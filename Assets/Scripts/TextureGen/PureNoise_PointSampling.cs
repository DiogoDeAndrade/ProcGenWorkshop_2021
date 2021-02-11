using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PureNoise_PointSampling : PureNoise
{
    public FilterMode filterMode;

    protected override void ProcessTexture(Texture2D texture)
    {
        base.ProcessTexture(texture);

        texture.filterMode = filterMode;
    }
}
