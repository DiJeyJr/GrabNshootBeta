using UnityEngine;

namespace Weapon
{
    public class NatureAmmoFactory : IAmmoFactory
    {
        private GameObject prefab;

        public NatureAmmoFactory(GameObject prefab)
        {
            this.prefab = prefab;
        }

        public GameObject CreateAmmo(Transform spawnPoint)
        {
            return GameObject.Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}