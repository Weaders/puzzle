using Assets.Scripts.IAP;
using Assets.Scripts.Task;
using Game.Common;
using Game.Menu;
using UnityEngine;

namespace Game.Menu {
    public class FullAccessBtn : MonoBehaviour {

        public StoreMng storyMng;

        public TaskCtrl taskCtrl;

        private void Start() {

            taskCtrl.onSuccess.AddListener(() => {
                storyMng.BuyUpgradeForFullVersion();
            });
        }

        public void OnClick() {

            taskCtrl.Show();

            GetComponentInParent<BuyAccessPopup>().Hide();

        }

    }

}
