using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy's Movement Speed
    public float speed = 8f;
    
    // Keep these static.
    private float zOrder = 15f;
    private float yOrder = 0.99f;

    float[] xPos;

    Vector3 nextMovement;

    public bool moving;
    public bool canMove = true;

    // Does not need to be manually set. Will be automatically chosen by the enemy.
    public int movementChoice = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Possible movements locations that it can choose to slide to randomly.
        xPos = new float[5];

        xPos[0] = 0f;
        xPos[1] = -3.5f;
        xPos[2] = 3.5f;
        xPos[3] = -7f;
        xPos[4] = 7f;

        // Sets the spawnpoint of the enemy to this Vector3.
        nextMovement = new Vector3(xPos[0], yOrder, zOrder);
        transform.position = nextMovement;
    
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!moving && canMove)
        {
            movementChoice = ChooseNextMovement(movementChoice);
            canMove = false;
            moving = true;
        }

        if (moving)
        {
            Move();
        }

    }

    int ChooseNextMovement(int previousChoice)
    {
        // A looping if-check to make sure that the new choice isn't the same as the previous one.
        int choice = previousChoice;
        while (previousChoice == choice)
        {
            choice = Random.Range(0, 4);
        }

        // Add if checks to determine if the distance between choices is great enough?

        return choice;
    }

    void Move()
    {
        if (transform.position.x < xPos[movementChoice] && transform.position.x != xPos[movementChoice])
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x > xPos[movementChoice] && transform.position.x != xPos[movementChoice])
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }

        if (transform.position.x == xPos[movementChoice])
        {
            moving = false;
            // canMove would hypothetically be set True somewhere else? Maybe?
            canMove = true;
        }
            

    }
}
