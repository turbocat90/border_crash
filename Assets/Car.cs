using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    private Rigidbody rb;
    private float rotateDirection;
    public float speed;
    public float speedBoost;
    [SerializeField] private float maxSpeed;
    public float rotateSpeed;
    public float rotateAngle;
    [SerializeField] private float turnBraking;
    public float mass;
    public float HP;
    private TouchController touchController;
    public bool isCarDestroyed;
    public ParticleSystem[] particleDeath;
    public ParticleSystem[] particleDust;
    public bool goToFinish;
    public CinemachineVirtualCamera virtualCamera;
    public Transform startPoint;
    public bool isStarting;
    public Canvas canvas;
    private float velocity = 0;
    public Text startText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = mass / 100;
        touchController = GetComponent<TouchController>();
    }
    private void Update()
    {
        rotateDirection = Input.GetAxisRaw("Horizontal");
        Death();
        GoToFinish();
        if (isStarting)
        {
          //  float targetFOV = 28 + speed * 0.5f;
         //   virtualCamera.m_Lens.FieldOfView = Mathf.SmoothDamp(virtualCamera.m_Lens.FieldOfView, targetFOV, ref velocity, 1f);
        }
    }
    private void FixedUpdate()
    {
        if(isStarting)
        {
            Moving();
            Rotation();
        }       
        GoToFinish();
    }
    private void Rotation()
    {
        if (speed > speedBoost)
        {
            transform.Rotate(0, rotateAngle * rotateSpeed * touchController.moveDirection * Time.deltaTime, 0);
            transform.Rotate(0, rotateAngle * rotateSpeed * rotateDirection * Time.deltaTime, 0);
        }

        if (rotateDirection != 0 && speed > 0)
        {
            speed -= turnBraking * Time.fixedDeltaTime;
        }
        if (touchController.moveDirection != 0 && speed > 0)
        {
            speed -= turnBraking * Time.fixedDeltaTime;
        }
    }
    private void Moving()
    {
        //rb.velocity = transform.forward * speed;
        //rb.AddForce(transform.forward * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        if (speed < maxSpeed)
        {
            speed += speedBoost * Time.fixedDeltaTime;
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space) && speed > 0)
        {
            speed -= speed * 0.1f;
        }
    }
    private void Death()
    {
        if (isCarDestroyed)
        {
            isCarDestroyed = false;
            speed = 0;
            speedBoost = 0;
            foreach (ParticleSystem particle in particleDeath)
            {
                particle.Play();
            }
            foreach (ParticleSystem particle in particleDust)
            {
                particle.Stop();
            }
            StartCoroutine(en());
        }
        
    }
    private void GoToFinish()
    {
        Vector3 finish = new Vector3(0, 0, 480);
        if (goToFinish)
        {
            //canvas.gameObject.SetActive(true);
            transform.LookAt(finish);
            //transform.position = Vector3.MoveTowards(transform.position, finish, 40 * Time.fixedDeltaTime);
            float distance = Vector3.Distance(finish, transform.position);
            if (distance < 1)
            {
                speed = 0;
                speedBoost = 0;
                goToFinish = false;
                foreach (ParticleSystem particle in particleDust)
                {
                    particle.Stop();
                }
            }         
        }
    }
    IEnumerator en()
    {
        yield return new WaitForSeconds(1.3f);
        virtualCamera.Follow = startPoint;
        CameraController.StartPreviewCamera();

        gameObject.SetActive(false);
    }
    public IEnumerator enText()
    {
       /* startText.gameObject.SetActive(true);
        startText.text = "3";
        yield return new WaitForSeconds(1f);
        startText.text = "2";
        yield return new WaitForSeconds(1f);
        startText.text = "1";*/
        yield return new WaitForSeconds(1f);
      //  startText.text = "GO";
        isStarting = true;
/*        yield return new WaitForSeconds(.5f);
        startText.gameObject.SetActive(false);*/
    }
}
