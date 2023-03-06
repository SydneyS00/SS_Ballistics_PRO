using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Frog : MonoBehaviour
{
    public GameObject target;
    public float launchForce = 10f;
    Rigidbody rb;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            FiringSolution fs = new FiringSolution();
            // determine the firing angle to hit a given location with a given muzzle velocity
            Nullable<Vector3> aimVector = fs.AngleForTargeting(transform.position, target.transform.position, launchForce, Physics.gravity);
            if (aimVector.HasValue)
            {
                rb.AddForce(aimVector.Value.normalized * launchForce, ForceMode.VelocityChange);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.isKinematic = true;
            transform.position = startPos;
            rb.isKinematic = false;
        }
    }
}
