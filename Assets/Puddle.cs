using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    [Range(0, 9)][SerializeField] private int speedDecrease;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Car car))
        {
            car.speed -= (car.speed * speedDecrease / 10) * 1000 / car.mass; ;
        }
    }
}
