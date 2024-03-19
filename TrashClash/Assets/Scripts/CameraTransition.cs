using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public Transform target; // The target to rotate around (e.g., the game board)
    public float rotationSpeed = 1.0f; // Speed of rotation
    public float zoomSpeed = 1.0f; // Speed of zoom
    public float zoomOutDistance = 10.0f; // Distance to zoom out
    public float zoomInDistance = 5.0f; // Distance to zoom in

    private Vector3 offset; // Offset between camera and target
    private bool isRotating = false; // Flag to track rotation state
    private int zValue = 0;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isRotating)
        {
            StartCoroutine(RotateCamera());
        }
    }

    IEnumerator RotateCamera()
    {
        isRotating = true;

        // Store initial camera position and rotation
        Vector3 initialPosition = transform.position;
        Quaternion initialRotation = transform.rotation;

        // Smoothly zoom out
        float t = 0;
        while (t < 1.0f)
        {
            t += Time.deltaTime * zoomSpeed;
            transform.position = Vector3.Lerp(initialPosition, target.position + offset - transform.forward * zoomOutDistance, t);
            yield return null;
        }

        // Smoothly rotate camera
        zValue += 180;
        Quaternion targetRotation = Quaternion.Euler(0, 0, zValue); // Example rotation (90 degrees around Z-axis)
        t = 0;
        while (t < 1.0f)
        {
            t += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, t);
            yield return null;
        }

        // Smoothly zoom in
        t = 0;
        while (t < 1.0f)
        {
            t += Time.deltaTime * zoomSpeed;
            transform.position = Vector3.Lerp(transform.position, target.position + offset - transform.forward * zoomInDistance, t);
            yield return null;
        }

        isRotating = false;
    }
}




