using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureShader : BaseTextureGenerator
{
    public FilterMode filterMode;

    void Start()
    {
        UpdateTexture();
    }

    protected override void FillTexture(Color[] colors)
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                colors[x + y * width] = GetColor(x, y);
            }
        }
    }

    protected virtual Color GetColor(int x, int y)
    {
        return Color.magenta;
    }

    protected override void ProcessTexture(Texture2D texture)
    {
        base.ProcessTexture(texture);

        texture.filterMode = filterMode;
    }

}
