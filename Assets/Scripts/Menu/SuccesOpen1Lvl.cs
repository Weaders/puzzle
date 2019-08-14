using UnityEngine;

namespace Assets.Scripts.Menu {
    [RequireComponent(typeof(CanvasGroup))]
    public class SuccesOpen1Lvl : MonoBehaviour {

        private CanvasGroup canvasGroup;

        private void Awake() {

            canvasGroup = GetComponent<CanvasGroup>();

        }

        public void Show() {

            canvasGroup.interactable = true;
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;

        }

        public void Hide() {

            canvasGroup.interactable = false;
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;

        }

    }
}
