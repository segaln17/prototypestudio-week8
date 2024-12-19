using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfTiltLeft : MonoBehaviour
{
    public Rigidbody rbLeft;
    //public Rigidbody rbRight;

    private Vector3 left_EulerAngleVelocity;
    //private Vector3 right_EulerAngleVelocity;
    
    // Start is called before the first frame update
    void Start()
    {
        rbLeft = GetComponent<Rigidbody>();
        //rbRight = GetComponent<Rigidbody>();

        left_EulerAngleVelocity = new Vector3(0, 0, 15);
        //right_EulerAngleVelocity = new Vector3(0, 0, 15);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion deltaRotation = Quaternion.Euler(left_EulerAngleVelocity * Time.fixedDeltaTime);
            rbLeft.MoveRotation(rbLeft.rotation * deltaRotation);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Quaternion deltaRotation = Quaternion.Euler(-left_EulerAngleVelocity * Time.fixedDeltaTime);
            rbLeft.MoveRotation(rbLeft.rotation * deltaRotation);
        }

        /*
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Quaternion deltaRotation = Quaternion.Euler(-right_EulerAngleVelocity * Time.fixedDeltaTime);
            rbRight.MoveRotation(rbRight.rotation * deltaRotation);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Quaternion deltaRotation = Quaternion.Euler(right_EulerAngleVelocity * Time.fixedDeltaTime);
            rbRight.MoveRotation(rbRight.rotation * deltaRotation);
        }
        */
    }
}
