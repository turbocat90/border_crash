using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hedgehog : MonoBehaviour
{
    [Range(0,10)] public int degreeOfStrength;
    public float damage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Car car))
        {
            car.HP -= damage;
            if (car.HP <= 0)
            {
                car.isCarDestroyed = true;
            }
            if (degreeOfStrength < 10)
            {
                car.speed -= (car.speed * degreeOfStrength / 10) * 1000 / car.mass;
                gameObject.SetActive(false);
            }
            if (degreeOfStrength == 10)
            {
                car.isCarDestroyed = true;
            }
        }
    }
}

