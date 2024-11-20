using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBullet : MonoBehaviour
{
    [SerializeField] private float maxCollectDistance = 2f;
    private ChamberRotation chamberRotation;
    private Sfx _sfx;
    public AudioClip clip;

    private void Start()
    {
        _sfx = GameObject.FindGameObjectWithTag("AudioSFX").GetComponent<Sfx>();
        chamberRotation = gameObject.GetComponent<ChamberRotation>();
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
        Destroy(chamberRotation.chambers[0]);
        chamberRotation.chambers[0] = newBullet;
    }
}
