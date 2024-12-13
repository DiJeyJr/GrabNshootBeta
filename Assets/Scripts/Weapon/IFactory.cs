using UnityEngine;

namespace Weapon
{
    public interface IAmmo
    {
        void OnShoot();
        void OnHit();
    }

    public interface IAmmoFactory
    {
        GameObject CreateAmmo(Transform spawnPoint);
    }
}