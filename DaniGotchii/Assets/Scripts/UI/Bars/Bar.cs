using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Blackboard _blackboard = null;
    [SerializeField]private string _variableName = null;
    
    private Slider _slider = null;
    

    private void Start()
    {
        if (!_slider)
            _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (_slider)
        {
            _slider.value = _blackboard.GetValue(_variableName);
        }
    }
}
