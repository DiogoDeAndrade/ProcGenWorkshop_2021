using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTexture : TextureShader
{
    public float frequencyX = 1.0f;
    public float frequencyY = 1.0f;
    public bool  firstLayer;
    public bool  secondLayer;
    public bool  thirdLayer;
    public bool  forthLayer;
    public Vector2 offset1;
    public Vector2 offset2;
    public Vector2 offset3;
    public Vector2 offset4;

    protected override Color GetColor(int x, int y)
    {
        float v = 0;

        if (firstLayer)
        {
            v = v + 0.25f * Mathf.PerlinNoise(x * frequencyX + offset1.x, y * frequencyY + offset1.y);
        }

        if (secondLayer)
        {
            v = v + 0.25f * Mathf.PerlinNoise(x * frequencyX  + offset2.x, y * frequencyY  + offset2.y);
        }

        if (thirdLayer)
        {
            v = v + 0.25f * Mathf.PerlinNoise(x * frequencyX  + offset3.x, y * frequencyY  + offset3.y);
        }

        if (forthLayer)
        {
            v = v + 0.25f * Mathf.PerlinNoise(x * frequencyX  + offset4.x, y * frequencyY  + offset4.y);
        }

        v = Mathf.Clamp01(v);

        return new Color(v,v,v,1);
    }

    private void Update()
    {
        offset1.x += Time.deltaTime * 0.05f;
        offset2.x += Time.deltaTime * 0.10f;
        offset3.x += Time.deltaTime * 0.20f;
        offset4.x += Time.deltaTime * 1;

        UpdateTexture();
    }
}
