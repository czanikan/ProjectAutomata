using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampMachine : MonoBehaviour
{
    public float speed = 2;
    public Transform endpoint;
    public enum colorType {Red, Blue};
    public colorType ct;
    Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        ct = colorType.Red;
    }

    void Update()
    {
        if(GetComponent<DragObject>().dragging)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                if(ct == colorType.Red)
                {
                    ct = colorType.Blue;
                    renderer.materials[2].SetColor("_Color", Color.blue);
                }
                else
                {
                    ct = colorType.Red;
                    renderer.materials[2].SetColor("_Color", Color.red);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ct == colorType.Red)
        {
            other.GetComponent<BoxData>().AddStamp('r');
        }
        else
        {
            other.GetComponent<BoxData>().AddStamp('b');
        }
    }
}
