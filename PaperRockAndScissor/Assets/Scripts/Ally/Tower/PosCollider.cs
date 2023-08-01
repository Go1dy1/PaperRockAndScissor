using UnityEngine;

public class PosCollider : MonoBehaviour
{
    [SerializeField] private Collider _clickAreaCollider;
    public static bool AccsesPoint { get; private set; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Camera.main != null)
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
}
