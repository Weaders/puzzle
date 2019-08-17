using UnityEngine;
using UnityEngine.Events;

namespace Game.User {

    public class UserChange : UnityEvent<UserData> { }

    public class UserData {

        private const string IS_EASY_ACCESS_CODE = "is_easy_access";

        private const string IS_HARD_ACCESS_CODE = "is_hard_access";

        private bool _isAccessEasyLvl = false;
        private bool _isAccessHardLvl = false;

        public UserData() {

            if (PlayerPrefs.HasKey(IS_EASY_ACCESS_CODE)) {
                _isAccessEasyLvl = PlayerPrefs.GetInt(IS_EASY_ACCESS_CODE) == 1;
            }

            if (PlayerPrefs.HasKey(IS_HARD_ACCESS_CODE)) {
                _isAccessHardLvl = PlayerPrefs.GetInt(IS_HARD_ACCESS_CODE) == 1;
            }

            Debug.Log("User init");
            Debug.Log($"User easy access - {_isAccessEasyLvl}");
            Debug.Log($"User hard access - {_isAccessHardLvl}");

        }

        public bool isAccessEasyLevel {
            get {
                return _isAccessEasyLvl;
            }
            set {

                _isAccessEasyLvl = value;
                PlayerPrefs.SetInt(IS_EASY_ACCESS_CODE, value ? 1 : 0);
                onChange.Invoke(this);

            }
        }

        public bool isAccessHardLevel {
            get {
                return _isAccessHardLvl;
            }
            set {

                _isAccessHardLvl = value;
                PlayerPrefs.SetInt(IS_HARD_ACCESS_CODE, value ? 1 : 0);
                onChange.Invoke(this);

            }
        }

        public UnityEvent<UserData> onChange = new UserChange();

    }

}