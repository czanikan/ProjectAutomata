using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public GameObject belt;
    public Transform endpoint;
    public float speed;
    public static bool isActive = true;


    private void OnTriggerStay(Collider other)
    {
        if (isActive)
        {
            // crate current position: other.transform.position
            other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
        }
        
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
