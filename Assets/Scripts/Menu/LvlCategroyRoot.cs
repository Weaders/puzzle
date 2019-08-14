using System;
using System.Linq;
using UnityEngine;

namespace Game.Menu {
    public class LvlCategroyRoot : MonoBehaviour {

        private LvlCategorySelBtn[] btns;

        private void Awake() {
            btns = GetComponentsInChildren<LvlCategorySelBtn>();
        }

        /// <summary>
        /// Get category btn for level index.
        /// </summary>
        /// <param name="levelIndex"></param>
        /// <returns></returns>
        public LvlCategorySelBtn GetCategoryBtn(int levelIndex) {

            foreach (var btn in btns) {

                var lvl = btn.sceneIndexes.FirstOrDefault(b => b == levelIndex);

                if (lvl != default) {
                    return btn;
                }

            }

            throw new Exception("Can not get category button");

        }

    }
}
