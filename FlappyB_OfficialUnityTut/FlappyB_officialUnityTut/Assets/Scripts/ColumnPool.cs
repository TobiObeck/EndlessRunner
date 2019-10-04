using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float spawnRate = 4f;
    public float columnMin = -5f;
    public float columnMax = -1.5f;

    private GameObject[] columns;
    private Vector2 objectPoolPos = new Vector2(-15, 0);
    private float timeSinceLastSpawned = 2f;
    private float spawnXPosition = 10f;
    private int currentColumn = 0;

	// Use this for initialization
	void Start ()
    {
        columns = new GameObject[columnPoolSize];
        for(int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(
                                    this.columnPrefab
                                    , this.objectPoolPos
                                    , Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.timeSinceLastSpawned += Time.deltaTime;

        if(GameControl.instance.gameOver == false
                    && this.timeSinceLastSpawned >= this.spawnRate)
        {
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
            this.timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(this.columnMin, this.columnMax);
            this.columns[this.currentColumn].transform.position = new Vector2(this.spawnXPosition, spawnYPosition);
            currentColumn++;
        }
	}
}
