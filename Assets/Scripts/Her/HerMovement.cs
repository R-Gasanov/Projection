using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerMovement : MonoBehaviour
{ // Her movement will be set to two and change over time based on the levels finished
    public static float speed = 0f;
    private Transform Character;


    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Character != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Character.position, speed * Time.deltaTime);
        }
    }
}
