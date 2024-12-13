using UnityEngine;
using System.Collections.Generic;

namespace Weapon
{
    public class AmmoFactory : MonoBehaviour
    {
        private static Dictionary<string, GameObject> ammoPrefabs = new Dictionary<string, GameObject>();

        public static void RegisterAmmoPrefab(string ammoType, GameObject prefab)
        {
            if (!ammoPrefabs.ContainsKey(ammoType))
            {
                ammoPrefabs.Add(ammoType, prefab);
            }
        }

        public static GameObject CreateAmmo(string ammoType, Transform spawnPoint)
        {
            if (ammoPrefabs.TryGetValue(ammoType, out GameObject ammoPrefab))
            {
                GameObject ammoInstance = GameObject.Instantiate(ammoPrefab, spawnPoint.position, spawnPoint.rotation);
                return ammoInstance;
            }
            else
            {
                Debug.LogError($"Ammo type '{ammoType}' not recognized!");
                return null;
            }
        }
    }
}