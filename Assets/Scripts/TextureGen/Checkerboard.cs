using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkerboard : BaseTextureGenerator
{
    public Color color1 = Color.yellow;
    public Color color2 = Color.red;
    [Range(1, 32)]
    public int gridSize = 8;

    protected override void FillTexture(Color[] colors)
    {
        base.FillTexture(colors);

        
    }
}
