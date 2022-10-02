using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] private int degreeOfStrange;
    public float HP;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Car car))
        {
            car.TakeDamage(degreeOfStrange, 0);
            HP -= car.GetDamage();
            if (HP <= 0)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                car.LvlComplete();
            }
            else
            {
                transform.GetChild(1).gameObject.SetActive(false);
                car.DestroyCar();
            }
        }
    }

}
