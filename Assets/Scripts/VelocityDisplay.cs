using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VelocityDisplay : MonoBehaviour
{
    Rigidbody controller;
    void Start()
    {
        controller = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 horizontalVelocity = controller.velocity;
        Vector3 verticalVelocity = controller.velocity;
        horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);
        verticalVelocity = new Vector3(0, controller.velocity.y, 0);
        // The speed on the x-z plane ignoring any speed
        float horizontalSpeed = horizontalVelocity.magnitude;
        // The speed from gravity or jumping
        float verticalSpeed = controller.velocity.y;
        // The overall speed
        float overallSpeed = controller.velocity.magnitude;

        Debug.Log(verticalSpeed); 
    }
}