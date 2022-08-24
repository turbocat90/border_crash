using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float speedMove;
    public float speedRot;
    private float turnAngel;

    
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
        Rotation();
    }
    private void Update()
    {
        turnAngel = Input.GetAxis("Horizontal") * speedRot * Time.deltaTime;
    }
    private void Rotation()
    {
        Quaternion RotateAngle = Quaternion.Euler(0, turnAngel, 0);
        transform.Rotate(0, turnAngel, 0);
    }
    private void Move()
    {
        rb.AddForce(transform.forward * speedMove * Time.deltaTime);
    }
}
