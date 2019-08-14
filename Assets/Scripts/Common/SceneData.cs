using Game.User;

namespace Game.Common {
    public static class SceneData {

        private static UserData _userData;

        public static UserData GetUserData() {

            if (_userData == null) {
                _userData = new UserData();
            }

            return _userData;

        }

        public static void Clear() { }

    }
}
