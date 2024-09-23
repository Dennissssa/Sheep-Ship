using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepRotation : MonoBehaviour
{
    public float rotationSpeed = 30f; 

    void Update()
    {
       
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}