using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barell : MonoBehaviour
{
    [SerializeField] private float expForce;
    [SerializeField] private float expRadius;
    private float expTimer;
    private bool startTimer = false;
    private float timeToExp;
    [SerializeField] [Range(0,10)] private float speedDecrease;
    public ParticleSystem particleExp;
    private void Update() 
    {
        if (startTimer)
        {
            expTimer += Time.deltaTime;
            if (expTimer >= timeToExp)
            {
                startTimer = false;
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, expRadius);
                foreach (var item in hitColliders)
                {
                    if (item.TryGetComponent(out Rigidbody rb))
                    {
                        rb.AddExplosionForce(expForce, transform.position, expRadius, 0, ForceMode.Impulse);
                        if (item.TryGetComponent(out Car car))
                        {
                            car.speed -= (car.speed * speedDecrease / 10) * 1000 / car.mass;
                            car.HP -= 1500;
                        }                       
                        particleExp.Play();
                        /*Vector3 carpos = car.gameObject.transform.position;
                        Vector3 pos = new Vector3(carpos.x - transform.position.x, carpos.y - transform.position.y, carpos.z - transform.position.z);
                        rb.AddForce(pos.x * expForce/2 , pos.y,pos.z * expForce, ForceMode.Impulse);
                        car.speed = 0;*/
                        Debug.Log("boom");
                    }
                }
                StartCoroutine(en());
                //Destroy(gameObject);   
            }
        }
    }
    IEnumerator en()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.TryGetComponent(out Car car))
        {
            expTimer = 0;
            startTimer = true;
            timeToExp = 0;
        }
    }
}
