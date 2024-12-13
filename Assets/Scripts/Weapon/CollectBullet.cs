using UnityEngine;

namespace Weapon
{
    public class CollectBullet : MonoBehaviour
    {
        [SerializeField] private float maxCollectDistance = 2f;
        private ChamberRotation _chamberRotation;
        private Sfx _sfx;
        public AudioClip clip;

        private void Start()
        {
            _sfx = GameObject.FindGameObjectWithTag("AudioSFX").GetComponent<Sfx>();
            _chamberRotation = gameObject.GetComponent<ChamberRotation>();
        }

        public void CollectBulletFunction()
        {
            if (Physics.Raycast(transform.parent.GetChild(0).transform.position, transform.parent.GetChild(0).transform.forward /* Getting Camera forward*/, out RaycastHit hit, maxCollectDistance))
            {
                if (hit.transform.CompareTag("Bullet"))
                {
                    _sfx.playSfx(clip);
                    hit.transform.GetComponent<Collider>().enabled = false;
                    ExchangeBulletFunction(hit.transform.gameObject);
                }
            }
        }

        private void ExchangeBulletFunction(GameObject newBullet)
        {
            Destroy(_chamberRotation.chambers[0]);

            // Limpia el nombre de la bala
            string ammoType = newBullet.name.Replace("Ammo", "").Split('(')[0].Trim();

            // Crea la bala usando la fábrica abstracta
            GameObject ammoInstance = AmmoAbstractFactory.CreateAmmo(ammoType, _chamberRotation.chambersTransform[0]);
            if (ammoInstance != null)
            {
                _chamberRotation.chambers[0] = ammoInstance;
            }
            else
            {
                Debug.LogError($"Failed to create ammo of type: {ammoType}");
            }
        }
    }
}


