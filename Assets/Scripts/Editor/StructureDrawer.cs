using Lunari.Tsuki;
using UnityEditor;
using UnityEngine;

namespace Editor {
    [CustomPropertyDrawer(typeof(Structure))]
    public class StructureDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var h = property.FindPropertyRelative("height");
            var w = property.FindPropertyRelative("width");
            EditorGUI.PropertyField(position.GetLine(0), h);
            EditorGUI.PropertyField(position.GetLine(1), w);
            var comp = property.FindPropertyRelative("composition");
            var width = w.intValue;
            var height = h.intValue;
            var editorWidth = /*position.width / width*/16F;
            comp.arraySize = width * height;
            for (var y = 0; y < h.intValue; y++) {
                for (var x = 0; x < width; x++) {
                    var e = comp.GetArrayElementAtIndex(y * width + x);
                    e.boolValue =
                        EditorGUI.Toggle(
                            position.SetXMin(position.xMin + x * editorWidth)
                                .SetYMin(position.yMin + (y + 2) * EditorGUIUtility.singleLineHeight)
                                .SetWidth(editorWidth)
                                .SetHeight(EditorGUIUtility.singleLineHeight),
                            e.boolValue);
                }
            }
        }


        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return (property.FindPropertyRelative("height").intValue + 2) *
                   EditorGUIUtility.singleLineHeight;
        }
    }
}