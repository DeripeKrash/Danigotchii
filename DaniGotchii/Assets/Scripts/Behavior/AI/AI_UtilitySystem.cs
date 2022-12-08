using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AI_UtilitySystem : MonoBehaviour
{
    public List<AI_UtilityState> listState = new List<AI_UtilityState>();
    public AI_UtilityState currentState = null;
        
    // Start is called before the first frame update
    void Start()
    {
        if (listState.Count == 0)
            SetupFromChildren();
        
        if (currentState == null && listState.Count > 0)
            currentState = listState[0];

        if (currentState == null)
            enabled = false;
        
        currentState.Setup();
    }

    private void Update()
    {
        CheckForStateChange();
    }

    private void CheckForStateChange()
    {
        currentState.DoAction();
        
        if (!currentState.CanExitState())
        {
            return;
        }
        
        currentState.gameObject.SetActive(false);

        float MaxValue = 0f;
        float checkValue;
        
        for (int i = 0; i < listState.Count; i++)
        {
            checkValue = listState[i].Priority();

            if (checkValue > MaxValue)
            {
                currentState = listState[i];
                MaxValue = checkValue;
            }
        }
        
        currentState.gameObject.SetActive(true);
        currentState.Setup();
    }

    public void SetupFromChildren()
    {
        listState.Clear();

        float maxPriority = 0f;
        float checkPriority = 0f;

        for (int i = 0; i < transform.childCount; i++)
        {
            AI_UtilityState state = transform.GetChild(i).gameObject.GetComponent<AI_UtilityState>();

            if (state)
            {
                state.gameObject.SetActive(false);
                //state.Setup();
                listState.Add(state);
                checkPriority = state.Priority();
                if (checkPriority > maxPriority)
                {
                    currentState = state;
                    maxPriority = checkPriority;
                }
            }
        }
    }
}


[CustomEditor(typeof(AI_UtilitySystem))]
public class AI_UtilitySystemInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if (GUILayout.Button("Set List with Children"))
        {
            AI_UtilitySystem stateMachine = target as AI_UtilitySystem;
            if (stateMachine)
                stateMachine.SetupFromChildren();

        }
    }
}

