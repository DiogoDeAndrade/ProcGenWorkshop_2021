using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTextureRadial : TextureShader
{
    public float frequencyX = 1.0f;
    public float frequencyY = 1.0f;

    public float offset;

    public Gradient gradient;

    protected override Color GetColor(int x, int y)
    {
        float v = 0;

        float cx = width / 2;
        float cy = height / 2;

        float dx = x - cx;
        float dy = y - cy;

        float dist = Mathf.Sqrt(dx * dx + dy * dy);

        dx /= dist;
        dy /= dist;

        float ang = Mathf.Atan2(dy, dx);

        float radius = 70 + 50 * Mathf.PerlinNoise(ang * frequencyX, offset * frequencyY);

        if (dist < radius)
        {
            return gradient.Evaluate(dist / radius);
        }

        return Color.black;
/*
        dx /= dist;
        dy /= dist;

        float ang = Mathf.Atan2(dy, dx);

        v = v + Mathf.PerlinNoise(dist * frequencyX, ang * frequencyY);

        v = Mathf.Clamp01(v);

        return new Color(v,v,v,1);*/
    }

    private void Update()
    {
        UpdateTexture();
    }
}
