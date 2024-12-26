using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerSpawn : MonoBehaviour
{
    public GameObject Her; // Her
    public Transform Character; // The main player

    // These are left and right spawners which will spawn on top of spawners a certain distance away from the current player.

    public Transform RightSpawn;
    public Transform LeftSpawn;


    // The Spawn distance and chance

    //public float SpawnDist = 7f;
    public static float SpawnChance = 0f;

    // Start is called before the first frame update
    void Start()
    {


        // We will want it to have a chance at spawning every incrimental second
        InvokeRepeating("AttemptSpawn", 1f, 1f);
    }

    private void Update()
    {
        PositionUpdate();
    }

    void PositionUpdate()
    {
        Vector2 RightSpawnPos = RightSpawn.transform.position;
        Vector2 LeftSpawnPos = LeftSpawn.transform.position;
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
        // NEW additional code for the game itself
        int counter = Random.Range(0, 2); // Generate a value between 0 or 1 (0 is inclusive in the MIN range 2 is exlusive in the MAX range)
        Debug.Log("Here is the counter! " + counter);

        if (counter == 0)
        {
            Vector2 SpawnLoc = RightSpawn.position;

            Instantiate(Her, SpawnLoc, Quaternion.Euler(0, 180, 0));
        }
        else if (counter == 1) // To spawn on the opposite end of the charcter to make it more interersting 
        {
            Vector2 SpawnLoc = LeftSpawn.position;

            Instantiate(Her, SpawnLoc, Quaternion.identity);
        }

    }
}
