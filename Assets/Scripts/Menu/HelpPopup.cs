using UnityEngine;

namespace Assets.Scripts.Menu {

    [RequireComponent(typeof(CanvasGroup))]
    public class HelpPopup : MonoBehaviour {

        private CanvasGroup canvasGroup;

        private void Awake() {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start() {
            Hide();
        }

        public void Show() {

            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

        }

        public void Hide() {

            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

        }

    }
}
