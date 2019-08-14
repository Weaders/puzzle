using UnityEngine;

namespace Game.Menu {

    public class BuyAccessPopup : MonoBehaviour {

        private CanvasGroup canvasGroup;

        private void Awake() {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Show() {

            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;

        }

        public void Hide() {

            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;

        }

    }

}
