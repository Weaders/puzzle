using Game.Carousel;
using Game.Common;
using Game.Menu;
using System.Linq;
using UnityEngine;

namespace Game.Manager {

    [RequireComponent(typeof(SwipeToPanel))]
    public class MenuMng : MonoBehaviour {

        public LvlCategroyRoot lvlCategoryRoot;

        public GameObject musicObj;

        public MenuPanel CurrentMenuPanel;

        public MenuPanel PrevMenuPanel;

        private SwipeToPanel swipeToPanel;

        private void Awake() {

            SceneData.Clear();
            swipeToPanel = GetComponent<SwipeToPanel>();

        }

        private void Update() {

            if (Input.GetKeyUp(KeyCode.Escape) && CurrentMenuPanel != null && CurrentMenuPanel.panelType == MenuPanelType.Levels) {

                var panels = GameObject.FindGameObjectsWithTag("MenuPanel")
                    .Select(x => x.GetComponent<MenuPanel>())
                    .ToArray();

                for (var i = 0; i < panels.Length; i++) {

                    if (panels[i].panelType == MenuPanelType.Category) {

                        swipeToPanel.target = panels[i];
                        swipeToPanel.Swipe();

                    }
                    
                }

            }

        }

        public void RemoveOldMusic() {
            Destroy(musicObj);
        }

        public void SwitchToCategorySelect(int sceneIndex) {

            var ctgBtn = lvlCategoryRoot.GetCategoryBtn(sceneIndex);

            var panels = GameObject
                .FindGameObjectsWithTag("MenuPanel")
                .Select(x => x.GetComponent<MenuPanel>());

            var levelsPanel = panels
                .FirstOrDefault(p => p.panelType == MenuPanelType.Levels);

            var targetTransform = levelsPanel.transform as RectTransform;

            var categoryPanel = panels
                .FirstOrDefault(p => p.panelType == MenuPanelType.Category);

            if (targetTransform.localPosition.x != 0) {

                var trVector = new Vector3(-targetTransform.localPosition.x, 0, 0);

                Debug.Log($"Move to category panel - {trVector}");

                // Load levels
                categoryPanel
                    .GetComponentsInChildren<LvlCategorySelBtn>()
                    .First(btn => btn.sceneIndexes.Any(l => l == sceneIndex))
                    .LoadLvls();

                foreach (var panel in panels) {

                    Debug.Log($"Before: " + panel.transform.localPosition);
                    panel.transform.localPosition = panel.transform.localPosition + trVector;
                    Debug.Log($"After: " + panel.transform.localPosition);

                }

            }

            var carouselView = levelsPanel.gameObject.GetComponent<CarouselView>();

            var selItem = carouselView.GetItems().First(x => x.GetComponent<LvlSelBtn>().SceneIndex == sceneIndex);

            CurrentMenuPanel = levelsPanel;
            
            carouselView.SlideToItem(selItem);

        }

    }

}
