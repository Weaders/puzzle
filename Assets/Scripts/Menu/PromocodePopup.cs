using Game.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Menu {
    public class PromocodePopup  : MonoBehaviour {

        public TMP_InputField inputField;

        public GameObject errorMsg;

        private CanvasGroup canvasGroup;

        private SuccesOpen1Lvl successOpenLvl1;

        private void Awake() {

            canvasGroup = GetComponent<CanvasGroup>();

            successOpenLvl1 = GameObject
                .FindGameObjectWithTag("Level1Success")
                .GetComponent<SuccesOpen1Lvl>();

        }

        private void Start() {

            errorMsg.SetActive(false);
            Hide();

        }

        public void UseCode() {

            var userData = SceneData.GetUserData();

            if (inputField.text == "level1") {

                userData.isAccessEasyLevel = true;
                Hide();
                successOpenLvl1.Show();

            } else {
                errorMsg.SetActive(true);
            }

        }

        public void Hide() {

            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0;

        }

        public void Show() {

            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1;

        }

    }

}
