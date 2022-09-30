using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieVisual : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> particles;
    [SerializeField] private NavaMeshAge navaMeshAge;
    private Animator m_animator;
    private NavMeshAgent m_agent;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_agent = GetComponent<NavMeshAgent>();
    }
    private void Death()
    {
        m_agent.Stop();
        m_agent.enabled = false;
        m_animator.SetTrigger("Death");
        foreach (var item in particles)
        {
            item.Play();
        }
        StartCoroutine(DeathDelay());
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Car car))
            Death();
    }
    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(2f);
        Destroy(navaMeshAge.gameObject);
    }
}
