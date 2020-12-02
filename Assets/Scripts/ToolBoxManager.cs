using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBoxManager : MonoBehaviour
{
    public GameObject conveyorPrefab;
    public GameObject automataPrefab;
    public GameObject FConveyorPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddConveyor()
    {
        Instantiate(conveyorPrefab, transform.position, Quaternion.Euler(-90f, 0f, 0f));
    }

    public void AddAutomata()
    {
        Instantiate(automataPrefab, transform.position, Quaternion.Euler(-90f, 0f, 0f));
    }

    public void AddFlippingConveyor()
    {
        Instantiate(FConveyorPrefab, transform.position, Quaternion.Euler(-90f, 0f, 0f));
    }
}
