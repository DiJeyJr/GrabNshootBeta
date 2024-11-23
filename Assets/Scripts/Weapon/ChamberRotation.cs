using UnityEngine;

namespace Weapon
{
    public class ChamberRotation : MonoBehaviour
    {
        public GameObject[] chambers;
        [SerializeField] public Transform[] chambersTransform;

    
        private Sfx _sfx;
        public AudioClip clip;
    
        private void Start()
        {
            _sfx = GameObject.FindGameObjectWithTag("AudioSFX").GetComponent<Sfx>();
        }

    
        public void RotateChamber()
        {
            GameObject tempSaveChamberBullet = chambers[0];
            _sfx.playSfx(clip);
            chambers[0] = chambers[1];
            chambers[1] = chambers[2];
            chambers[2] = tempSaveChamberBullet;
        }

        public void BulletInChamberPositionUpdate()
        {
            for (int i = 0; i < chambers.Length; i++)
            {
                if (chambers[i] != null)
                {
                    chambers[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    chambers[i].transform.SetParent(chambersTransform[i]);
                    chambers[i].transform.position = chambersTransform[i].position;
                }
            }
        }
    }
}
