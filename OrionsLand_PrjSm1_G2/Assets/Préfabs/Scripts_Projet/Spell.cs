using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public float lifetimeSpell = 2;
    private void OnCollisionEnter(Collision collision)
    {
         Destroy(gameObject);     
    }
    private void Start()
    {
        Destroy(gameObject, lifetimeSpell);
    }
}