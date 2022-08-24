using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public float moveDirection;
    public bool braking;
    private void Update()
    {
        if (Input.touchCount > 0 && Input.touchCount < 2)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < 0)
            {
                moveDirection = -1;
            }
            else
            {
                moveDirection = 1;
            }
        }
        else if (Input.touchCount == 0)
        {
            moveDirection = 0;
        }
        else if (Input.touchCount >= 2)
        {
            moveDirection = 2;
        }

    }
}
