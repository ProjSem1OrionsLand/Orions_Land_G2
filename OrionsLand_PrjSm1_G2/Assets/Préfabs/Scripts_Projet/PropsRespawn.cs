using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsRespawn : MonoBehaviour
{
	[Header("Liens Scripts")]
	public SpellDetection spellValid;

	[Space(10)]

	[Header("Info Spawn GameObject")]
	public GameObject propsToSpawn;
	public Transform spawnPoint;

	[Space(10)]

	[Tooltip("Temps pour respawn le GameObject")]
	public float respawnTime = 10f;
	public float currentRespawnTime;

	void Start()
	{
		currentRespawnTime = respawnTime;
	}

	void FixedUpdate()
	{
/*        if (spellValid.activation == true)
        {
			currentRespawnTime -= 1*Time.deltaTime;
			if(currentRespawnTime <= 0f)
            {
				GameObject props = Instantiate(propsToSpawn, spawnPoint.position, spawnPoint.rotation);
				spellValid.activation = false;
				currentRespawnTime = respawnTime;
			}
		}
*/

	}
}
