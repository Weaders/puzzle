using Assets.Scripts.Menu;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Menu {
    public class BGMainMenu : MonoBehaviour, IPointerClickHandler {

        private BuyAccessPopup buyAccessPopup;
        private PromocodePopup promocodePopup;
        private SuccesOpen1Lvl succesOpen1Lvl;
        private HelpPopup helpPopup;

        void Awake() {

            buyAccessPopup = GameObject
                .FindGameObjectWithTag("BuyAccess")
                .GetComponent<BuyAccessPopup>();

            promocodePopup = GameObject
                .FindGameObjectWithTag("Promocode")
                .GetComponent<PromocodePopup>();

            succesOpen1Lvl = GameObject
                .FindGameObjectWithTag("Level1Success")
                .GetComponent<SuccesOpen1Lvl>();

            helpPopup = GameObject
                .FindGameObjectWithTag("HelpPopup")
                .GetComponent<HelpPopup>();

        }

        public void OnPointerClick(PointerEventData eventData) {

            buyAccessPopup.Hide();
            promocodePopup.Hide();
            succesOpen1Lvl.Hide();
            helpPopup.Hide();

        }

    }
}
