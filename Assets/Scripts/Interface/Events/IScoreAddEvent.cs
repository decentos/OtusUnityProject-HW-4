namespace MVCExample
{
    namespace Events
    {
        public delegate void ScoreAddEventHandler();

        public interface IScoreAddEvent
        {       
            event ScoreAddEventHandler ScoreAdded;
        }
    }
}