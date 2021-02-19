using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadGen : BaseMeshGenerator
{
    protected override void FillMesh(Mesh mesh)
    {
        List<Vector3> positions = new List<Vector3>();
        List<int>     indices = new List<int>();

        positions.Add(new Vector3(-1, -1, 0));
        positions.Add(new Vector3(-1,  1, 0));
        positions.Add(new Vector3( 1,  1, 0));
        positions.Add(new Vector3( 1, -1, 0));

        indices.Add(0);
        indices.Add(1);
        indices.Add(2);
        indices.Add(0);
        indices.Add(2);
        indices.Add(3);

        mesh.SetVertices(positions);
        mesh.SetIndices(indices, MeshTopology.Triangles, 0, true);
    }
}
