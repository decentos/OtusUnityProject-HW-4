using System.Collections.Generic;
using MVCExample.Events;
using UnityEngine;

namespace MVCExample
{
    public sealed class Controllers : IInitialization, ICleanup
    {
        private readonly IExecute[] _executeControllers;

        public int Length => _executeControllers.Length;

        public IExecute this[int index] => _executeControllers[index];

        public Controllers(Data data, IEnemySpawnEvent enemySpawnHandler, IGameStartEvent gameStartEventHandler, IGameOverEvent gameOverEventHandler)
        {
            var pcInputHorizontal = new PCInputHorizontal();
            var pcInputVertical = new PCInputVertical();
            var pcInputFire = new PCInputFire();
            
            IPlayerFactory playerFactory = new PlayerFactory(data.Player);
            var player = playerFactory.CreatePlayer();

            var enemiesPlaceHolder = new GameObject("enemiesPlaceHolder").transform;
            var bulletsPlaceHolder = new GameObject("bulletsPlaceHolder").transform;
            bulletsPlaceHolder.parent = enemiesPlaceHolder;
            
            Object.Instantiate(data.Enviroment.spaceParticle, enemiesPlaceHolder.transform);

            var enemies = new CompositeMove();
            var enemyFactory = new EnemyFactory();
            var bulletFactory = new BulletFactory();

            var controllers = new List<IExecute>
            {
                new InputController(pcInputHorizontal, pcInputVertical, pcInputFire),
                new MoveController(pcInputHorizontal, pcInputVertical, enemiesPlaceHolder, data.Player),
                new EnemyMoveController(enemies, player),
                new ShootController(pcInputFire, bulletFactory, data.Bullets, bulletsPlaceHolder),
                new EnemySpawnController(enemies, enemyFactory, data.Enemy, enemiesPlaceHolder, enemySpawnHandler),
            };

            _executeControllers = controllers.ToArray();
        }

        public void Initialization()
        {
            foreach (var controller in _executeControllers)
            {
                (controller as IInitialization)?.Initialization();
            }
        }

        public void Cleanup()
        {
            foreach (var controller in _executeControllers)
            {
                (controller as ICleanup)?.Cleanup();
            }
        }
    }
}