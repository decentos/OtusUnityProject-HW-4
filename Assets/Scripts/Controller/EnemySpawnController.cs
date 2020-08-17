using MVCExample.Events;
using UnityEngine;

namespace MVCExample
{
    public sealed class EnemySpawnController : IInitialization, ICleanup, IExecute
    {
        private readonly CompositeMove _enemiesMove;
        private readonly IEnemyFactory _enemyFactory;
        private readonly Transform _enemiesPlaceHolder;
        private readonly EnemyData _data;
        private readonly IEnemySpawnEvent _enemySpawnEventHandler;

        private readonly EnemyProvider[] _enemiesPool;
        private int _enemyIndex = 0;

        private Vector3 _newEnemyPosition;
        
        public EnemySpawnController(CompositeMove enemies, 
                                    IEnemyFactory enemyFactory, 
                                    EnemyData data,
                                    Transform enemiesPlaceHolder,
                                    IEnemySpawnEvent enemySpawnEventHandler)
        {
            _enemiesMove = enemies;
            _data = data;
            _enemiesPlaceHolder = enemiesPlaceHolder;
            _enemyFactory = enemyFactory;
            _enemySpawnEventHandler = enemySpawnEventHandler;

            _enemiesPool = new EnemyProvider[_data.MaxEnemiesInPool];
        }
        
        private void SpawnEnemy()
        {
            _newEnemyPosition.x = Random.Range(-10.0f, 10.0f);
            _newEnemyPosition.y = Random.Range(-10.0f, 10.0f);

            var enemie = _enemiesPool[_enemyIndex];
            enemie.transform.position = _newEnemyPosition;
            enemie.gameObject.SetActive(true);
            
            _enemiesMove.AddUnit(enemie);
            
            ++_enemyIndex;
            _enemyIndex %= _enemiesPool.Length;
        }
        
        public void Initialization()
        {
            for (int i = 0; i < _data.MaxEnemiesInPool; i++)
            {
                var enemie = _enemyFactory.CreateEnemy(_data, EnemyType.Small, _enemiesPlaceHolder) as EnemyProvider;
                enemie.SerializeGameData(_enemiesMove);
                enemie.gameObject.SetActive(false);
                _enemiesPool[i] = enemie;            
            }

            _enemySpawnEventHandler.EnemySpawned += SpawnEnemy;
        }

        public void Cleanup()
        {
            _enemySpawnEventHandler.EnemySpawned -= SpawnEnemy;
        }

        public void Execute(float deltaTime)
        {
        }
    }
}