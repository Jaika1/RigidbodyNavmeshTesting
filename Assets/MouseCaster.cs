using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCaster : MonoBehaviour
{
    public MovementScript MS;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit rh;
            if (Physics.Raycast(r, out rh))
            {
                MS.RunPath(rh.point);
            }
        }
    }
}
