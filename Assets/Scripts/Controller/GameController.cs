using System;
using System.Collections;
using MVCExample.Events;
using UnityEngine;

namespace MVCExample
{
    public sealed class GameController : MonoBehaviour, IEnemySpawnEvent, IGameStartEvent, IGameOverEvent
    {
        [SerializeField] private Data _data;
        private Controllers _controllers;
        
        public event EnemySpawnEventHandler EnemySpawned = delegate { };
        
        public event GameStartEventHandler GameStarted = delegate { };
        
        public event GameOverEventHandler GameOver = delegate { };

        private void Start()
        {
            _controllers = new Controllers(_data, this, this, this);
            _controllers.Initialization();
            StartCoroutine(SpawnEnemy(_data.Enemy.SpawnIntervalTime));
        }

        private void OnDisable()
        {
            _controllers.Cleanup();
        }

        private void Update()
        {
            // gameObject.SetActive(true);
            var deltaTime = Time.deltaTime;
            for (var i = 0; i < _controllers.Length; i++)
            {
                _controllers[i].Execute(deltaTime);
            }
        }

        private IEnumerator SpawnEnemy(float intervalTime)
        {
            while (true)
            {
                yield return new WaitForSeconds(intervalTime);
                EnemySpawned();
            }
        }
    }
}
