using System.Collections.Generic;
using UnityEngine;

public class DaniGotchii : MonoBehaviour
{
    #region Class & Struct

    [System.Serializable]
    public class Need
    {
        [SerializeField] private string _name;
        [SerializeField,Tooltip("In minutes")] private float _duration;

        public string Name => _name;
        public float Duration => _duration;
        [System.NonSerialized] private Blackboard.Variable _variable;

        public Blackboard.Variable Variable
        {
            get => _variable;
            set => _variable = value;
        }
    }

    #endregion

    [SerializeField] private List<Need> _needs = new List<Need>();
    [SerializeField] private Blackboard _blackboard = null;

    private void Start()
    {
        InitNeeds();
    }

    private void Update()
    {
        UpdateNeeds();
    }
    
    #region Needs function

    public float GetValue(string varName)
    {
        foreach (Need need in _needs)
        {
            if (need.Name == varName)
                return need.Duration;
        }
        
        Debug.LogError("The name \"{varName}\" is invalid.");
        return 0.0f;
    }

    private Need FindValue(string varName)
    {
        foreach (Need need in _needs)
        {
            if (need.Name == varName)
                return need;
        }

        Debug.LogError($"The name is \"{varName}\" invalid.");
        return null;
    }

    private void UpdateNeeds()
    {
        foreach (Need need in _needs)
        {
            if (need.Variable != null)
            {
                need.Variable.Value += (1.0f / (need.Duration * 60.0f)) * Time.deltaTime;
                need.Variable.Value = Mathf.Clamp(need.Variable.Value, 0.0f, 1.0f);
                
            }
        }
    }

    private void InitNeeds()
    {
        if (!_blackboard)
        {
            Debug.LogError("The reference to the blackboard is null.");
            return;
        }

        foreach (Need need in _needs)
        {
            Blackboard.Variable tempVar = _blackboard.FindVariable(need.Name);

            if (tempVar != null)
            {
                need.Variable = tempVar;
                need.Variable.Value = Mathf.Clamp(need.Variable.Value, 0.0f, 1.0f);
            }
            else
                Debug.LogWarning($"The name \"{need.Name}\" doesn't correspond to a blackboard variable name.");
        }
    }

    public void FillNeed(string varName, float value)
    {
        foreach (Need need in _needs)
        {
            if (need.Name == varName)
            {
                need.Variable.Value += value;
                return;
            }
        }
        Debug.LogError($"the name \"{varName}\" is invalid.");
    }

    #endregion
}