using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Balloon {

    [RequireComponent(typeof(Animator))]
    public class Balloon : MonoBehaviour {

        public UnityEvent onDestroyEvent = new UnityEvent();

        private Animator animator;

        private AudioSource audioSource;

        private void Awake() {

            animator = GetComponent<Animator>();

            var musicObj = GameObject.FindGameObjectWithTag("Music");

            if (musicObj == null)
            {
                musicObj = GameObject.FindObjectOfType<AudioSource>().gameObject;
            }

            audioSource = musicObj.GetComponent<AudioSource>();

        }

        public void Boom(int animRange) {
            audioSource.PlayOneShot(Resources.Load<AudioClip>("AudioClips/BalloonExplosing"));
            animator.SetBool($"Boom{animRange}", true);
        }

        private void BalloonDestroy() {
            onDestroyEvent.Invoke();
        }

    }

}
