using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWave : BaseTextureGenerator
{
    [Range(0.0f, 1.0f)]
    public float amplitude = 1.0f;
    public float frequency = 2.0f;

    protected override void FillTexture(Color[] colors)
    {
        for (int i = 0; i < width * height; i++)
        {
            colors[i] = Color.black;
        }

        for (int x = 0; x < width; x++)
        {
            float normalizedX = (float)x / width;
            float s = Mathf.Sin(normalizedX * Mathf.PI * frequency);
            int   y = Mathf.FloorToInt((height / 2) + s * (height / 2) * amplitude);
            if ((y >= 0) && (y < height))
            {
                int index = y * width + x;
                colors[index] = Color.green;
            }
        }
    }
}
