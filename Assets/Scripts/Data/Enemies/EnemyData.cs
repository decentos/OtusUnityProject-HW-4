using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MVCExample
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "Data/Unit/EnemySettings")]
    public sealed class EnemyData : ScriptableObject
    {
        [Serializable] 
        private struct EnemyInfo
        {
            public EnemyType Type;
            public EnemyProvider EnemyPrefab;
        }

        [SerializeField] private List<EnemyInfo> _enemyInfo;
        [SerializeField] private float _enemySpawnIntervalTime;
        public float SpawnIntervalTime => _enemySpawnIntervalTime;
        [SerializeField] private int _maxEnemiesInPool;
        public int MaxEnemiesInPool => _maxEnemiesInPool;

        public EnemyProvider GetEnemy(EnemyType type)
        {
            var enemyInfo = _enemyInfo.First(info => info.Type == type);
            return enemyInfo.EnemyPrefab;
        }
    }
}