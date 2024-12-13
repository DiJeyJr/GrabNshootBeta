using UnityEngine;
using System.Collections.Generic;

namespace Weapon
{
    public class AmmoAbstractFactory : MonoBehaviour
    {
        private static Dictionary<string, IAmmoFactory> ammoFactories = new Dictionary<string, IAmmoFactory>();

        public static void RegisterAmmoFactory(string ammoType, IAmmoFactory factory)
        {
            if (!ammoFactories.ContainsKey(ammoType))
            {
                ammoFactories.Add(ammoType, factory);
            }
        }

        public static GameObject CreateAmmo(string ammoType, Transform spawnPoint)
        {
            if (ammoFactories.TryGetValue(ammoType, out IAmmoFactory factory))
            {
                return factory.CreateAmmo(spawnPoint);
            }
            else
            {
                Debug.LogError($"Ammo type '{ammoType}' not recognized!");
                return null;
            }
        }
    }
}