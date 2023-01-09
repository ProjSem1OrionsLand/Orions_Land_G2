using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressources : MonoBehaviour
{
    public float maxMana = 100f;
    public float currentMana = 100f;
    public float manaRegenPerSec = 15f;

    void Start()
    {
        currentMana = maxMana;
    }

    void RegenMana()
    {
        if (currentMana < maxMana)
        {
            currentMana += manaRegenPerSec*Time.deltaTime;
            currentMana = Mathf.Clamp(currentMana, 0f, maxMana);
        }
    }

    public bool EnergySpend(float spellCost)
    {
        //on vx dépenser de l'énergie
        //Check si on en a assez
        //Si on en a assez, on return "true" et on dépense
        //Si non, on retourne false

        if (spellCost <= currentMana)
        {
            currentMana -= spellCost;
            return true;
        }

        return false;

    }

    void Update()
    {
        RegenMana();
    }
}
