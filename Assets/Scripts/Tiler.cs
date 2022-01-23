using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiler : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void FixedUpdate()
    {
        _meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(_meshRenderer.sharedMaterial.GetTextureOffset("_MainTex").x+0.001f, 0));
    }
}
