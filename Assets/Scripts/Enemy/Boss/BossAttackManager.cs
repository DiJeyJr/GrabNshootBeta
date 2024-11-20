using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackManager : MonoBehaviour
{
    [SerializeField] GameObject barrier;
    
    [SerializeField] GameObject[] Attacks;
    private bool startBossFight = false;
    private bool executingSequence = false;
    
    private Sfx _sfx;
    public AudioClip[] clip;

    private void Start()
    {
        _sfx = GameObject.FindGameObjectWithTag("AudioSFX").GetComponent<Sfx>();
    }
    
    private void Update()
    {
        if (startBossFight && !executingSequence)
        {
            StartCoroutine(AttackSquence());
        }
    }

    private bool isAtacking = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            barrier.SetActive(true);
            startBossFight = true;
            _sfx.playSfx(clip[3]);
        }
        
    }

    IEnumerator AttackSquence()
    {
        executingSequence = true;
        yield return new WaitForSeconds(5f);
        StartCoroutine(Explosion());
        yield return new WaitForSeconds(5f);
        StartCoroutine(Tiles());
        yield return new WaitForSeconds(5f);
        StartCoroutine(Explosion());
        yield return new WaitForSeconds(5f);
        StartCoroutine(Bombs());
        executingSequence = false;
    }

    IEnumerator Explosion()
    {
        Attacks[0].transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Attacks[0].transform.GetChild(0).gameObject.SetActive(false);
        _sfx.playSfx(clip[0]);
        Attacks[0].transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Attacks[0].transform.GetChild(1).gameObject.SetActive(false);
    }
    
    IEnumerator Tiles()
    {
        Attacks[1].transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Attacks[1].transform.GetChild(0).gameObject.SetActive(false);
        _sfx.playSfx(clip[1]);
        Attacks[1].transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Attacks[1].transform.GetChild(1).gameObject.SetActive(false);
    }
    
    IEnumerator Bombs()
    {
        Attacks[2].transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Attacks[2].transform.GetChild(0).gameObject.SetActive(false);
        _sfx.playSfx(clip[2]);
        Attacks[2].transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Attacks[2].transform.GetChild(1).gameObject.SetActive(false);
    }
}
