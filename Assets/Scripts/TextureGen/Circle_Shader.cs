using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Shader : TextureShader
{
    public float radius = 10;

    protected override Color GetColor(int x, int y)
    {
        float cx = width / 2;
        float cy = height / 2;

        float dist = Mathf.Sqrt((x - cx) * (x - cx) + (y - cy) * (y - cy));
        if (Mathf.Abs(dist - radius) < 2)
        {
            return Color.cyan;
        }

        return Color.black;
    }

    private void Update()
    {
        UpdateTexture();
    }
}
