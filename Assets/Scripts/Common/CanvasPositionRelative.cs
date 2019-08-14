using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Common {
    public class CanvasPositionRelative : MonoBehaviour {

        private CanvasScaler canvasScaler;

        private void Awake() {

            canvasScaler = GameObject
                .FindGameObjectWithTag("MainCanvas")
                .GetComponent<CanvasScaler>();

            var posRef = canvasScaler.referenceResolution.y / Screen.height;

            var localPos = transform.localPosition;

            //Debug.Log($"Old position: {localPos}");

            //transform.localPosition = new Vector3(localPos.x, localPos.y + localPos.y * posRef, localPos.z);

            //Debug.Log($"Old position: {transform.localPosition}, {posRef}, {localPos.y * posRef}");

        }

    }
}
