namespace MVCExample
{
    namespace Events
    {
        public delegate void GameOverEventHandler();

        public interface IGameOverEvent
        {       
            event GameOverEventHandler GameOver;    
        }
    }
}