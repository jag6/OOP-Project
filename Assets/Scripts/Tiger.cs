using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiger : Animal
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Move()
    {
        speed = 100.0f;
        base.Move();
    }
}