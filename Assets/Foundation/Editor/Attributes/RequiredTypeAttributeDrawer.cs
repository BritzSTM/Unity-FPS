using UnityEngine;
using UnityEditor;

namespace Fd.Editor
{
    [CustomPropertyDrawer( typeof( RequiredTypeAttribute ) )]
    public class RequiredTypeAttributeDrawer : PropertyDrawer
    { 
        public override void OnGUI( Rect position, SerializedProperty property, GUIContent label )
        {
            EditorGUI.BeginProperty(position, label, property);

            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                var attr = attribute as RequiredTypeAttribute;
                var refer = EditorGUI.ObjectField(
                    position, label, property.objectReferenceValue, typeof(UnityEngine.Object), true);
             
                if (refer != null)
                {
                    if (refer is GameObject go)
                        refer = go.GetComponent(attr.CheckType);
                    else if (!attr.CheckType.IsAssignableFrom(refer.GetType()))
                    {
                        Debug.LogWarning("Failed assign data");
                        refer = null;
                    }
                }

                property.objectReferenceValue = refer;
            }
            else
            {
                var prevColor = GUI.color;
                GUI.color = Color.red;

                EditorGUI.LabelField(position, label, new GUIContent("Property is not reference type"));

                GUI.color = prevColor;
            }

            EditorGUI.EndProperty();
        }
    }
}