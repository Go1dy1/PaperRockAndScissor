using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteAlways]
public class Zone : MonoBehaviour
{
        public Image boundsImage;

    void Update () {
        Vector3 pos = transform.position;
        Vector3 boundsMin = boundsImage.rectTransform.rect.min + (Vector2)boundsImage.rectTransform.position;
        Vector3 boundsMax = boundsImage.rectTransform.rect.max + (Vector2)boundsImage.rectTransform.position;

        pos.x = Mathf.Clamp(pos.x, boundsMin.x, boundsMax.x);
        pos.y = Mathf.Clamp(pos.y, boundsMin.y, boundsMax.y);
        transform.position = pos;
}
}