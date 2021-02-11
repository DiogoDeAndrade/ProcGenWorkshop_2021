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
        int sizeX = width / gridSize;
        int sizeY = height / gridSize;

        int condition = (((x / sizeX) + (y / sizeY)) % 2);

        if (condition == 0)
            return color1;

        return color2;
    }
}
