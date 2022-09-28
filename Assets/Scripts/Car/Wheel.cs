using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] private GameObject wheel_1;
    [SerializeField] private GameObject wheel_2;
    [SerializeField] private GameObject wheel_3;
    [SerializeField] private GameObject wheel_4;
    private bool isStart = false;
    private void FixedUpdate()
    {
        if(isStart)
            WheelRotate();
    }
    private void WheelRotate()
    {
        wheel_1.transform.Rotate(Vector3.right * 80);
        wheel_2.transform.Rotate(Vector3.right * 80);
        wheel_3.transform.Rotate(Vector3.right * 80);
        wheel_4.transform.Rotate(Vector3.right * 80);
    }
    public void StartRotate(bool isStarting) => isStart = isStarting;
}
