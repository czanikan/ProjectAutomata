using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlippingConveyor : MonoBehaviour
{
    public GameObject belt;
    public GameObject endpoint;
    public float speed;
    public static bool isActive = true;


    private void OnTriggerStay(Collider other)
    {
        if (isActive)
        {
            // crate current position: other.transform.position
            other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.transform.position, speed * Time.deltaTime);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Box"))
        {
            this.transform.Rotate(0, 0, 180);
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
