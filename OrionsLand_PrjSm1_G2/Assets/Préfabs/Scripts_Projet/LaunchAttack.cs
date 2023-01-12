using UnityEngine;

public class LaunchAttack : MonoBehaviour
{
    [Header("Liens Scripts")]
    public Ressources playerRessource;

    [Header("Position GameObject")]
    public Transform spellSpawnpoint;

    [Space(10)]
    [Header("Props et prefabs")]
    public GameObject spellWater;
    public GameObject spellWind;


    [Space(10)]
    [Header("Les FX")]
    public GameObject zoneAttackFire;
    public ParticleSystem Flame;


    [Space(10)]
    [Header("Les Variables")]
    public float spellCost = 30f;
    public float spellSpeed = 10f;
    public float timeFireSpell = 3f;
    public float currentTimeFireSpell;

    bool spell1;
    bool spell2;
    bool spell3;

    private void Start()
    {
        zoneAttackFire.SetActive(false);
        currentTimeFireSpell = timeFireSpell;
    }

    void Update()
    {
        SpellSelector();
        
        if (Input.GetMouseButtonDown(0) && playerRessource.EnergySpend(spellCost))
        {
            ShootSpell();
            if (spell1 == true)
            {
                zoneAttackFire.SetActive(true);

                if (currentTimeFireSpell <= 0f)
                {
                    zoneAttackFire.SetActive(false);
                    currentTimeFireSpell = timeFireSpell;
                }
                else
                {
                    currentTimeFireSpell -= 1 * Time.deltaTime;

                }
            }
        }
    }

    private void FlameTImer()
    {

    }

    private void ShootSpell()
    {
        if (spell1 == true)
        {
            Flame.Play(true);

        }

        if (spell2 == true)
        {
            GameObject spell = Instantiate(spellWater, spellSpawnpoint.position, spellSpawnpoint.rotation);
            Rigidbody rig = spell.GetComponent<Rigidbody>();
            rig.AddForce(spellSpawnpoint.forward * spellSpeed, ForceMode.Impulse);
        }           

        if (spell3 == true)
        {
            GameObject spell = Instantiate(spellWind, spellSpawnpoint.position, spellSpawnpoint.rotation);
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
