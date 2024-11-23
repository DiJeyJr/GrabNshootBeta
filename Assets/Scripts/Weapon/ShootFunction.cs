using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;

public class ShootFunction : MonoBehaviour
{
    [SerializeField] private float shootForce;
    [SerializeField] private Transform shootPivot;
    
    //Overheat
    [SerializeField] private float overheatMaxTime;
    [SerializeField] private float cooldownTime;
    private float overheatTimer;
    private float overheatValue;
    private bool isOverheat;

    //State
    private bool shoot;
    private bool shooting = false;
    private bool isCooling;

    private GameObject activeBullet;

    private Sfx _sfx;
    public AudioClip[] clip;

    private void Start()
    {
        _sfx = GameObject.FindGameObjectWithTag("AudioSFX").GetComponent<Sfx>();
    }

    private void Update()
    {
        //check for shoot
        if (shoot && !shooting && !isOverheat)
        {
            //Shooting
            StartCoroutine(HandleFirerate(activeBullet));
        }
        else if (!shoot && overheatTimer > 0 || isOverheat)
        {
            //Cooling down weapon
            overheatTimer -= Time.deltaTime * (overheatMaxTime / cooldownTime);
            if (overheatTimer <0)
                overheatTimer = 0;
        }

        if (overheatTimer >= overheatMaxTime)
        {
            isOverheat = true;
            _sfx.playSfx(clip[1]);
            overheatTimer = overheatMaxTime-0.0001f; //-0.0001f Reference number to avoid reproducing audio twice
        }
        
        if (overheatTimer <= 0)
            isOverheat = false;
    }

    public void Shoot(GameObject bullet)
    {
        shoot = true;
        activeBullet = bullet;
    }

    public void CoolDown()
    {
        shoot = false;
    }
    
    private void instantiateBullet(GameObject bullet)
    {
        if (bullet == null)
        {
            Debug.LogError("La bala es nula, no se puede instanciar.");
            return;
        }

        // Crear la bala usando la fábrica
        string bulletType = bullet.name.Replace("Ammo", "").Split('(')[0].Trim();; // Obtener el tipo de bala sin "(Clone)"
        GameObject instantiatedBullet = AmmoFactory.CreateAmmo(bulletType, bullet.transform);

        if (instantiatedBullet != null)
        {
            // Configurar propiedades de la bala después de ser creada
            instantiatedBullet.transform.position = shootPivot.position;
            instantiatedBullet.transform.rotation = bullet.transform.rotation;

            Rigidbody rb = instantiatedBullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false; // Permitir físicas para que la bala sea disparada
                rb.AddForce(GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform.forward * shootForce, ForceMode.Impulse); // Aplicar fuerza
            }
        }
        else
        {
            Debug.LogError($"No se pudo crear la bala de tipo: {bulletType}");
        }
    }

    
    /*
    private void instantiateBullet(GameObject bullet)
    {
        if (bullet != null)
        {
            GameObject bulletInstance = Instantiate(bullet, shootPivot.position, Quaternion.identity, null);
            bulletInstance.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            bulletInstance.GetComponent<Collider>().enabled = true;
            bulletInstance.GetComponent<Rigidbody>().useGravity = false;
            bulletInstance.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            bulletInstance.GetComponent<Rigidbody>().AddForce(GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform.forward * shootForce, ForceMode.Impulse);
            Destroy(bulletInstance, 4);
        }
    }*/
    
    private float CalculateRPM(float t)
    {
        // Exponential function: RPM(t) to ms = 1 / (a * Mathf.Exp(b * t)) + c / 60s (1 minute)
        return 1/ ((350f * Mathf.Exp(-0.0002f * t) + 150f) / 60);
    }

    IEnumerator HandleFirerate(GameObject bullet)
    {
        if (bullet != null)
        {
            shooting = true;
            instantiateBullet(bullet);
            _sfx.playSfx(clip[0]);
            float timeToFire = CalculateRPM(overheatTimer * 1000 /* make seconds miliseconds*/);
            overheatTimer += Time.deltaTime + timeToFire;
            yield return new WaitForSeconds(timeToFire);
            shooting = false;
        }
        
    }

    public float GetOverheatPercentage()
    {
        return overheatTimer / overheatMaxTime;
    }
}
