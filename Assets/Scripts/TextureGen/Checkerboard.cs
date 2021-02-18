using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkerboard : BaseTextureGenerator
{
    public Color color1 = Color.yellow;
    public Color color2 = Color.red;
    [Range(1, 32)]
    public int gridSize = 8;

    protected override void ProcessTexture(Texture2D texture)
    {
        base.ProcessTexture(texture);

        texture.filterMode = FilterMode.Point;
    }

    protected override void FillTexture(Color[] colors)
    {
        base.FillTexture(colors);

        float cellWidth = width / gridSize;
        float cellHeight = height / gridSize;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float cellX = Mathf.FloorToInt(x / cellWidth);
                float cellY = Mathf.FloorToInt(y / cellHeight);

                Color color;
                if (Mathf.RoundToInt(cellX + cellY) % 2 == 0) color = color1;
                else color = color2;

                int index = y * width + x;
                colors[index] = color;
            }
        }
    }

    private void Update()
    {
        UpdateTexture();
    }
}
