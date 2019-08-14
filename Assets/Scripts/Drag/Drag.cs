using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Drag {

    public class Drag : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {

        public UnityEvent onEndDrag = new UnityEvent();
        public UnityEvent onBeginDrag = new UnityEvent();

        private Vector3 localStartPos;

        public void OnDrag(PointerEventData eventData) {
            gameObject.transform.position += new Vector3(eventData.delta.x, eventData.delta.y, 0);
        }

        public void OnEndDrag(PointerEventData eventData) {
            onEndDrag.Invoke();
        }

        public void OnBeginDrag(PointerEventData eventData) {
            onBeginDrag.Invoke();
        }
    }

}