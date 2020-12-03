using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStateMachine : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject spawnPoint;

    private GameObject box;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SummonBox()
    {
        box = (GameObject) Instantiate(boxPrefab, spawnPoint.transform.position, Quaternion.identity);
    }

    public void DestroyBox()
    {
        Destroy(GameObject.FindGameObjectWithTag("Box").gameObject);
        //GameObject box = GameObject.FindGameObjectWithTag("Box");
        Destroy(box);
    }
}
