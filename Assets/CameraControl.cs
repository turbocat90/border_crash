using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;
    public CinemachineVirtualCamera virtualCamera;
    private float velocity = 0;
    public float cameraSpeed;
    private bool isEnd;
    private Vector3 currentPosition;
    private void Start()
    {
        currentPosition = transform.position;
        virtualCamera.transform.position = startPosition.position;
        virtualCamera.m_Lens.FieldOfView = 70;

    }
    private void Update()
    {
        if (!isEnd)
        {
            if (Vector3.Distance(virtualCamera.transform.position, endPosition.position) > 0.5f)
            {
                virtualCamera.transform.position = Vector3.MoveTowards(virtualCamera.transform.position, endPosition.position, cameraSpeed);
            }
            else
            {
                isEnd = true;
            }
        }

        if (isEnd)
        {
            virtualCamera.m_Lens.FieldOfView = Mathf.SmoothDamp(virtualCamera.m_Lens.FieldOfView, 43, ref velocity, .5f);
            virtualCamera.transform.position = Vector3.MoveTowards(transform.position, currentPosition, 1.5f);
        }
    }

}
