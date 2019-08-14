using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Menu {

    public class Sun : MonoBehaviour, IPointerClickHandler {

        private Image image;

        private Color[] colors = new[] { Color.white, Color.red, Color.green };

        private int currentColor = 0;

        public float speed = 10f;

        public void OnPointerClick(PointerEventData eventData) {

            if (currentColor == colors.Length - 1) {
                currentColor = 0;
            } else {
                currentColor++;
            }

            image.color = colors[currentColor];

        }

        private void Awake() {
            image = GetComponent<Image>();
        }

        private void Update() {

            var startX = Screen.width / 2f + (transform as RectTransform).sizeDelta.x / 2;
            var highY = Screen.height / 2f - (transform as RectTransform).sizeDelta.y / 2;
            
            var step = speed * Time.deltaTime;

            transform.Rotate(new Vector3(0, 0, step), Space.Self);

            var newX = transform.localPosition.x + step;

            var xForCos = newX / startX;

            var newY = Mathf.Cos(xForCos) * highY;

            var deltaY = newY - transform.localPosition.y;

            transform.Translate(new Vector2(step, deltaY), Space.World);

            if (transform.localPosition.x > startX) {
                transform.localPosition = new Vector2(-startX, transform.localPosition.y);
            }

        }

    }

}
