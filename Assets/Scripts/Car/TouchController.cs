using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public float moveDirection;
    public bool braking { get; set; } = false;
    public bool isStarting { get; set; } = false;
    private void Update()
    {
        if (isStarting)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.y > Screen.height / 6)
                {
                    if (touch.position.x < Screen.width / 2)
                    {
                        moveDirection = -1;
                    }
                    else
                    {
                        moveDirection = 1;
                    }
                }
                else
                {
                    braking = true;
                    moveDirection = 0;
                }
            }
            else
            {
                braking = false;
                moveDirection = 0;
            }             
        }
    }
    IEnumerator StartDelay()
    {
        moveDirection = 0;
        yield return new WaitForSeconds(0.3f);
        isStarting = true;
    }
    public void StartTouch() => StartCoroutine(StartDelay());
}
