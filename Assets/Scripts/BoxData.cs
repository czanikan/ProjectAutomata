using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxData : MonoBehaviour
{
    public string stamps = "";

    void Start()
    {
        stamps = "";
    }
    public void AddStamp(char stamp)
    {
        stamps += stamp;
    }
}
