using UnityEngine;
using UnityEngine.Events;

namespace Imgs {

    public class PlaceForImg : MonoBehaviour {

        public ImgPart img;

        public bool isPlaced = false;

        public UnityEvent onPlaced = new UnityEvent();

        public void SetImg(ImgPart _img) {

            img = _img;
            isPlaced = true;
            onPlaced.Invoke();

        }

    }

}
