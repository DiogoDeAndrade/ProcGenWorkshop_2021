using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PureNoise : BaseTextureGenerator
{
    public int      seed;
    public bool     gaussian;
    [Range(0.0f, 1.0f)]
    public float    mean = 0.5f;
    [Range(0.0f, 1.0f)]
    public float    stdDev = 0.5f;

    protected override void FillTexture(Color[] colors)
    {
        var rnd = new System.Random(seed);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int index = y * width + x;

                float r;
                if (gaussian)
                    r = Mathf.Clamp01(rnd.Gaussian(mean, stdDev / 0.3f));
                else
                    r = rnd.Range(0.0f, 1.0f);
                colors[index] = new Color(r,r,r,1);
            }
        }
    }

    void Update()
    {
        UpdateTexture();
    }
}
