using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SpellDetection : MonoBehaviour
{
    [Header("Props a désactiver")]

    public GameObject props;

    [Space(10)]
    [Header("Les FX")]
    public VisualEffect VFxFire;
    public ParticleSystem waterParticle;
    public ParticleSystem windParticle;

    [Space(10)]
    [Header("Les Timeurs")]
    public float lifetimeFire = 5f;
    public float lifetimeWater = 5f;
    public float lifetimeWind = 0.5f;

    [Space(10)]
    public float currentFireLifetime;
    public float currentWaterLifetime;
    public float currentWindLifetime;

    [Space(10)]
    [Header("Variables")]
    public bool activation;
    public bool fireShoot;
    public bool waterShoot;
    public bool windShoot;
    public bool timerRespawn;
    
    void Awake()
    {
        timerRespawn = false;
        activation = true;
        currentFireLifetime = lifetimeFire;
        currentWaterLifetime = lifetimeWater;
        currentWindLifetime = lifetimeWind;
    }

    private void FixedUpdate()
    {
        if (activation == true)
        {
            props.SetActive(true);
        }
        else 
        {
            props.SetActive(false);
        }

        if (fireShoot == true)
        {
            currentFireLifetime -= 1 * Time.deltaTime;
        }        
        if (waterShoot == true)
        {
            currentWaterLifetime -= 1 * Time.deltaTime;
        }        
        if (windShoot == true)
        {
            currentWindLifetime -= 1 * Time.deltaTime;
        }

        if (currentFireLifetime < 0 || currentWaterLifetime < 0 || currentWindLifetime < 0 )
        {
            fireShoot = false;
            waterShoot = false;
            windShoot = false;

            activation = false;
            timerRespawn = true;

            currentFireLifetime = lifetimeFire;
            currentWaterLifetime = lifetimeWater;
            currentWindLifetime = lifetimeWind;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "SpellFeu")
        {
            VFxFire.Play();
            fireShoot = true;
        }

        else if (collision.gameObject.tag == "SpellEau")
        {
            waterParticle.Play(true);
            waterShoot = true;
        }

        else if (collision.gameObject.tag == "SpellVent")
        {
            windParticle.Play(true);
            windShoot = true;

        }
    }
}
