using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDetection : MonoBehaviour
{
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
    [Header("Les Timeurs")]
    public float lifetimeRemainingFire = 5f;
    public float lifetimeRemainingWater = 30f;
    public float lifetimeRemainingWind = 0.5f;
    public float respawnProps = 15f;
    public float currentRespawnProps;

    [Space(10)]
    [Header("Variables")]
    public bool activation;
    public bool fireShoot;
    public bool waterShoot;
    public bool windShoot;
    
    void Awake()
    {
        activation = false;
        currentRespawnProps = respawnProps;
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
            lifetimeRemainingFire -= 1 * Time.deltaTime;
        }

        if (lifetimeRemainingFire < 0 || lifetimeRemainingWater < 0 || lifetimeRemainingWind < 0 )
        {
            activation = false;
            currentRespawnProps -= 1 * Time.deltaTime;
        }

        if (currentRespawnProps < 0)
        {
            activation = true;
            currentRespawnProps = respawnProps;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "SpellFeu")
        {
            GameObject particle = Instantiate(particleFire, propPosition.position, propPosition.rotation);
            fireShoot = true;
        }

        else if (collision.gameObject.tag == "SpellEau")
        {
            GameObject particle = Instantiate(particleWater, propPosition.position, propPosition.rotation);
            Destroy(gameObject, lifetimeRemainingWater);
            waterShoot = true;
        }

        else if (collision.gameObject.tag == "SpellVent")
        {
            GameObject particle = Instantiate(particleWind, propPosition.position, propPosition.rotation);
            Destroy(gameObject, lifetimeRemainingWind);
            windShoot = true;

        }
    }
}
