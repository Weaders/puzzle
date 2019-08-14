using Game.Common;
using UnityEngine;

namespace Game.GameScripts {

    public class ToMenu : MonoBehaviour {

        public void OnClick() {
            SceneWalk.ToMenu();
        }

        public void ToMenuWithLevel() {

            var lvlIndex = (GameData.stateData as InGameState).lvlIndex;
            SceneWalk.ToMenuLvls(lvlIndex);

        }

    }

}
