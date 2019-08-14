using Game.Carousel;
using UnityEngine;

namespace Game.Menu {

    [RequireComponent(typeof(SwipeToPanel))]
    public class LvlCategorySelBtn : MonoBehaviour {

        public CarouselView carousel;

        public LvlSelBtn btnPrefab;

        public int[] sceneIndexes;

        public LvlType lvlType;

        private SwipeToPanel swipeToPanel;
        
        public void OnClick() {

            swipeToPanel = GetComponent<SwipeToPanel>();

            LoadLvls();

            swipeToPanel.Swipe();

        }

        /// <summary>
        /// Clear carousel items, after add new from lvls field.
        /// </summary>
        public void LoadLvls() {

            carousel.ShowLvls(lvlType);

            //carousel.Clear();

            //for (var i = 0; i < sceneIndexes.Length; i++) {

            //    var btn = Instantiate(btnPrefab.gameObject);

            //    var selBtn = btn.GetComponent<LvlSelBtn>();

            //    selBtn.lvlIndex = sceneIndexes[i];
            //    selBtn.SceneIndex = sceneIndexes[i];
            //    selBtn.lvlType = lvlType;
            //    selBtn.byFullAccess = lvlType == LvlType.Hard || i >= 3;

            //    selBtn.UpdateImg();

            //    carousel.Add(btn.gameObject.GetComponent<CarouselItem>());

            //}

        }

    }
}
