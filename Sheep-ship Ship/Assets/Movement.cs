using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 5f; 
    public float rotationSpeed = 700f; 

    void Update()
    {
        
        Vector3 direction = Vector3.zero;

       
        if (Input.GetKey(KeyCode.W))
        {
            direction += transform.forward; 
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += -transform.forward; 
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += -transform.right; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += transform.right; 
        }

        
        if (direction != Vector3.zero)
        {
            MoveShip(direction.normalized); 
            RotateShip(direction.normalized);
        }
    }

    
    void MoveShip(Vector3 direction)
    {
        
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    
    void RotateShip(Vector3 direction)
    {
        
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}