using UnityEngine;

namespace Weapon
{
    public interface IAmmo
    {
        void OnShoot();
        void OnHit();
    }
    
    public class FireAmmo : MonoBehaviour, IAmmo
    {
        public void OnShoot()
        {
            
        }

        public void OnHit()
        {
            
        }
    }

    public class NatureAmmo : MonoBehaviour, IAmmo
    {
        public void OnShoot()
        {
            
        }

        public void OnHit()
        {
            
        }
    }

    public class WaterAmmo : MonoBehaviour, IAmmo
    {
        public void OnShoot()
        {
            
        }

        public void OnHit()
        {
            
        }
    }
}