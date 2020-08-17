using UnityEngine;

namespace MVCExample
{
    public class BulletFactory : IBulletFactory
    {
        public IBullet CreateBullet(BulletsSettings settings, BulletsType type, Transform bulletsPlaceHolder)
        {
            var bulletProvider = settings.GetBullet(type);
            return Object.Instantiate( bulletProvider, Vector3.zero, Quaternion.identity, bulletsPlaceHolder);
        }
    }
}