using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    [Header("Base Settings")]
    public string CarName;
    public int ID;
    [SerializeField] private float baseSpeed;
    [SerializeField] private float baseAcceleration;
    [SerializeField] private float baseMaxSpeed;
    [SerializeField] private float baseTurnBraking;
    [SerializeField] private float baseRotateAngle;
    [SerializeField] private float baseMass;
    [SerializeField] private float baseArmor;
    [Space]
    [Header("Upgrade Settings")]
    [SerializeField] private float speedGradePercent;
    [SerializeField] private float armorGradePercent;
    [SerializeField] private float damageGradePercent;
    [SerializeField] private float controllGradePercent;

    public float currentSpeed { get; set; }
    public float currentAcceleration { get; set; }
    public float currentMaxSpeed { get; set; }
    public float currentTurnBraking { get; set; }
    public float currentRotateAngle { get; set; }
    public float currentMass { get; set; }
    public float currentArmor { get; set; }
    public float currentControll { get; set; }
    public int currentSpeedAndControllGrade = 0; //  { get; set; } = 0;
    public int currentArmorAndHpGrade = 0; // { get; set; } = 0;
    [Space]
    [Header("Components")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private VisualUpgrade visualUpgrade;
    [SerializeField] private TouchController touchController;
    private float m_rotateDirection;
    private float m_rotateSpeed = 1;
    private int maxArmorAndHpGrade = 10;
    private int maxSpeedAndControllGrade = 10;
    private float HP;
    private bool carIsActive = false;


    private void Awake()
    {
        Initialise();
        if(rb!= null)
            rb.mass = currentMass / 100;
    }
    private void Update()
    {
        m_rotateDirection = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        if (carIsActive)
        {
            Moving();
            Rotation();
        }
    }
    public void SpeedAndControllUpgrade()
    {
        if (currentSpeedAndControllGrade < maxSpeedAndControllGrade)
        {
            currentSpeedAndControllGrade++;
            currentSpeed += (baseSpeed / 100) * speedGradePercent;
            currentAcceleration += (baseAcceleration / 100) * speedGradePercent;
            currentMaxSpeed += (baseMaxSpeed / 100) * speedGradePercent;
            currentRotateAngle += (baseRotateAngle / 100) * speedGradePercent;
            // добавить контроль
            visualUpgrade.ActiveSpeedGrade(currentSpeedAndControllGrade);
        }
    }
    public void ArmorAndDamageUpgrade()
    {
        if (currentArmorAndHpGrade < maxArmorAndHpGrade)
        {
            currentArmorAndHpGrade++;
            currentArmor += (baseArmor / 100) * armorGradePercent;
            currentMass += (baseMass / 100) * armorGradePercent;
            visualUpgrade.ActiveArmorGrade(currentArmorAndHpGrade);
        }
    }
    private void Initialise()
    {
        if (currentSpeedAndControllGrade == 0)
        {
            currentSpeed = baseSpeed;
            currentAcceleration = baseAcceleration;
            currentMaxSpeed = baseMaxSpeed;
            currentTurnBraking = baseTurnBraking;
            currentRotateAngle = baseRotateAngle;
        }
        else
        {
            for (int i = 0; i < currentSpeedAndControllGrade; i++)
            {
                SpeedAndControllUpgrade();
            }
        }
        if (currentArmorAndHpGrade == 0)
        {
            currentMass = baseMass;
            currentArmor = baseArmor;
        }
        else
        {
            for (int i = 0; i < currentArmorAndHpGrade; i++)
            {
                ArmorAndDamageUpgrade();
            }
        }
    }
    private void Rotation()
    {
        transform.Rotate(0, currentRotateAngle * m_rotateSpeed * touchController.moveDirection * Time.deltaTime, 0);
        transform.Rotate(0, currentRotateAngle * m_rotateSpeed * m_rotateDirection * Time.deltaTime, 0);
        if (currentSpeed > 0 && m_rotateDirection != 0 || currentSpeed > 0 && touchController.moveDirection != 0)
        {
            currentSpeed -= currentTurnBraking * Time.fixedDeltaTime;
        }
    }
    private void Moving()
    {

        if (currentSpeed < currentMaxSpeed)
        {
            currentSpeed += currentAcceleration * Time.fixedDeltaTime;
        }
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space) && currentSpeed > 0)
        {
            currentSpeed -= currentSpeed * 0.1f;
        }
    }
    public void TakeDamage(int speedFall, int damage, bool destroy = false)
    {
        if (destroy)
        {
            DestroyCar();
        }
        else
        {
            HP -= damage;
            currentSpeed -= (currentSpeed * speedFall / 10) * 1000 / currentMass;
        }
        if (HP <= 0)
            DestroyCar();
    }
    public void DestroyCar()
    {
        visualUpgrade.StartDeathParticle(); //активация партиклов смерти
        StopCar();
        StartCoroutine(DeathDelay());
    }
    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(1.3f);
        ActionSystem.CarDestroyed();
        gameObject.SetActive(false);
    }
    public void StartCar()
    {
        HP = currentArmor;
        carIsActive = true;
        visualUpgrade.StartMovingParcticle();
    }
    public float GetDamage() => currentMass * currentSpeed / 1000;
    public void StopCar()
    {
        visualUpgrade.StopMovingParticles();
        /*currentSpeed = 0;
        currentAcceleration = 0;*/
        carIsActive = false;
    }
    public void FInishLvl()
    {
        currentSpeed = baseSpeed;
        ActionSystem.CarFinished();
    }
    public void LvlComplete()
    {
        StartCoroutine(LvlCompleteDelay());
    }
    IEnumerator LvlCompleteDelay()
    {
        Debug.Log("finish");
        yield return new WaitForSeconds(1.0f);
        StopCar();
        FInishLvl();

    }
    public void Skidding() => rb.AddForce(transform.forward * currentSpeed / 2, ForceMode.VelocityChange);
}
