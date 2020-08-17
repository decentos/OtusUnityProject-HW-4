namespace MVCExample
{
    namespace Events
    {
        public delegate void EnemySpawnEventHandler();

        public interface IEnemySpawnEvent
        {       
            event EnemySpawnEventHandler EnemySpawned;    
        }
    }
}