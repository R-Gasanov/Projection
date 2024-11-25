using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerSpawn : MonoBehaviour
{
    public GameObject Her; // Her
    public Transform Character; // The main player

    // The Spawn distance and chance

    public float SpawnDist = 5f;
    public static float SpawnChance = 0f;


    // Start is called before the first frame update
    void Start()
    {
        // We will want it to have a chance at spawning every incrimental second
        InvokeRepeating("AttemptSpawn", 1f, 1f);
    }

    // Update is called once per frame
    void AttemptSpawn()
    {
        // We will creating the random generator

        // It'll be from 0-1 and random float value and since we've capped it at 0.2 it'll only spawn 20% chance
        float RandVal = Random.Range(0f, 1f);

        if (RandVal < SpawnChance)
        {
            SpawnHer();
        }
    }

    void SpawnHer()
    {
        Vector2 SpawnLoc = (Vector2)Character.position - new Vector2(SpawnDist, 0);

        Instantiate(Her, SpawnLoc, Quaternion.identity);
    }
}
