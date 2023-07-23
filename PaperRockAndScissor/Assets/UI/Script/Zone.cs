using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[ExecuteAlways]
public class Zone : MonoBehaviour
{
    [FormerlySerializedAs("boundsImage")] [SerializeField] private Image _boundsImage;

    private void Update()
    {
        Vector3 position = transform.position;
        Vector3 boundsMin = _boundsImage.rectTransform.rect.min + (Vector2)_boundsImage.rectTransform.position;
        Vector3 boundsMax = _boundsImage.rectTransform.rect.max + (Vector2)_boundsImage.rectTransform.position;

        position.x = Mathf.Clamp(position.x, boundsMin.x, boundsMax.x);
        position.y = Mathf.Clamp(position.y, boundsMin.y, boundsMax.y);

        transform.position = position;
    }
}
