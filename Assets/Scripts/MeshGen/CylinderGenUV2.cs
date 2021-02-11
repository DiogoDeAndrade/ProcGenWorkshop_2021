using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderGenUV2 : CylinderGenUV
{
    protected override void FillMesh(Mesh mesh)
    {
        base.FillMesh(mesh);

        mesh.RecalculateTangents();
    }
}
