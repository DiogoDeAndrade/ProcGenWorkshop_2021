using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTextureGenerator : MonoBehaviour
{
    [Range(2, 8192)]
    public int width = 256;
    [Range(2, 8192)]
    public int height = 256;

    void Start()
    {
        UpdateTexture();
    }

    protected void UpdateTexture()
    { 
        Color[]   colors = new Color[width * height];

        FillTexture(colors);

        Texture2D texture = new Texture2D(width, height, TextureFormat.RGBA32, true);
        texture.SetPixels(colors);
        ProcessTexture(texture);
        texture.Apply(true, true);

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer)
        {
            Material material = new Material(meshRenderer.material);

            material.SetTexture("_MainTex", texture);

            meshRenderer.material = material;
        }        
    }

    protected virtual void ProcessTexture(Texture2D texture)
    {

    }

    protected virtual void FillTexture(Color[] colors)
    {
        for (int i = 0; i < width * height; i++)
        {
            colors[i] = Color.red;
        }
    }
}
