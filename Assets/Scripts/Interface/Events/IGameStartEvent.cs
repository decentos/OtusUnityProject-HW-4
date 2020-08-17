namespace MVCExample
{
    namespace Events
    {
        public delegate void GameStartEventHandler();

        public interface IGameStartEvent
        {       
            event GameStartEventHandler GameStarted;    
        }
    }
}