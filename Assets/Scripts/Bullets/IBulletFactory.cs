using UnityEngine;

namespace MVCExample
{
    public interface IBulletFactory
    {
        IBullet CreateBullet(BulletsSettings settings, BulletsType type, Transform bulletsPlaceHolder);
    }
}