using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    List<GameObject> prefabs = new List<GameObject>();
    public GameObject plate1Prefab;                                    //The column game object.
    public GameObject plate2Prefab;

    public int poolSize = 8;                                  //How many columns to keep on standby.
    public float spawnRate = 3f;                                    //How quickly columns spawn.
    public float yMin = -1f;                                    //Minimum y value of the column position.
    public float yMax = 3.5f;                                    //Maximum y value of the column position.

    private GameObject[] obstacles;                                    //Collection of pooled columns.
    private int current = 0;                                    //Index of the current column in the collection.

    private Vector2 objectPoolPosition = new Vector2 (-15,-25);        //A holding position for our unused columns offscreen.
    private float spawnXPosition = 7f;

    private float timeSinceLastSpawned;


    void Start()
    {
        timeSinceLastSpawned = 0f;

        prefabs.Add(plate1Prefab);
        prefabs.Add(plate2Prefab);

        //Initialize the columns collection.
        obstacles = new GameObject[poolSize];
        //Loop through the collection... 
        for(int i = 0; i < poolSize; i++)
        {
            //...and create the individual columns.
            obstacles[i] = (GameObject)Instantiate(prefabs[Random.Range(0, 2)], objectPoolPosition, Quaternion.identity);
        }
    }


    //This spawns columns as long as the game is not over.
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
        {    
            timeSinceLastSpawned = 0f;

            //Set a random y position for the column
            float spawnYPosition = Random.Range(yMin, yMax);

            //...then set the current column to that position.
            obstacles[current].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            current ++;

            if (current >= poolSize) 
            {
                current = 0;
            }
        }
    }
}