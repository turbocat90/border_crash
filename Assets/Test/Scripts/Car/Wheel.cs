using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public void WheelMoving(float speed) => transform.Rotate(Vector3.right * speed);
}
