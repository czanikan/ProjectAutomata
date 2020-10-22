using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 2f;
    public float scrollSpeed;
    public float minY;
    public float maxY;

    void LateUpdate()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 input = new Vector3(Input.GetAxis("Horizontal"),  scroll, Input.GetAxis("Vertical"));

        input.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

        transform.Translate(input * speed * Time.deltaTime, Space.World);

        
    }

    
}
