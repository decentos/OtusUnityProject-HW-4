using UnityEngine;

namespace MVCExample
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        public IEnemy CreateEnemy(EnemyData data, EnemyType type, Transform placeHolder)
        {
            var enemyProvider = data.GetEnemy(type);
            return Object.Instantiate( enemyProvider, Vector3.zero, Quaternion.identity, placeHolder);
        }
    }
}
