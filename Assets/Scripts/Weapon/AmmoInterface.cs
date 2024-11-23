using UnityEngine;

namespace Weapon
{
    public interface IAmmo
    {
        void OnShoot(); // Define comportamiento al disparar
        void OnHit();   // Define comportamiento al impactar
    }

// Implementaciones concretas
    public class FireAmmo : MonoBehaviour, IAmmo
    {
        public void OnShoot()
        {
            Debug.Log("Fire ammo shot with burning effect!");
        }

        public void OnHit()
        {
            Debug.Log("Fire ammo hit and burned the target!");
        }
    }

    public class NatureAmmo : MonoBehaviour, IAmmo
    {
        public void OnShoot()
        {
            Debug.Log("Wood ammo shot with splintering effect!");
        }

        public void OnHit()
        {
            Debug.Log("Wood ammo hit and caused knockback!");
        }
    }

    public class WaterAmmo : MonoBehaviour, IAmmo
    {
        public void OnShoot()
        {
            Debug.Log("Leaf ammo shot with slowing effect!");
        }

        public void OnHit()
        {
            Debug.Log("Leaf ammo hit and slowed the target!");
        }
    }
}