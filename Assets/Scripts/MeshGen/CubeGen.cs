using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGen : BaseMeshGenerator
{
    public Vector3 size = Vector3.one;

    protected override void FillMesh(Mesh mesh)
    {
        List<Vector3> positions = new List<Vector3>();
        List<int>     indexes = new List<int>();

        positions.Add(new Vector3(-size.x, -size.y, -size.z));
        positions.Add(new Vector3(-size.x,  size.y, -size.z));
        positions.Add(new Vector3( size.x,  size.y, -size.z));
        positions.Add(new Vector3( size.x, -size.y, -size.z));
        positions.Add(new Vector3(-size.x, -size.y,  size.z));
        positions.Add(new Vector3(-size.x,  size.y,  size.z));
        positions.Add(new Vector3( size.x,  size.y,  size.z));
        positions.Add(new Vector3( size.x, -size.y,  size.z));

        indexes.Add(0); indexes.Add(1); indexes.Add(2);
        indexes.Add(0); indexes.Add(2); indexes.Add(3);
        indexes.Add(3); indexes.Add(2); indexes.Add(6);
        indexes.Add(3); indexes.Add(6); indexes.Add(7);
        indexes.Add(7); indexes.Add(6); indexes.Add(5);
        indexes.Add(7); indexes.Add(5); indexes.Add(4);
        indexes.Add(4); indexes.Add(5); indexes.Add(1);
        indexes.Add(4); indexes.Add(1); indexes.Add(0);
        indexes.Add(1); indexes.Add(5); indexes.Add(6);
        indexes.Add(1); indexes.Add(6); indexes.Add(2);
        indexes.Add(7); indexes.Add(0); indexes.Add(3);
        indexes.Add(7); indexes.Add(4); indexes.Add(0);

        mesh.SetVertices(positions);
        mesh.SetIndices(indexes, MeshTopology.Triangles, 0, true);
    }
}
