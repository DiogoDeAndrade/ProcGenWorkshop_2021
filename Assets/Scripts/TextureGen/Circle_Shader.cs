using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Shader : TextureShader
{
    public float radius = 10;

    protected override Color GetColor(int x, int y)
    {
        return Color.black;
    }
}
