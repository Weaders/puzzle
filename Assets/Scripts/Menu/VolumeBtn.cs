using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu {

    [RequireComponent(typeof(Animator))]
    public class VolumeBtn : MonoBehaviour {

        public bool volumeToggled = true;

        public GameObject offIcon;

        private Animator animator;

        private void Awake() {

            animator = GetComponent<Animator>();

            if (AudioListener.volume == 1) {
                offIcon.SetActive(false);
                animator.SetBool("VolumePlay", true);
            } else {
                animator.SetBool("VolumePlay", false);
                offIcon.SetActive(true);
            }

        }

        public void OnClick() {

            volumeToggled = !volumeToggled;

            if (volumeToggled) {

                offIcon.SetActive(false);
                AudioListener.volume = 1;
                animator.SetBool("VolumePlay", true);

            } else {

                offIcon.SetActive(true);
                AudioListener.volume = 0;
                animator.SetBool("VolumePlay", false);

            }

        }

    }
}
