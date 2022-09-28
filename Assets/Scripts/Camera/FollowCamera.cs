using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private float smoothRateFOV;
    private float cameraSpeed = 0;
    private float minFOV = 30, maxFOV = 60;
    private float m_offset_X = 0f;
    public float m_offset_Z = 32f;
    private float m_velocity = 0;
    private Vector3 m_velocityV;
    private Vector3 m_target;
    private static Camera m_mainCamera;
    private static Car m_followTarget;
    private static float currentFOV;
    private static Vector3 startPosition = new Vector3(0, 109.7f, -167.8f);

    private void Awake()
    {
        m_mainCamera = GetComponent<Camera>();
        m_followTarget = null;
    }
    void FixedUpdate()
    {
        if (m_followTarget)
        {
            //  olf method
            /* Vector3 currentPosition = Vector3.Lerp(transform.position, m_target, cameraSpeed * Time.fixedDeltaTime);
             transform.position = currentPosition;
             m_target = new Vector3(m_followTarget.gameObject.transform.position.x + offset_X, transform.position.y, m_followTarget.gameObject.transform.position.z + offset_Z);
 */
            // new method
            Vector3 carpos = new Vector3(m_followTarget.gameObject.transform.position.x + m_offset_X, transform.position.y, m_followTarget.gameObject.transform.position.z - m_offset_Z);
            transform.position = Vector3.SmoothDamp(transform.position, carpos, ref m_velocityV, cameraSpeed);



            m_offset_Z = 50 - (m_mainCamera.fieldOfView / 2);

            float targetFOV = 28 + m_followTarget.currentSpeed * 0.5f;
            m_mainCamera.fieldOfView = Mathf.Clamp(Mathf.SmoothDamp(m_mainCamera.fieldOfView, targetFOV, ref m_velocity, smoothRateFOV),minFOV, maxFOV);



            currentFOV = m_mainCamera.fieldOfView;
        }
    }
    public static float GetCurrentFOV() => currentFOV;
    public static void SetFollowTarget(Car car ) => m_followTarget = car;
    public static void EnabledDisable(bool isOn) => m_mainCamera.gameObject.SetActive(isOn);
    public static void ResetPosition()
    {
        m_mainCamera.transform.position = startPosition;
        m_mainCamera.fieldOfView = 50;
    }
    public static Vector3 GetCurrentPosition() => m_mainCamera.transform.position;




}
