using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Comparers;


public enum GraphFunctionType : byte
{
    Linear,
    Exponential,
    Sigmoid,
    Logarithmic,
    Logistic,
    Curve
}

[System.Serializable]
public class GraphFunction
{
    public GraphFunctionType type;

    public float coefficient = 1f;
    public float offset = 0f;
    public float power = 2f;
    public float logExponential = 2f;
    public float sigCoefficient = 1f;
    public float sigOffset = -0.5f;
    
    //Logistic value
    public float k = 1f;
    public float a = 1f;
    public float r = 1f;
    
    public AnimationCurve curve = new AnimationCurve();
    
    public float GetValue(float x)
    {
        switch (type)
        {
            case GraphFunctionType.Linear : return Linear(x, coefficient, offset);
            case GraphFunctionType.Exponential : return Exponential(x, power);
            case GraphFunctionType.Sigmoid : return Sigmoide(x, sigCoefficient, sigOffset);
            case GraphFunctionType.Logarithmic : return Logarithmic(x, logExponential);
            case GraphFunctionType.Logistic : return Logistic(x);
            case GraphFunctionType.Curve : return Curve(x, curve);
        }
    
        return 0f;
    }
    
    public static float Linear(float x, float coefficient = 1f, float offset = 0f)
    {
        return coefficient * x + offset;
    }
    
    public static float Exponential(float x, float power)
    {
        return Mathf.Pow(x, power);
    }

    public static float Sigmoide(float x, float logExponential, float sigOffset)
    {
        return 1 / (1 + Mathf.Exp(-logExponential * x)) + sigOffset;
    }

    public static float Logarithmic(float x, float logExponential)
    {
        return Mathf.Pow(x, logExponential);
    }

    public static float Logistic(float x, float k = 1.0f, float r = 1.0f, float a = 1.0f)
    {
        float temp = a * Mathf.Exp(-r * x);

        if (Mathf.Approximately(temp, -1))
            return 0;

        return k/(1 + temp);
    }

    public static float Curve(float x, AnimationCurve curve)
    {
        return curve.Evaluate(x);
    }
    
    public virtual void InspectorDisplay() { }
}

// A custom editor must be created to use GraphFunction in inspector

[CustomPropertyDrawer(typeof(GraphFunction))]
public class GraphFunctionInspector : PropertyDrawer
{
    private bool bfoldout = true;
    
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight * (EditorGUIUtility.wideMode ? 1 : 2);
    }
    
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        bfoldout = EditorGUILayout.Foldout(bfoldout, label);
        
        if(bfoldout)
        {
            SerializedProperty typeProperty = property.FindPropertyRelative("type");
            GraphFunctionType type = (GraphFunctionType) typeProperty.enumValueIndex;

            EditorGUILayout.PropertyField(typeProperty);

            switch (type)
            {
                case GraphFunctionType.Linear : {LinearDisplay(property); return;}
                case GraphFunctionType.Exponential : {ExponentialDisplay(property); return;}
                case GraphFunctionType.Logarithmic :  {LogarithmicDisplay(property); return;}
                case GraphFunctionType.Logistic : {LogisticDisplay(property); return;}
                case GraphFunctionType.Sigmoid :  {SigmoidDisplay(property); return;}
                case GraphFunctionType.Curve : {CurveDisplay(property); return;}
            }
        }
    }

    private void LinearDisplay(SerializedProperty property)
    {
        SerializedProperty power = property.FindPropertyRelative("coefficient");
        power.floatValue = EditorGUILayout.FloatField("coefficient", power.floatValue);
        
        SerializedProperty offset = property.FindPropertyRelative("offset");
        offset.floatValue = EditorGUILayout.FloatField("offset", offset.floatValue);
    }

    private void ExponentialDisplay(SerializedProperty property)
    {
        SerializedProperty power = property.FindPropertyRelative("power");
        power.floatValue = EditorGUILayout.FloatField("power", power.floatValue);
    }

    private void LogarithmicDisplay(SerializedProperty property)
    {
        SerializedProperty logExponential = property.FindPropertyRelative("logExponential");
        logExponential.floatValue = Mathf.Clamp(EditorGUILayout.FloatField("exponential", logExponential.floatValue), 0f, 1f);
    }

    private void SigmoidDisplay(SerializedProperty property)
    {
        SerializedProperty power = property.FindPropertyRelative("sigCoefficient");
        power.floatValue = EditorGUILayout.FloatField("coefficient", power.floatValue);
        
        SerializedProperty offset = property.FindPropertyRelative("sigOffset");
        offset.floatValue = EditorGUILayout.FloatField("offset", offset.floatValue);
    }
    
    private void LogisticDisplay(SerializedProperty property)
    {
        SerializedProperty k = property.FindPropertyRelative("k");
        k.floatValue = EditorGUILayout.FloatField("k", k.floatValue);
        
        SerializedProperty a = property.FindPropertyRelative("a");
        a.floatValue = EditorGUILayout.FloatField("a", a.floatValue);
        
        SerializedProperty r = property.FindPropertyRelative("r");
        r.floatValue = EditorGUILayout.FloatField("r", r.floatValue);
    }

    private void CurveDisplay(SerializedProperty property)
    {
        SerializedProperty animationCurve = property.FindPropertyRelative("curve");
        animationCurve.animationCurveValue = EditorGUILayout.CurveField("curve", animationCurve.animationCurveValue);
    }
}

