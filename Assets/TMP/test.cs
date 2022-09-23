using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private CarList carList;
    private void Start()
    {
        carList = GetComponent<CarList>();
        //Instantiate(carList.cars[0], );
    }
}
