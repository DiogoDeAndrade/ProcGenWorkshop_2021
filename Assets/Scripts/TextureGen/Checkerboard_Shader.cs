using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkerboard_Shader : TextureShader
{
    public Color color1 = Color.yellow;
    public Color color2 = Color.red;
    [Range(1, 32)]
    public int gridSize = 8;

    protected override Color GetColor(int x, int y)
    {
        float cellWidth = width / gridSize;
        float cellHeight = height / gridSize;

        float cellX = Mathf.FloorToInt(x / cellWidth);
        float cellY = Mathf.FloorToInt(y / cellHeight);

        if (Mathf.RoundToInt(cellX + cellY) % 2 == 0) return color1;
        else return color2;
    }

    void Update()
    {
        UpdateTexture();
    }
}
