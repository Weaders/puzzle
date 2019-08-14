using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor {
    
    [CustomEditor(typeof(BoxCollider2D))]
    public class ColliderSize : UnityEditor.Editor
    {
        public override void OnInspectorGUI() {

            DrawDefaultInspector();

            if (GUILayout.Button("SetSize")) {

                var boxCol = target as BoxCollider2D;

                var rectTransform = (boxCol.transform as RectTransform);
                
                var vectorCorns = new Vector3[4];
                
                rectTransform.GetLocalCorners(vectorCorns);

                boxCol.size = new Vector2(vectorCorns[2].x - vectorCorns[0].x, vectorCorns[1].y - vectorCorns[0].y);

//                boxCol.size = (boxCol.transform as RectTransform).sizeDelta;

            }
            
        }
    }
   
    
}


