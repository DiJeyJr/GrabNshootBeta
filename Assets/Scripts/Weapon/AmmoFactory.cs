using UnityEngine;
using UnityEngine.Serialization;

namespace Weapon
{
    public class AmmoFactory : MonoBehaviour
    {
        public static GameObject CreateAmmo(string ammoType, Transform spawnPoint)
        {
            GameObject ammoPrefab = null;

            switch (ammoType)
            {
                case "Nature":
                    ammoPrefab = Resources.Load<GameObject>("Prefabs/NatureAmmo");
                    break;
                case "Fire":
                    ammoPrefab = Resources.Load<GameObject>("Prefabs/FireAmmo");
                    break;
                case "Water":
                    ammoPrefab = Resources.Load<GameObject>("Prefabs/WaterAmmo");
                    break;
                default:
                    Debug.LogError($"Ammo type '{ammoType}' not recognized!");
                    break;
            }

            if (ammoPrefab != null)
            {
                GameObject ammoInstance = GameObject.Instantiate(ammoPrefab, spawnPoint.position, spawnPoint.rotation);
                return ammoInstance;
            }

            return null;
        }
    }
}
