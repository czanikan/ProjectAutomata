using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructurePlaceing : MonoBehaviour
{
    public bool multiPlaceable = false;

    RaycastHit hit;
    Vector3 movePos;
    public GameObject prefab;
    private float distance;
    private bool isColliding = false;
    private Color originalColor = new Color32(50, 240, 255, 255);
    private Color warningColor = Color.red;

    void Start()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);

        transform.position = new Vector3(rayPoint.x, 2f, rayPoint.z);

    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);

        transform.position = new Vector3(rayPoint.x, 2f, rayPoint.z);

        if (!multiPlaceable)
        {
            if (Input.GetMouseButtonDown(0) && !isColliding && TimeManager.isBuildMode == true)
            {
                var currentPos = transform.position;
                Instantiate(prefab, new Vector3(Mathf.Round(currentPos.x), 1f, Mathf.Round(currentPos.z)), transform.rotation);
                Destroy(gameObject);
            }
        } else
        {
            if (Input.GetMouseButton(0) && !isColliding && TimeManager.isBuildMode == true)
            {
                var currentPos = transform.position;
                Instantiate(prefab, new Vector3(Mathf.Round(currentPos.x)+1, 1f, Mathf.Round(currentPos.z)+1), transform.rotation);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Destroy(gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Rotate(90);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Rotate(-90);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
        }

    }

    private void Rotate(int rotationAngle)
    {
        transform.Rotate(Vector3.forward * rotationAngle);
    }

    private void OnTriggerStay(Collider other)
    {
        isColliding = true;
        this.GetComponent<Renderer>().material.color = warningColor;
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
        this.GetComponent<Renderer>().material.color = originalColor;
    }
}
