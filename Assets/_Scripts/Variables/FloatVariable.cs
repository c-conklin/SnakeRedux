using UnityEngine;
using System;
using _Scripts.Shared;

namespace _Scripts.Variables
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = VariableConstants.Menu.FLOAT, order = 0)]
    public class FloatVariable : ScriptableObject
    {
        public float Value;       
    }
    
    [Serializable]
    public class FloatReference
    {
        public bool UseConstant = true;
        public float ConstantValue;
        public FloatVariable Variable;

        public FloatReference()
        { }

        public FloatReference(float value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public float Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        public static implicit operator float(FloatReference reference)
        {
            return reference.Value;
        }
    }
}
