using Game.Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Carousel {

    [RequireComponent(typeof(ScrollRect))]
    public class CarouselView : MonoBehaviour {

        public CarouselItem currentSelItem;

        public float leftMargin = 5;

        public RectTransform itemsContainer;

        private AudioSource mainSource;

        private ScrollRect scrollRect;

        public GameObject easyLevel;

        public GameObject hardLevel;


        private List<CarouselItem> currentItems = new List<CarouselItem>();

        private void Awake() {

            mainSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
            scrollRect = GetComponent<ScrollRect>();

        }

        public void ShowLvls(LvlType lvlType) {

            if (lvlType == LvlType.Easy) {

                easyLevel.SetActive(true);
                hardLevel.SetActive(false);
                scrollRect.content = easyLevel.transform as RectTransform;

            } else {

                easyLevel.SetActive(false);
                hardLevel.SetActive(true);
                scrollRect.content = hardLevel.transform as RectTransform;

            }

        }

        /// <summary>
        /// Add item for carousel
        /// </summary>
        /// <param name="item"></param>
        public void Add(CarouselItem item) {

            item.transform.SetParent(itemsContainer, false);

            if (currentSelItem == null) {
                currentSelItem = item;
            }

            currentItems.Add(item);

        }

        /// <summary>
        /// Remove all carousel items
        /// </summary>
        public void Clear() {

            var items = GetComponentsInChildren<CarouselItem>();

            foreach (var item in items) {
                Destroy(item.gameObject);
            }

            currentSelItem = null;
            currentItems.Clear();

            scrollRect.horizontalNormalizedPosition = 0f;

        }

        /// <summary>
        /// Get items.
        /// </summary>
        /// <returns></returns>
        public CarouselItem[] GetItems() {

            if (easyLevel.activeSelf) {
                return easyLevel.GetComponentsInChildren<CarouselItem>();
            } else {
                return hardLevel.GetComponentsInChildren<CarouselItem>();
            }
        }

        /// <summary>
        /// Slide to item.
        /// </summary>
        /// <param name="item"></param>
        public void SlideToItem(CarouselItem item) {

            var items = GetItems();

            for (var i = 0; i < items.Length; i++) {

                if (items[i] == item) {

                    Debug.Log($"Found item for index: {i}");

                    StartCoroutine(SetHorizontal(i * .1f + 0.1f, scrollRect));

                    break;

                }

            }

        }

        private IEnumerator SetHorizontal(float x, ScrollRect scrollRect) {

            yield return new WaitForEndOfFrame();
            scrollRect.horizontalNormalizedPosition = x;



        }
    }

}
