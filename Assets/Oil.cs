using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{
    //[SerializeField] private float rotateAngleDecrease;
    [SerializeField] [Range(0,9)] private int speedDecrease;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.TryGetComponent( out Car car))
        {
            other.TryGetComponent(out Rigidbody rb);
            rb.AddForce(car.transform.forward * car.speed/2, ForceMode.VelocityChange);
            //car.rotateAngle -= rotateAngleDecrease;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Car car))
        {
            car.speed -= (car.speed * speedDecrease / 10) * 1000 / car.mass;
        } 
    }
    /*private void OnTriggerExit(Collider other) 
    {
        if (other.TryGetComponent( out Car car))
        {
            car.rotateAngle += rotateAngleDecrease;
        }
    }*/
}
