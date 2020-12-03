using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBoxManager : MonoBehaviour
{
    public GameObject conveyorPrefab;
    public GameObject automataPrefab;
    public GameObject FConveyorPrefab;

    public void AddConveyor()
    {
        if (TimeManager.isBuildMode == true)
        {
            Instantiate(conveyorPrefab, transform.position, Quaternion.Euler(-90f, 0f, 0f));
        }
    }

    public void AddAutomata()
    {
        if (TimeManager.isBuildMode == true)
        {
            Instantiate(automataPrefab, transform.position, Quaternion.Euler(-90f, 0f, 0f));
        }
    }

    public void AddFlippingConveyor()
    {
        if (TimeManager.isBuildMode == true)
        {
            Instantiate(FConveyorPrefab, transform.position, Quaternion.Euler(-90f, 0f, 0f));
        }
    }
}
