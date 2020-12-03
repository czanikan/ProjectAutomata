using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class EndStateMachine : MonoBehaviour
{
    public Transform returnPoint;
    public Transform checkPoint;
    public Transform toCheckPoint;
    public Transform toReturnPoint;
    public float speed = 2;
    private string boxString;
    private bool returning = false;
    public GameManager gm;
    public string task;
    
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
        if(!returning && Vector3.Distance(other.transform.position, checkPoint.transform.position) > 0.01f)
        {
            if (Vector3.Distance(other.transform.position, toCheckPoint.transform.position) > 0.01f)
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, toCheckPoint.position, speed * Time.deltaTime);
            }
            else
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, checkPoint.position, speed * Time.deltaTime);
            }

            if (Regex.IsMatch(boxString, task, RegexOptions.IgnoreCase) && gm.GetComponent<GameManager>().isComplete == false)
            {
                Debug.Log("Complete! :3");
                gm.GetComponent<GameManager>().isComplete = true;
            }
            else
            {
                Debug.Log("return to destination");
                returning = true;
            }
        }
        if(returning)
        {
            if(Vector3.Distance(other.transform.position, toReturnPoint.transform.position) > 1f)
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, toReturnPoint.position, speed * Time.deltaTime);
            }
            else
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, returnPoint.position, speed * Time.deltaTime);
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        returning = false;
    }
}
