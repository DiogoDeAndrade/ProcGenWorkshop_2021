using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadTextured : BaseMeshGenerator
{
    public float scale = 1.0f;

    protected override void FillMesh(Mesh mesh)
    {
        List<Vector3> positions = new List<Vector3>();
        List<Vector2> uv = new List<Vector2>();
        List<int>     indexes = new List<int>();

        positions.Add(new Vector3(-1, -1, 0));
        positions.Add(new Vector3(-1,  1, 0));
        positions.Add(new Vector3( 1,  1, 0));
        positions.Add(new Vector3( 1, -1, 0));

        uv.Add(new Vector2(0, scale));
        uv.Add(new Vector2(0, 0));
        uv.Add(new Vector2(scale, 0));
        uv.Add(new Vector2(scale, scale));

        indexes.Add(0);
        indexes.Add(1);
        indexes.Add(2);
        indexes.Add(0);
        indexes.Add(2);
        indexes.Add(3);

        mesh.SetVertices(positions);
        mesh.SetUVs(0, uv);
        mesh.SetIndices(indexes, MeshTopology.Triangles, 0, true);
    }
}
