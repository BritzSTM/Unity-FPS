using System;
using UnityEngine;

namespace Fd
{
    [AttributeUsage( (AttributeTargets.Field | AttributeTargets.Property), AllowMultiple = true, Inherited = true)]
    public class RequiredTypeAttribute : PropertyAttribute
    {
        public readonly Type CheckType;
        public readonly bool UseEditorInjector;

        /// <param name="checkTypes"></param>
        /// <param name="useReferenceInjector">Use object reference injector in unity editor inspector.</param>
        public RequiredTypeAttribute( Type checkType, bool useEditorInjector = true )
        {
            CheckType = checkType;
            UseEditorInjector = useEditorInjector;
        }
    }
}