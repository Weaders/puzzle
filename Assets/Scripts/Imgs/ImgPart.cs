using Game.Manager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Imgs {

    [RequireComponent(typeof(Drag.Drag))]
    public class ImgPart : MonoBehaviour {

        private Image spriteRenderer;
        private BoxCollider2D boxCollider;

        private PlaceForImg placeForImg;

        private Vector3 startLocalPos = Vector3.zero;

        private Vector3 scaleStart = Vector3.zero;

        public UnityEvent onMiss = new UnityEvent();

        public bool IsUseCustomPlacePos = false;

        public Vector3 CustomPlacePos = Vector3.zero;

        private double sizeSquare;

        private void Awake() {

            scaleStart = transform.localScale;

            spriteRenderer = GetComponent<Image>();
            boxCollider = GetComponent<BoxCollider2D>();

            placeForImg = GetComponent<PlaceForImg>();

            var drag = GetComponent<Drag.Drag>();

            drag.onEndDrag.AddListener(OnEndDrag);
            drag.onBeginDrag.AddListener(OnBeginDrag);
        }

        private void Start() {

            var sizeDelt = (transform as RectTransform).sizeDelta;
            sizeSquare = sizeDelt.x * sizeDelt.y * 0.85;

        }

        private void OnTriggerStay2D(Collider2D targetCollider) {

            var targetPlaceForImg = targetCollider.GetComponent<PlaceForImg>();

            if (targetPlaceForImg == null || targetPlaceForImg.img != this) {
                return;
            }

            var transformParent = transform.parent;

            // Left - top
            var lt = new Vector2(
                Mathf.Max(boxCollider.bounds.min.x, targetCollider.bounds.min.x),
                Mathf.Max(boxCollider.bounds.min.y, targetCollider.bounds.min.y)
            );

            lt = transformParent.transform.InverseTransformPoint(lt);

            // Bottom - right
            var br = new Vector2(
                Mathf.Min(boxCollider.bounds.max.x, targetCollider.bounds.max.x),
                Mathf.Min(boxCollider.bounds.max.y, targetCollider.bounds.max.y)
            );

            br = transformParent.transform.InverseTransformPoint(br);

            var sVector = br - lt;

            var s = sVector.x * sVector.y;

            if (s >= sizeSquare) {
                placeForImg = targetCollider.gameObject.GetComponent<PlaceForImg>();
            } else {
                placeForImg = null;
            }

        }

        private void OnTriggerExit2D(Collider2D collision) {

            if (collision.GetComponent<PlaceForImg>() == placeForImg) {
                placeForImg = null;
            }

        }

        private void OnEndDrag() {

            if (placeForImg != null) {

                if (IsUseCustomPlacePos) {
                    gameObject.transform.localPosition = CustomPlacePos;
                } else {
                    gameObject.transform.position = placeForImg.transform.position;
                }

                placeForImg.SetImg(this);
                transform.SetAsLastSibling();

                GetComponent<Drag.Drag>().enabled = false;

            } else {

                gameObject.transform.localPosition = startLocalPos;
                onMiss.Invoke();
                transform.localScale = scaleStart;

            }

        }

        private void OnBeginDrag() {

            startLocalPos = transform.localPosition;
            transform.localScale = Vector3.one;
            transform.SetAsLastSibling();

        }

    }

}