using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenNormals1 : CubeGen
{
    protected override void FillMesh(Mesh mesh)
    {
        base.FillMesh(mesh);

        mesh.RecalculateNormals();
    }
}
