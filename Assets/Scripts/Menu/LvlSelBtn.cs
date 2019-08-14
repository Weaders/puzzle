using Game.Common;
using Game.Manager;
using Game.User;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Menu {

    public enum LvlType {
        Hard, Easy
    }

    public class LvlSelBtn : MonoBehaviour {

        public int SceneIndex = 0;
        public int lvlIndex = 0;

        public LvlType lvlType = LvlType.Easy;

        public bool byFullAccess = false;

        public Image image;

        public GameObject blockedImg;

        private GameObject bgObj;

        private BuyAccessPopup buyAccessPopup;

        private void Awake() {

            buyAccessPopup = GameObject
                .FindGameObjectWithTag("BuyAccess")
                .GetComponent<BuyAccessPopup>();
        }

        private void Start() {

            var userData = SceneData.GetUserData();

            userData.onChange.AddListener((user) => {
                UpdateByUserChange();
            });

            UpdateByUserChange();

        }

        public void OnClick() {

            var userData = SceneData.GetUserData();

            if (IsHaveAccess()) {
                SceneWalk.ToGame(SceneIndex);
            } else {
                buyAccessPopup.Show();
            }

        }

        private void UpdateByUserChange() {

            if (IsHaveAccess()) {
                blockedImg.gameObject.SetActive(false);
            } else {
                blockedImg.gameObject.SetActive(true);
            }

        }

        private bool IsHaveAccess() {

            if (!byFullAccess) {
                return true;
            }

            var userData = SceneData.GetUserData();

            if (lvlType == LvlType.Easy) {
                return userData.isAccessEasyLevel;
            } else {
                return userData.isAccessHardLevel;
            }
            
        }


        public void UpdateImg() {
            UpdateBgObj();
        }

        private Sprite GetImage() {

            var lvlTypeName = lvlType == LvlType.Easy ? "Easy" : "Hard";

            var imgPath = $"Images/Carousel/{lvlTypeName}/{lvlIndex}";

            Debug.Log($"Load image for scene: {imgPath}");

            return Resources.Load<Sprite>(imgPath);

        }

        private GameObject UpdateBgObj() {

            if (bgObj != null) {
                Destroy(bgObj);
            }

            Debug.Log($"Prefabs/PuzzleBG/{lvlIndex}");

            bgObj = Resources.Load<GameObject>($"Prefabs/PuzzleBG/{lvlIndex}");

            var bg = Instantiate(bgObj, gameObject.transform);

            bg.transform.SetAsFirstSibling();

            var bgRect = (bg.transform as RectTransform);
            var currentTransform = (gameObject.transform as RectTransform);

            bgRect.localPosition = Vector3.zero;

            Debug.Log($"Name - {transform.name}");

            var scaleX = (currentTransform.sizeDelta.x / bgRect.sizeDelta.x);
            var scaleY = ((currentTransform.sizeDelta.y - 100) / bgRect.sizeDelta.y);

            Debug.Log("------------------Before-------------------");

            Debug.Log($"Scale x - {scaleX}, Scale y - {scaleY}");

            Debug.Log($"Bg rect - TopLeft - {bgRect.offsetMin}|BottomRight - {bgRect.offsetMax}");
            Debug.Log($"Current rect - TopLeft - {bgRect.offsetMin}|BottomRight - {bgRect.offsetMax}");

            Debug.Log("/------------------Before-------------------/");

            //bgRect.localScale = new Vector3(scaleX, scaleY, 1);

            Debug.Log("------------------After-------------------");

            Debug.Log($"Bg rect - TopLeft - {bgRect.offsetMin}|BottomRight - {bgRect.offsetMax}");
            Debug.Log($"Current rect - TopLeft - {bgRect.offsetMin}|BottomRight - {bgRect.offsetMax}");

            Debug.Log("/------------------After-------------------/");

            return bgObj;

        }

    }

}
