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
            if (Input.touchCount > 0 && Input.touchCount < 2)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.x < Screen.width / 2)
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
                moveDirection = 0;
                if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(1).phase == TouchPhase.Began)
                {
                    braking = true;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(1).phase == TouchPhase.Ended)
                {
                    braking = false;
                }
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
