namespace Game.Common {

    public enum GameState {
        Menu, Game
    }

    public interface IGameState {

    }

    public class MenuState : IGameState {

    }
    
    public class InGameState : IGameState {

        public int lvlIndex { get; set; }

    }

    public static class GameData {

        public static GameState stateType;

        public static IGameState stateData;

    }
}
