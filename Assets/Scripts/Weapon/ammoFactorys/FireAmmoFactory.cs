using UnityEngine;

namespace Weapon
{
    public class FireAmmoFactory : IAmmoFactory
    {
        private GameObject prefab;

        public FireAmmoFactory(GameObject prefab)
        {
            this.prefab = prefab;
        }

        public GameObject CreateAmmo(Transform spawnPoint)
        {
            return GameObject.Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}