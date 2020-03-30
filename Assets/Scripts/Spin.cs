﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 3.0f;

    void Update()
    {
        // Cosi ruota attorno al proprio asse Y
        //transform.Rotate(0, speed, 0);

        // Il 4' argomento e' lo spazio delle coordinate, il riferimento
        // Cosi ruota rispetto all'asse Y del mondo, del piano 
        transform.Rotate(0, speed, 0, Space.World);
    }
}
