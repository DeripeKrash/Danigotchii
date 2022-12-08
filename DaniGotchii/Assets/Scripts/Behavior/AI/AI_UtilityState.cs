using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AI_UtilityState : MonoBehaviour
{
    public UnityEvent onSetup;
    public UnityEvent onAction;

    // Called when the State in enable
    public virtual void Setup()
    {
        onSetup?.Invoke();
    }
    
    // Called each Update when the State is enable 
    public virtual void DoAction()
    {
        onAction?.Invoke();
    }
    
    public virtual float Priority()
    {
        return 0.0f;
    }

    // Used to know if the the State can end safely
    public virtual bool CanExitState()
    {
        return true;
    }
}
