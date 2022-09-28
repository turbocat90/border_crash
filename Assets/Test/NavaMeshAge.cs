using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavaMeshAge : MonoBehaviour
{
    [SerializeField] private float Radius;
    [SerializeField] private NavMeshAgent m_agent;
 
    private Vector3 m_target;

    void Start()
    {
        FindeNewTarget();
    }


    void Update()
    {
        if(Vector3.Distance(m_agent.transform.position, m_target) < 0.3f)
                FindeNewTarget();
    }
    private void FindeNewTarget()
    {
        m_target = GetRandomPoint();
        m_agent.SetDestination(m_target);
    }
    public Vector3 GetRandomPoint()
    {
        Vector3 randomPos = Random.insideUnitSphere * Radius + transform.position;
        Vector3 pos = new Vector3(randomPos.x, 0, randomPos.z);
        return pos;
    }
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(m_agent.transform.position, m_target);
    }
}
