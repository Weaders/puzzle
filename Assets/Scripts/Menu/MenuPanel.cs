using UnityEngine;

namespace Game.Menu {

    public enum MenuPanelType {
        Start, Category, Levels
    }

    public class MenuPanel : MonoBehaviour {

        [SerializeField]
        public MenuPanelType panelType;


    }

}
