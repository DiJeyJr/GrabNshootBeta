using UnityEngine;

namespace Weapon
{
    public class WaterAmmoFactory : IAmmoFactory
    {
        private GameObject prefab;

        public WaterAmmoFactory(GameObject prefab)
        {
            this.prefab = prefab;
        }

        public GameObject CreateAmmo(Transform spawnPoint)
        {
            return GameObject.Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}