using Game.Manager;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Common {

    public enum LvlCategories {
        Easy, Hard
    }

    public class SceneWalk : MonoBehaviour {

        private static bool isLoaded;

        public static void ToMenuLvls(int lvlIndex) {

            if (isLoaded) {
                return;
            }

            isLoaded = true;

            var sceneAsync = SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);

            sceneAsync.completed += (opr) => {

                GameData.stateData = new MenuState();
                GameData.stateType = GameState.Menu;

                var musicObj = GameObject.FindGameObjectWithTag("Music");

                SceneManager.MoveGameObjectToScene(musicObj, SceneManager.GetSceneByBuildIndex(0));

                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

                var menuMng = GameObject.FindGameObjectWithTag("MenuMng").GetComponent<MenuMng>();

                menuMng.RemoveOldMusic();

                menuMng.SwitchToCategorySelect(lvlIndex);

                isLoaded = false;

            };

        }

        public static void ToMenu() {

            if (isLoaded) {
                return;
            }

            isLoaded = true;

            var sceneAsync = SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);

            sceneAsync.completed += (opr) => {

                GameData.stateType = GameState.Menu;
                GameData.stateData = new MenuState();

                var musicObj = GameObject.FindGameObjectWithTag("Music");

                SceneManager.MoveGameObjectToScene(musicObj, SceneManager.GetSceneByBuildIndex(0));

                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

                GameObject
                    .FindGameObjectWithTag("MenuMng")
                    .GetComponent<MenuMng>()
                    .RemoveOldMusic();

                isLoaded = false;

            };

        }

        public static void ToGame(int sceneIndex) {

            if (isLoaded) {
                return;
            }

            isLoaded = true;

            var sceneAsync = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);

            sceneAsync.completed += (opr) => {

                GameData.stateType = GameState.Game;
                GameData.stateData = new InGameState() {
                    lvlIndex = sceneIndex
                };

                var musicObj = GameObject.FindGameObjectWithTag("Music");

                SceneManager.MoveGameObjectToScene(musicObj, SceneManager.GetSceneByBuildIndex(sceneIndex));

                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

                isLoaded = false;

            };

        }

    }

}
