using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStateMachine : MonoBehaviour
{
    public Transform returnpoint;
    public Transform checkpoint;
    public float speed = 2;
    private string boxString;
    private bool returning = false;
    
    void Start()
    {
        returning = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Im on my waaay");
        boxString = other.GetComponent<BoxData>().stamps;
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(!returning && Vector3.Distance(other.transform.position, checkpoint.transform.position) > 0.01f)
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, checkpoint.position, speed * Time.deltaTime);
            if (boxString == "rbrbrb")
            {
                Debug.Log("Complete! :3");
            }
            else
            {
                Debug.Log("return to destination");
                returning = true;
            }
        }
        if(returning)
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, returnpoint.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        returning = false;
    }
}
