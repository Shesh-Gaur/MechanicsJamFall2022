using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindableObject : MonoBehaviour
{

    List<Vector3> myPositions = new List<Vector3>();
    List<Quaternion> myRotations = new List<Quaternion>();
    List<Vector3> myVelocities = new List<Vector3>();
    List<Vector3> myAngularVelocities = new List<Vector3>();
    public bool isRetroCausal = false;

    Rigidbody rb;
    Timer timeManager;

    Vector3 startPos;
    Quaternion startRot;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = FindObjectOfType<Timer>();
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        startRot = transform.rotation;
    }

    void Update()
    {
        if (timeManager.didTimeFlip)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

        // Update is called once per frame
    void FixedUpdate()
    {
        if (!isRetroCausal)
        {
            if (!timeManager.rewinding)
            {
                myPositions.Insert(0, transform.position);
                myRotations.Insert(0, transform.rotation);
                myVelocities.Insert(0, rb.velocity);
                myAngularVelocities.Insert(0, rb.angularVelocity);

            }
            else if (myPositions.Count > 1)
            {
                transform.position = myPositions[0];
                myPositions.RemoveAt(0);

                transform.rotation = myRotations[0];
                myRotations.RemoveAt(0);

                rb.velocity = myVelocities[0];
                myVelocities.RemoveAt(0);

                rb.angularVelocity = myAngularVelocities[0];
                myAngularVelocities.RemoveAt(0);
            }
            else if (myPositions.Count > 0)
            {
                transform.position = myPositions[0];

                transform.rotation = myRotations[0];

                rb.velocity = myVelocities[0];

                rb.angularVelocity = myAngularVelocities[0];
            }
            else
            {
                transform.position = startPos;
                transform.rotation = startRot;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
        else
        {
            if (timeManager.rewinding)
            {
                myPositions.Insert(0, transform.position);
                myRotations.Insert(0, transform.rotation);
                myVelocities.Insert(0, rb.velocity);
                myAngularVelocities.Insert(0, rb.angularVelocity);

            }
            else if (myPositions.Count > 1)
            {
                transform.position = myPositions[0];
                myPositions.RemoveAt(0);

                transform.rotation = myRotations[0];
                myRotations.RemoveAt(0);

                rb.velocity = myVelocities[0];
                myVelocities.RemoveAt(0);

                rb.angularVelocity = myAngularVelocities[0];
                myAngularVelocities.RemoveAt(0);
            }
            else if(myPositions.Count > 0)
            {
                transform.position = myPositions[0];

                transform.rotation = myRotations[0];

                rb.velocity = myVelocities[0];

                rb.angularVelocity = myAngularVelocities[0];
            }
            else
            {
                transform.position = startPos;
                transform.rotation = startRot;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
