using UnityEngine;

namespace MVCExample
{
    public interface IEnemyFactory
    {
        IEnemy CreateEnemy(EnemyData data, EnemyType type, Transform placeHolder);
    }
}
