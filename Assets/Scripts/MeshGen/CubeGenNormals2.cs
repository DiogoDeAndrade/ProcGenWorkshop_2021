using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenNormals2 : BaseMeshGenerator
{
    public Vector3 size = Vector3.one;

    protected override void FillMesh(Mesh mesh)
    {
        List<Vector3> positions = new List<Vector3>();
        List<Vector3> normals = new List<Vector3>();
        List<int>     indexes = new List<int>();

        // -Z face
        positions.Add(new Vector3(-size.x, -size.y, -size.z)); normals.Add(-Vector3.forward);
        positions.Add(new Vector3(-size.x,  size.y, -size.z)); normals.Add(-Vector3.forward);
        positions.Add(new Vector3( size.x,  size.y, -size.z)); normals.Add(-Vector3.forward);
        positions.Add(new Vector3( size.x, -size.y, -size.z)); normals.Add(-Vector3.forward);

        indexes.Add(0); indexes.Add(1); indexes.Add(2);
        indexes.Add(0); indexes.Add(2); indexes.Add(3);

        // +X face
        positions.Add(new Vector3(size.x, -size.y, -size.z)); normals.Add(Vector3.right);
        positions.Add(new Vector3(size.x,  size.y, -size.z)); normals.Add(Vector3.right);
        positions.Add(new Vector3(size.x,  size.y,  size.z)); normals.Add(Vector3.right);
        positions.Add(new Vector3(size.x, -size.y,  size.z)); normals.Add(Vector3.right);

        indexes.Add(4); indexes.Add(5); indexes.Add(6);
        indexes.Add(4); indexes.Add(6); indexes.Add(7);

        // -Z face
        positions.Add(new Vector3(-size.x, -size.y, size.z)); normals.Add(Vector3.forward);
        positions.Add(new Vector3( size.x, -size.y, size.z)); normals.Add(Vector3.forward);
        positions.Add(new Vector3( size.x,  size.y, size.z)); normals.Add(Vector3.forward);
        positions.Add(new Vector3(-size.x,  size.y, size.z)); normals.Add(Vector3.forward);

        indexes.Add(8); indexes.Add(9); indexes.Add(10);
        indexes.Add(8); indexes.Add(10); indexes.Add(11);

        // -X face
        positions.Add(new Vector3(-size.x, -size.y, -size.z)); normals.Add(-Vector3.right);
        positions.Add(new Vector3(-size.x, -size.y,  size.z)); normals.Add(-Vector3.right);
        positions.Add(new Vector3(-size.x,  size.y,  size.z)); normals.Add(-Vector3.right);
        positions.Add(new Vector3(-size.x,  size.y, -size.z)); normals.Add(-Vector3.right);

        indexes.Add(12); indexes.Add(13); indexes.Add(14);
        indexes.Add(12); indexes.Add(14); indexes.Add(15);

        // +Y face
        positions.Add(new Vector3(-size.x, size.y, -size.z)); normals.Add(Vector3.up);
        positions.Add(new Vector3(-size.x, size.y,  size.z)); normals.Add(Vector3.up);
        positions.Add(new Vector3( size.x, size.y,  size.z)); normals.Add(Vector3.up);
        positions.Add(new Vector3( size.x, size.y, -size.z)); normals.Add(Vector3.up);

        indexes.Add(16); indexes.Add(17); indexes.Add(18);
        indexes.Add(16); indexes.Add(18); indexes.Add(19);

        // -Y face
        positions.Add(new Vector3(-size.x, -size.y, -size.z)); normals.Add(-Vector3.up);
        positions.Add(new Vector3( size.x, -size.y, -size.z)); normals.Add(-Vector3.up);
        positions.Add(new Vector3( size.x, -size.y,  size.z)); normals.Add(-Vector3.up);
        positions.Add(new Vector3(-size.x, -size.y,  size.z)); normals.Add(-Vector3.up);

        indexes.Add(20); indexes.Add(21); indexes.Add(22);
        indexes.Add(20); indexes.Add(22); indexes.Add(23);

        mesh.SetVertices(positions);
        mesh.SetNormals(normals);
        mesh.SetIndices(indexes, MeshTopology.Triangles, 0, true);
    }
}
