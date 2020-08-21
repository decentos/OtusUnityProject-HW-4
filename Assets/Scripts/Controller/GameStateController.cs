using System;

namespace MVCExample
{
    public sealed class GameStateController
    {
        public Action openMenu = delegate () { };
        public Action gameStart = delegate () { };
        public Action gameOver = delegate () { };

        private GameStates _gameState;
        public GameStates GameState => _gameState;
        public void SetState(GameStates state)
        {
            switch (state)
            {
                case GameStates.GameInMenu:
                    _gameState = state;
                    openMenu();
                    break;
                case GameStates.GameStart:
                    _gameState = state;
                    gameStart();
                    break;
                case GameStates.GameOver:
                    _gameState = state;
                    gameOver();
                    break;
                case GameStates.None:
                    break;
                case GameStates.Count:
                    break;
                default:
                    break;
            }
        }
    }
}