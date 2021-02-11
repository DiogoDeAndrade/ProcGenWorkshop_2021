using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenNoise : TerrainGen
{
    public float maxHeight = 2.0f;

    protected override float GetHeight(float x, float y)
    {
        return Random.Range(0.0f, maxHeight);
    }
}
