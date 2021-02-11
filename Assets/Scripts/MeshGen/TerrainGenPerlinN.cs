using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TerrainGenPerlinN : TerrainGen
{
    [System.Serializable]
    public struct NoiseLayer
    {
        public bool    enable;
        public float   amplitude;
        public Vector2 frequency;
    }

    [ReorderableList]
    public NoiseLayer[] layers;

    protected override float GetHeight(float x, float y)
    {
        float height = 0.0f;

        return height;
    }

    private void Update()
    {
        UpdateMesh();
    }
}
