using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MaterialMover : MonoBehaviour
{

    [FormerlySerializedAs("scrollSpeed")] public float _scrollSpeed = 0.5F;
    [FormerlySerializedAs("rend")] public Renderer _rend;
    void Start()
    {
        _rend = GetComponent<Renderer>();
    }
    void Update()
    {
        float offset = Time.time * _scrollSpeed;
        _rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}