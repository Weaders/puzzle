using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Task {

    [RequireComponent(typeof(Button))]
    public class TaskBtn : MonoBehaviour {

        public GameObject disableHover;
        public int number;

        public void DisableByHover() {
            disableHover.SetActive(true);
        }

        public void EnableByHover() {
            disableHover.SetActive(false);
        }

    }
}
