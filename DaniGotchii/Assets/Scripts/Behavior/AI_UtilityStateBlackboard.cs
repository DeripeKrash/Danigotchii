using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class AI_UtilityStateBlackboard : AI_UtilityState
{
    [SerializeField] protected Blackboard _blackboard = null;
    [SerializeField] protected string variableToUse;
    
    [SerializeField] public GraphFunction graphFunction = new GraphFunction();
    
    protected Blackboard.Variable _blackboardVariable = null;
    
    public override void Setup()
    {
        base.Setup();

        _blackboardVariable = _blackboard.FindVariable(variableToUse);
    }

    public override float Priority()
    {
        if (_blackboardVariable == null)
        {
            _blackboardVariable = _blackboard.FindVariable(variableToUse);
        }
     
        Debug.Assert(_blackboardVariable != null, "Blackboard Variable is Null in " + gameObject.name);
        
        if (_blackboardVariable != null)
            return  graphFunction.GetValue(_blackboardVariable.Value);
        
        return 0f;
    }

    public override bool CanExitState()
    {
        return true;
    }
}

// A custom editor must be created to use GraphFunction
[CustomEditor(typeof(AI_UtilityStateBlackboard), true)]
public class UtilityStateBlackboardEditor : Editor { }

