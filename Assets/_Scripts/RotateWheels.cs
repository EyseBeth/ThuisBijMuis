using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * this is part of the wheel animation on page 2
 * */
public class RotateWheels : MonoBehaviour
{
    public float rotateSpeed = 10f;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * -rotateSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
