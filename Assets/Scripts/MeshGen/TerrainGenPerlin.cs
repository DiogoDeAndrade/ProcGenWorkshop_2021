using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenPerlin : TerrainGen
{
    public float maxHeight = 2.0f;

    public Vector2 noiseScale = new Vector2(0.1f, 0.1f);

    protected override float GetHeight(float x, float y)
    {
        return maxHeight * Mathf.PerlinNoise(x * noiseScale.x, y * noiseScale.y);
    }

    private void Update()
    {
        UpdateMesh();
    }
}
