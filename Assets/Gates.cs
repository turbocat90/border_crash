using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    public float Hp;
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Car car))
        {
            Hp -= (car.mass * car.speed) / 1000;
        }
        Debug.Log(Hp);
        if (Hp <= 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Car car))
        {
            Hp -= (car.mass * car.speed) / 1000;
        }
        Debug.Log(Hp);
        if (Hp <= 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            /*car.speed = 0;
            car.speedBoost = 0;*/
            car.goToFinish = true;
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);

        }
    }
}
