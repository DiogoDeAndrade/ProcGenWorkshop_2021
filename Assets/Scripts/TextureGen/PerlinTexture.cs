using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTexture : TextureShader
{
    public float frequencyX = 1.0f;
    public float frequencyY = 1.0f;

    protected override Color GetColor(int x, int y)
    {
        return Color.black;
    }

/*    private void Update()
    {
        UpdateTexture();
    }*/
}
