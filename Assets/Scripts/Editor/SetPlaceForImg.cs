using System.CodeDom;
using Imgs;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor {

    [CustomEditor(typeof(PlaceForImg))]
    public class SetPlaceForImg : UnityEditor.Editor {
        public override void OnInspectorGUI() {

            DrawDefaultInspector();

            if (GUILayout.Button("SetFromImgPart")) {

                var plImg = (target as PlaceForImg);

                plImg.transform.localPosition = plImg.img.transform.localPosition;
                (plImg.transform as RectTransform).sizeDelta = (plImg.img.transform as RectTransform).sizeDelta;

            }

        }
    }
    
}