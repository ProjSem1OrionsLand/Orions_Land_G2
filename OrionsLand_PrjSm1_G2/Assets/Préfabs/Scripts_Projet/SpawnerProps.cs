using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerProps : MonoBehaviour
{
    public SpellDetection SpellDetection;
    public float currentRespawnProps;
    public float respawnProps = 15f;

    private void Start()
    {
        currentRespawnProps = respawnProps;
    }
    void Update()
    {
        if (SpellDetection.timerRespawn == true)
        {
            currentRespawnProps -= 1 * Time.deltaTime;
        }

        if (currentRespawnProps < 0)
        {
            SpellDetection.props.SetActive(true);
            SpellDetection.timerRespawn = false;
            SpellDetection.activation = true;
            currentRespawnProps = respawnProps;
        }
    }
}
