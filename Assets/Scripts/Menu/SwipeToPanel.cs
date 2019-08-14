using Game.Manager;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Menu {

    public class SwipeToPanel : MonoBehaviour {

        public MenuPanel target;

        private float speed;

        private AudioClip audioClip;

        private AudioSource audioSource;

        private void Awake() {

            audioClip = Resources.Load<AudioClip>("AudioClips/BtnClick");
            audioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();

        }

        public void Swipe() {

            Debug.Log("Action swipe");

            var panels = GameObject
                .FindGameObjectsWithTag("MenuPanel")
                .Select(x => x.transform as RectTransform);

            var menuMng = GameObject
                .FindGameObjectWithTag("MenuMng")
                .GetComponent<MenuMng>();

            menuMng.PrevMenuPanel = menuMng.CurrentMenuPanel;
            menuMng.CurrentMenuPanel = target;

            if (target.transform.localPosition.x != 0) {
                StartCoroutine(Move(panels));
            }

            audioSource.PlayOneShot(audioClip);

            speed = Mathf.Abs(target.transform.localPosition.x * 4f);

            Debug.Log("End action swipe");

        }

        private IEnumerator Move(IEnumerable<RectTransform> panels) {

            Debug.Log($"Start swipe to {target.gameObject.name}");

            while (target.transform.localPosition.x != 0) {

                var sign = target.transform.localPosition.x > 0 ? -1 : 1;

                var x = sign * (speed * Time.fixedDeltaTime);

                if (Mathf.Abs(x) > Mathf.Abs(target.transform.localPosition.x)) {

                    if (Mathf.Abs(target.transform.localPosition.x) < .0001f) {

                        foreach (var panel in panels) {
                            panel.transform.localPosition = panel.transform.localPosition + new Vector3(-target.transform.localPosition.x, 0, 0);
                        }

                        Debug.Log($"Break on local position  - {target.transform.localPosition.x}");
                        break;

                    }

                    x = -target.transform.localPosition.x;

                    Debug.Log("LX: " + target.transform.localPosition.x + " X: " + x);

                }

                foreach (var panel in panels) {
                    panel.transform.localPosition = panel.transform.localPosition + new Vector3(x, 0, 0);
                }

                yield return new WaitForEndOfFrame();

            }

            Debug.Log("End swipe");

        }

    }

}
