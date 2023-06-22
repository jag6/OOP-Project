using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    public Rigidbody animalRb;

    public float speed { get; protected set; }
    protected abstract float defaultSpeed { get; }

    private GameObject player;

    void Awake()
    {
        speed = defaultSpeed;    
    }

    void Start()
    {
        animalRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        animalRb.AddForce(speed * Time.deltaTime * lookDirection);
    }
}
