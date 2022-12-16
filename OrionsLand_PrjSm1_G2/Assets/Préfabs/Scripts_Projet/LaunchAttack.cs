using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchAttack : MonoBehaviour
{
    public Transform spellSpawnpoint;
    public GameObject spellPrefab1;
    public GameObject spellPrefab2;
    public GameObject spellPrefab3;


    bool spell1;
    bool spell2;
    bool spell3;
    public float spellSpeed = 10f;


    void Update()
    {
        SpellSelector();
        
        if (Input.GetMouseButtonDown(0))
        {
            ShootSpell();
        }

    }


    private void ShootSpell()
    {
        if (spell1 == true)
        {
            GameObject spell = Instantiate(spellPrefab1, spellSpawnpoint.position, spellSpawnpoint.rotation);
            Rigidbody rig = spell.GetComponent<Rigidbody>();

            rig.AddForce(spellSpawnpoint.forward * spellSpeed, ForceMode.Impulse);
        }
            

        if (spell2 == true)
        {
            GameObject spell = Instantiate(spellPrefab2, spellSpawnpoint.position, spellSpawnpoint.rotation);
            Rigidbody rig = spell.GetComponent<Rigidbody>();

            rig.AddForce(spellSpawnpoint.forward * spellSpeed, ForceMode.Impulse);
        }
           

        if (spell3 == true)
        {
            GameObject spell = Instantiate(spellPrefab3, spellSpawnpoint.position, spellSpawnpoint.rotation);
            Rigidbody rig = spell.GetComponent<Rigidbody>();

            rig.AddForce(spellSpawnpoint.forward * spellSpeed, ForceMode.Impulse);
        }
    }

    private void SpellSelector()
    {
        if (Input.GetButtonDown("Slot1"))
        {
            spell1 = true;

            spell2 = false;
            spell3 = false;
        }

        if (Input.GetButtonDown("Slot2"))
        {
            spell2 = true;

            spell1 = false;
            spell3 = false;
        }

        if (Input.GetButtonDown("Slot3"))
        {
            spell3 = true;

            spell1 = false;
            spell2 = false;
        }

    }

}
