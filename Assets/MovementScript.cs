using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{
    Rigidbody rBody;
    Vector3[] crossPoints = new Vector3[0];

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        rBody.freezeRotation = true;
        rBody.isKinematic = true;
    }

    void Update()
    {
        if (crossPoints.Length == 0) return;

        if (Vector3.Distance(transform.position, crossPoints[0]) < 0.1f)
        {
            crossPoints = crossPoints.Skip(1).ToArray();
        }
        else
        {
            transform.LookAt(crossPoints[0]);
            Vector3 moveVect = crossPoints[0] - transform.position;
            moveVect.Normalize();
            moveVect *= 16.0f * Time.deltaTime;
            rBody.MovePosition(transform.position + moveVect);
        }
    }

    public void RunPath(Vector3 destination)
    {
        NavMeshPath path = new NavMeshPath();
        if (NavMesh.CalculatePath(transform.position, destination, -1, path))
        {
            crossPoints = path.corners;
            for (int i = 0; i < crossPoints.Length; ++i)
            {
                crossPoints[i] = new Vector3(crossPoints[i].x, 1, crossPoints[i].z);
            }
        }
    }
}
