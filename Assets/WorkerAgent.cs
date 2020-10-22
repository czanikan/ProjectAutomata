using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class WorkerAgent : MonoBehaviour
{

    NavMeshAgent agent;
    public bool arrived = false;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        Transform target = FindTarget();

        if (Vector3.Distance(transform.position, target.position) <= 10)
        {
            arrived = true;
        }

        StartCoroutine(DoSomething(target));

    }

    IEnumerator DoSomething(Transform target)
    {
        target = FindTarget();
        while (!arrived && target != null)
        {
            agent.destination = target.position;
            
            yield return null;
        }


        if (arrived)
        {
            yield return new WaitForSeconds(5);
            arrived = false;
        }
    }

    Transform FindTarget()
    {
        Transform target = GameObject.FindGameObjectsWithTag("Automata")[Random.Range(0, GameObject.FindGameObjectsWithTag("Automata").Length)].transform;
        return target;
    }

}
