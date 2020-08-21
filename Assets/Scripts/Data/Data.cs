using System.IO;
using UnityEngine;

namespace MVCExample
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _enemyDataPath;
        [SerializeField] private string _enviromentDataPath;
        [SerializeField] private string _bulletsDataPath;

        private PlayerData _player;
        private EnemyData _enemy;
        private EnviromentData _enviroment;
        private BulletsSettings _bullets;

        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>($"Data/{_playerDataPath}");
                }

                return _player;
            }
        }

        public EnemyData Enemy
        {
            get
            {
                if (_enemy == null)
                {
                    _enemy = Load<EnemyData>($"Data/{_enemyDataPath}");
                }

                return _enemy;
            }
        }

        public EnviromentData Enviroment
        {
            get
            {
                if (_enviroment == null)
                {
                    _enviroment = Load<EnviromentData>($"Data/{_enviromentDataPath}");
                }

                return _enviroment;
            }
        }

        public BulletsSettings Bullets
        {
            get
            {
                if (_bullets == null)
                {
                    _bullets = Load<BulletsSettings>($"Data/{_bulletsDataPath}");
                }

                return _bullets;
            }
        }

        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}