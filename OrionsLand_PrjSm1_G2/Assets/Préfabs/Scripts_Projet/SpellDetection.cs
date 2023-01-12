using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDetection : MonoBehaviour
{
    [Header("Scripts Externes")]
    public Ressources Ressources;

    [Space(10)]
    [Header("Position GameObject")]
    public Transform propPosition;
    public Transform respawnPosition;

    [Space(10)]
    [Header("Particle")]
    public GameObject particleFire;
    public GameObject particleWater;
    public GameObject particleWind;
    public GameObject props;

    [Space(10)]
    [Header("Les FX")]
    public ParticleSystem fireParticle;
    public ParticleSystem waterParticle;
    public ParticleSystem windParticle;

    [Space(10)]
    [Header("Les Timeurs")]
    public float lifetimeFire = 5f;
    public float lifetimeWater = 30f;
    public float lifetimeWind = 0.5f;
    public float respawnProps = 15f;

    [Space(10)]
    public float currentRespawnProps;
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
        currentRespawnProps = respawnProps;
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

        if (currentFireLifetime < 0 || currentWaterLifetime < 0 || currentWindLifetime < 0 )
        {
            fireShoot = false;
            activation = false;
            timerRespawn = true;
            currentFireLifetime = lifetimeFire;
            currentWaterLifetime = lifetimeWater;
            currentWindLifetime = lifetimeWind;
        }

        if(timerRespawn == true)
        {
            currentRespawnProps -= 1 * Time.deltaTime;
        }

        if (currentRespawnProps < 0)
        {
            timerRespawn = false;
            activation = true;
            currentRespawnProps = respawnProps;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "SpellFeu")
        {
            fireParticle.Play(true);
            fireShoot = true;
        }

        else if (collision.gameObject.tag == "SpellEau")
        {
            waterParticle.Play(true);
            Destroy(gameObject, lifetimeWater);
            waterShoot = true;
        }

        else if (collision.gameObject.tag == "SpellVent")
        {
            windParticle.Play(true);
            Destroy(gameObject, lifetimeWind);
            windShoot = true;

        }
    }
}
