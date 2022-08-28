using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PreviewCamera : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    private float m_velocity = 0;
    private static Camera m_previewCamera;
    private static Vector3 m_startPosition = new Vector3(0, 112.9f, 427.21f);
    private static Vector3 m_endPosition = new Vector3(0, 109.7f, -167.8f);
    private static bool isActive;
    private static float m_baseFOV = 75f;
    private void Awake()
    {
        m_previewCamera = GetComponent<Camera>();
        Condition(true);
    }
    void FixedUpdate()
    {
        if (isActive)
        {
            if (Vector3.Distance(transform.position, m_endPosition) > 0.5f)
            {


                // switch FOV to start 
                m_previewCamera.fieldOfView = Mathf.SmoothDamp(m_previewCamera.fieldOfView, m_baseFOV, ref m_velocity, 0.5f);

                // move
                transform.position = Vector3.MoveTowards(m_previewCamera.transform.position, m_endPosition, cameraSpeed);
                /*        if (Vector3.Distance(m_previewCamera.transform.position, m_endPosition) < 0.5f)
                        {
                            // end move
                            Condition(false);
                            CameraController.DisablePreviewCamera();
                        }*/
            }
            else
            {
                
                m_previewCamera.fieldOfView = Mathf.SmoothDamp(m_previewCamera.fieldOfView, 50f, ref m_velocity, 0.5f);
                if(m_previewCamera.fieldOfView > 50 && m_previewCamera.fieldOfView  < 50.5f)
                {
                    // end move
                    Condition(false);
                    CameraController.DisablePreviewCamera();
                }
            }
        }
    }
    public static void SwitchStartPosition(Vector3 startPosition) => m_previewCamera.transform.position = startPosition;
    public static void Condition(bool active) => isActive = active;
    public static void EnabledDisable(bool isOn) => m_previewCamera.gameObject.SetActive(isOn);
    public static void SetFOV(float currentFOV) => m_previewCamera.fieldOfView = currentFOV;
}
