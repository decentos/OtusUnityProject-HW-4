using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MVCExample
{
    [CreateAssetMenu(fileName = "BulletsSettings", menuName = "Data/Unit/BulletsSettings")]
    public class BulletsSettings : ScriptableObject
    {
        [Serializable]
        private struct BulletInfo
        {
            public BulletsType Type;
            public BulletProvider BulletPrefab;
        }

        [SerializeField] private List<BulletInfo> _bulletInfo;

        [SerializeField] private int _maxBulletsInPool;
        public int MaxBulletsInPool => _maxBulletsInPool;
        
        public BulletProvider GetBullet(BulletsType type)
        {
            var bulletInfo = _bulletInfo.First(info => info.Type == type);
            return bulletInfo.BulletPrefab;
        }
    }
}