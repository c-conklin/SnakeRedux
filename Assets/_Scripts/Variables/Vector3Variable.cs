using UnityEngine;
using System;
using _Scripts.Shared;

namespace _Scripts.Variables
{
    [CreateAssetMenu(fileName = "Vector3Variable", menuName = VariableConstants.Menu.VECTOR3, order = 0)]
    public class Vector3Variable : ScriptableObject
    {
        public Vector3 Value;
    }
    
    [Serializable]
    public class Vector3Reference
    {
        public bool UseConstant = true;
        public Vector3 ConstantValue;
        public Vector3Variable Variable;

        public Vector3Reference()
        { }

        public Vector3Reference(Vector3 value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public Vector3 Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        public static implicit operator Vector3(Vector3Reference reference)
        {
            return reference.Value;
        }
    }
}
