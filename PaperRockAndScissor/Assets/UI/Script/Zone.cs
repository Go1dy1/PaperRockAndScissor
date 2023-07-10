using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class Zone : MonoBehaviour
{
    [SerializeField] private Image boundsImage;

    private void Update()
    {
        Vector3 position = transform.position;
        Vector3 boundsMin = boundsImage.rectTransform.rect.min + (Vector2)boundsImage.rectTransform.position;
        Vector3 boundsMax = boundsImage.rectTransform.rect.max + (Vector2)boundsImage.rectTransform.position;

        position.x = Mathf.Clamp(position.x, boundsMin.x, boundsMax.x);
        position.y = Mathf.Clamp(position.y, boundsMin.y, boundsMax.y);

        transform.position = position;
    }
}
