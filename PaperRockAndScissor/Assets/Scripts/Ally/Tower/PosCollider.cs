using UnityEngine;
using UnityEngine.Serialization;

public class PosCollider : MonoBehaviour
{
 [FormerlySerializedAs("clickAreaCollider")] public Collider _clickAreaCollider;
 public static bool AccsesPoint = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == _clickAreaCollider)AccsesPoint= true;
                else AccsesPoint= false;
                    
                
            }
        }
    }
}
