using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    [FormerlySerializedAs("_interactionManager")] [SerializeField] private DaniGotchiiInteractionManager daniGotchiiInteractionManager = null;
    
    private Dropdown _dropdown = null;
    private Button _button = null;
    
    private void Start()
    {
        if (_dropdown == null)
            _dropdown = GetComponentInChildren<Dropdown>();
        
        if (_button == null)
            _button = GetComponentInChildren<Button>();

        Initialize();

    }

    private void Initialize()
    {
        if (daniGotchiiInteractionManager && _dropdown)
        {
            _dropdown.ClearOptions();
            List<string> funcsName = new List<string>();
            foreach (Interaction interaction in daniGotchiiInteractionManager.Interactions)
            {
                funcsName.Add(interaction.FunctionName);
            }
            _dropdown.AddOptions(funcsName);
        }
        _button.onClick.AddListener(OnClick);
    }
    
    private void OnClick()
    {
        daniGotchiiInteractionManager.DoFunction(_dropdown.options[_dropdown.value].text);
    }
}