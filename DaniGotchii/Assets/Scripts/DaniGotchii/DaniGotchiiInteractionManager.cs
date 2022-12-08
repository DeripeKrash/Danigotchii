using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interaction
{
    [SerializeField] private string _functionName;
    [SerializeField] private List<Blackboard.Variable> _variables;
    
    public string FunctionName => _functionName;
    public List<Blackboard.Variable> Variables => _variables;
}


public class DaniGotchiiInteractionManager: MonoBehaviour
{
    [SerializeField] private DaniGotchii _daniGotchii = null;
    [SerializeField] private List<Interaction> _interactions = new List<Interaction>();
    public List<Interaction> Interactions => _interactions;

    public void DoFunction(string functionName)
    {
        if (!_daniGotchii)
            return;
        
        foreach (Interaction interaction in _interactions)
        {
            if (interaction.FunctionName == functionName)
            {
                foreach (Blackboard.Variable variable in interaction.Variables)
                {
                    _daniGotchii.FillNeed(variable.Name, variable.Value);    
                }
                
                return;
            }

        }
        Debug.LogWarning($"The name \"{functionName}\" is invalid.");
    }
}
