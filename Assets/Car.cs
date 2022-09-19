using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    [SerializeField] private Transform finish;
    [SerializeField] private float turnBraking;
    public VisualUpgrade visualUpgrade;
    public int currentDamageGrade { get; set; }
    public int currentSpeedGrade { get; set; }
    public int currentArmorGrade { get; set; }
    public int currentcontrollGrade { get; set; }
    private Rigidbody rb;
    private float rotateDirection;
    public float maxSpeed;
    public float speed;
    public float speedBoost;
    public float rotateSpeed;
    public float rotateAngle;
    public float damage;
    public float controll;
    public float armor;
    public string name;
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
    public int id;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = damage / 100;
        touchController = GetComponent<TouchController>();
    }
    private void Update()
    {
        rotateDirection = Input.GetAxisRaw("Horizontal");
        Death();
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
            GlobalEventSystem.CarDestroyed();
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
    IEnumerator en()
    {
        yield return new WaitForSeconds(1.3f);
        //virtualCamera.Follow = startPoint;
        gameObject.SetActive(false);
        CameraController.StartPreviewCamera();

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
    public void DamageGrade()
    {
        if (currentDamageGrade < 20)
        {
            //visualUpgrade.ArmorGrade(currentArmorGrade);
            damage += 100;
            currentDamageGrade++;
        }
    }
    public void SpeedGrade()
    {
        if (currentSpeedGrade < 20)
        {
            //visualUpgrade.SpeedGrade(currentSpeedGrade);
            speed += speed * 0.05f;
            speedBoost += speedBoost * 0.05f;
            maxSpeed += 5f;
            currentSpeedGrade++;
        }
    }
    public void ArmorGrade()
    {
        if (currentArmorGrade < 20)
        {
            //visualUpgrade.SpeedGrade(currentSpeedGrade);
            armor += 100;
            currentArmorGrade++;
        }
    }
    public void ControllGrade()
    {
        if (currentcontrollGrade < 20)
        {
            //visualUpgrade.SpeedGrade(currentSpeedGrade);
            rotateAngle += 1;
            rotateSpeed += 0.5f;
            controll += 5;
            currentcontrollGrade++;
        }
    }
    public void Initialize()
    {
        for (int i = 0; i < SaveLoad.instance.saver.Count; i++)
        {
            if (SaveLoad.instance.saver[i].carID == this.id)
            {
                for (int j = 0; j < SaveLoad.instance.saver[i].speedGrade; j++)
                {
                    SpeedGrade();
                }
                for (int j = 0; j < SaveLoad.instance.saver[i].damageGrade; j++)
                {
                    DamageGrade();
                }
                for (int j = 0; j < SaveLoad.instance.saver[i].hpGrade; j++)
                {
                    ArmorGrade();
                }
                for (int j = 0; j < SaveLoad.instance.saver[i].controllGrade; j++)
                {
                    ControllGrade();
                }
            }
        }
    }
}
