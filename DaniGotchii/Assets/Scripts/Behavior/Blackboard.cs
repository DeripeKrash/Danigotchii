using System.Collections.Generic;
using UnityEngine;

public class Blackboard : MonoBehaviour
{
    [System.Serializable]
    public class Variable
    {
        [SerializeField] private string _name;
        [SerializeField] private float _value;

        public string Name => _name;

        public float Value
        {
            get => _value;
            set => _value = value;
        }
    }
    [SerializeField] private List<Variable> _variables = new List<Variable>();
    
    public float GetValue(string varName)
    {
        foreach (Variable variable in _variables)
        {
            if (variable.Name == varName)
                return variable.Value;
        }

        return 0.0f;
    }

    public Variable FindVariable(string varName)
    {
        foreach (Variable variable in _variables)
        {
            if (variable.Name == varName)
            {
                return variable;
            }
        }
        
        Debug.LogError($"The name \"{varName}\" is invalid.");

        return null;
    }
}