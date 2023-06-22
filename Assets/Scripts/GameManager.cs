using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> animalPrefab;

    private int animalCount;
    private int waveCount = 1;

    private float spawnRangeX = 10;
    private float spawnZMin = 15;
    private float spawnZMax = 25;

    // Start is called before the first frame update
    void Start()
    {
        Spawn(waveCount);
    }

    // Update is called once per frame
    void Update()
    {
        animalCount = GameObject.FindGameObjectsWithTag("Animal").Length;

        if (animalCount == 0)
        {
            waveCount++;
            Spawn(waveCount);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(-spawnZMin, spawnZMax);

        Vector3 randomPos = new Vector3(xPos, 0, zPos);
        return randomPos;
    }

    void Spawn(int animalsToSpawn)
    {
        int index = 0;

        for (int i = 0; i < animalsToSpawn; i++)
        {
            Instantiate(animalPrefab[index], GenerateSpawnPosition(), animalPrefab[index].transform.rotation);
        }
    }
}
