using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public bool isBox = false;

    private Color mouseOverColor = Color.green;
    private Color originalColor = Color.white;
    private Color warningColor = Color.red;
    private Vector3 originalPos;
    public bool dragging = false;
    private bool isColliding = false;
    private float distance;

    void OnMouseEnter()
    {
        if (GetComponent<Renderer>())
            GetComponent<Renderer>().material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        if (GetComponent<Renderer>())
            GetComponent<Renderer>().material.color = originalColor;
    }

    void OnMouseDown()
    {
        originalPos = transform.position;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        
        if (!isColliding)
        {
            dragging = false;
            var currentPos = transform.position;
            transform.position = new Vector3(Mathf.Round(currentPos.x), 1f, Mathf.Round(currentPos.z));
            GetComponent<Renderer>().material.color = originalColor;
        }
        else
        {
            transform.position = originalPos;
        }
        
    }

    void Update()
    {
        if (dragging && TimeManager.isBuildMode == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(rayPoint.x, 2f, rayPoint.z);
            //GetComponent<Renderer>().material.color = mouseOverColor;

            if (Input.GetKeyDown(KeyCode.E))
            {
                Rotate(90);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Rotate(-90);
            }

            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Destroy(gameObject);
            }
        }
    }

    private void Rotate(int rotationAngle)
    {
        transform.Rotate(Vector3.forward * rotationAngle);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isBox && dragging)
        {
            isColliding = true;
            GetComponent<Renderer>().material.color = warningColor;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isBox && dragging)
        {
            isColliding = false;
            GetComponent<Renderer>().material.color = originalColor;
        }
            
    }
}

