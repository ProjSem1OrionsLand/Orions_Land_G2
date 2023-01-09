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

    [Space(10)]
    [Header("Les Timeurs")]
    public float lifetimeRemaining = 5f;


    [Space(10)]
    [Header("Variables")]
    public bool shoot;
    void Awake()
    {
        shoot = false;

    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "SpellFeu")
        {
            GameObject particle = Instantiate(particleFire, propPosition.position, propPosition.rotation);
            Destroy(gameObject, lifetimeRemaining);
            shoot = true;
        }

        else if (collision.gameObject.tag == "SpellEau")
        {
            GameObject particle = Instantiate(particleWater, propPosition.position, propPosition.rotation);
            Destroy(gameObject, lifetimeRemaining);
            shoot = true;

        }

        else if (collision.gameObject.tag == "SpellVent")
        {
            GameObject particle = Instantiate(particleWind, propPosition.position, propPosition.rotation);
            Destroy(gameObject, lifetimeRemaining);
            shoot = true;

        }
    }
}
