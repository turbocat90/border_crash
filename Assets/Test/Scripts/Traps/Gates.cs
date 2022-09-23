using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    public float HP;
    private bool IsFinish = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Car car))
        {
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
