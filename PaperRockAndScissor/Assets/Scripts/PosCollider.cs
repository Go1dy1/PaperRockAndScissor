using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosCollider : MonoBehaviour
{
 public Collider clickAreaCollider;
 public static bool AccsesPoint = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == clickAreaCollider)
                {
                    AccsesPoint= true;
                    Debug.Log("True");
                }
                else
                {
                    AccsesPoint= false;
                    Debug.Log("False");
                }
            }
        }
    }
}
