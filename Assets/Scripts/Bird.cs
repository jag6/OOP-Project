using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Animal
{
    private float spawnRangeY = 10;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected override void Move()
    {
        speed = 40.0f;
        base.Move();
    }

    protected override Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float yPos = Random.Range(-spawnRangeY, spawnRangeY);
        float zPos = Random.Range(-spawnZMin, spawnZMax);

        Vector3 randomPos = new Vector3(xPos, yPos, zPos);

        return randomPos;
    }
}
