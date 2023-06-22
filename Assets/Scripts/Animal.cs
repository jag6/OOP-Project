using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private Rigidbody animalRb;
    public List<GameObject> animalPrefab;

    protected float speed;

    private int animalCount;
    private int waveCount = 1;

    protected float spawnRangeX = 10;
    protected float spawnZMin = 15;
    protected float spawnZMax = 25; 

    private GameObject player;

    void Start()
    {
        animalRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        Spawn(waveCount);
    }

    void Update()
    {
        animalCount = GameObject.FindGameObjectsWithTag("Respawn").Length;

        if (animalCount == 0)
        {
            waveCount++;
            Spawn(waveCount);
        }

        Move();
    }

    protected virtual void Move()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        animalRb.AddForce(speed * Time.deltaTime * lookDirection);
    }

    protected virtual Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(-spawnZMin, spawnZMax);

        Vector3 randomPos = new Vector3(xPos, 0, zPos);
        return randomPos;
    }

    void Spawn(int animalsToSpawn)
    {
        int index = Random.Range(0, animalPrefab.Count);

        for (int i = 0; i < animalsToSpawn; i++)
        {
            Instantiate(animalPrefab[index], GenerateSpawnPosition(), animalPrefab[index].transform.rotation);
        }
    }
}
