using System.Collections.Generic;
using UnityEngine;

namespace MVCExample
{
    public sealed class ShootController : IExecute, ICleanup, IInitialization
    {
        private bool _isFire;
        private BulletsType _generatedBulletsType;

        private readonly IUserInputProxy<bool> _fireInputProxy;
        private readonly IBulletFactory _bulletFactory;
        private readonly BulletsSettings _bulletsSettings;
        private readonly Transform _bulletsPlaceHolder;
        
        private readonly BulletProvider[] _bulletsPool;
        private int _bulletIndex = 0;
        
        public ShootController(IUserInputProxy<bool> fireInputProxy, IBulletFactory bulletFactory,
            BulletsSettings bulletsSettings,Transform bulletsPlaceHolder)
        {
            _fireInputProxy = fireInputProxy;
            _bulletFactory = bulletFactory;
            _bulletsSettings = bulletsSettings;
            _generatedBulletsType = BulletsType.Single;
            _bulletsPlaceHolder = bulletsPlaceHolder;
            
            _bulletsPool = new BulletProvider[_bulletsSettings.MaxBulletsInPool];
            
            _fireInputProxy.AxisOnChange += FireOnAxisOnChange;
        }

        void FireOnAxisOnChange(bool isFire)
        {
            _isFire = isFire;
        }

        public void Execute(float deltaTime)
        {
            if (_isFire)
            {
                Debug.Log("Fire");
                Shoot();
            }

            foreach (var bullet in _bulletsPool)
            {
                if(bullet.isActiveAndEnabled)
                    bullet.Move(Vector3.zero);
            }
        }

        public void Cleanup()
        {
            _fireInputProxy.AxisOnChange -= FireOnAxisOnChange;
        }

        public void Initialization()
        {
            for (int i = 0; i < _bulletsSettings.MaxBulletsInPool; i++)
            {
                var bullet = _bulletFactory.CreateBullet(_bulletsSettings, _generatedBulletsType, _bulletsPlaceHolder) as BulletProvider;
                bullet.gameObject.SetActive(false);
                _bulletsPool[i] = bullet;
            }
        }

        private void OnWeaponChange(BulletsType type)
        {
            _generatedBulletsType = type;
            Initialization();
        }

        private void Shoot()
        {
            _bulletsPool[_bulletIndex].Pull();
            ++_bulletIndex;
            _bulletIndex %= _bulletsPool.Length;
        }
    }
}