using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiMovement : MonoBehaviour
{
    private Transform samuraiTransform;
    private Vector3 initialForward;
    // private float smoothing = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            Input.compass.enabled = true;
        }
        Input.location.Start();
        samuraiTransform = GetComponent<Transform>();
        transform.rotation = Quaternion.Euler(0, -Input.compass.trueHeading, 0);
        initialForward = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation in case you want to use the gyroscope
        // Quaternion attitude = Input.gyro.attitude;

        // var rotator = attitude;
        // rotator *= Quaternion.Euler(0f, 0f, 180f);
        // rotator *= Quaternion.Euler(90f, 180f, 0f);

        // transform.rotation = Quaternion.Slerp(transform.rotation, rotator, smoothing);

        // Movement
        Vector3 acceleration = Input.acceleration;
        Vector3 movement = new (acceleration.x, 0, acceleration.y);
        transform.Translate(movement * Time.deltaTime, Space.World);
    }
}
