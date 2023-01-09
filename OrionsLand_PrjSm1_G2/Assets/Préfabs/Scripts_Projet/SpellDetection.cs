using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDetection : MonoBehaviour
{
    [Header("PositionGameObject")]
    public Transform propPosition;

    [Space (10)]
    [Header("Particle")]

    public GameObject particleFire;
    public GameObject particleWater;
    public GameObject particleWind;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "SpellFeu")
        {
            GameObject particle = Instantiate(particleFire, propPosition.position, propPosition.rotation);
        }

        else if (collision.gameObject.tag == "SpellEau")
        {
            GameObject particle = Instantiate(particleWater, propPosition.position, propPosition.rotation);
        }

        else if (collision.gameObject.tag == "SpellVent")
        {
            GameObject particle = Instantiate(particleWind, propPosition.position, propPosition.rotation);
        }
    }
    void Update()
    {
        
    }
}
