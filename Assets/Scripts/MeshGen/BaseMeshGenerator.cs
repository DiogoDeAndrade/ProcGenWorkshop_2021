using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMeshGenerator : MonoBehaviour
{
    public Material material;

    MeshRenderer meshRenderer;
    MeshFilter   meshFilter;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            meshFilter = gameObject.AddComponent<MeshFilter>();
        }

        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            meshRenderer = gameObject.AddComponent<MeshRenderer>();
        }

        meshRenderer.material = material;

        UpdateMesh();
    }

    protected void UpdateMesh()
    {
        if (meshFilter == null) return;
        if (meshRenderer == null) return;

        Mesh mesh = new Mesh();
        mesh.name = "Generated Mesh";

        FillMesh(mesh);

        mesh.UploadMeshData(true);

        meshFilter.mesh = mesh;
    }

    protected virtual void FillMesh(Mesh mesh)
    {
        List<Vector3> positions = new List<Vector3>();
        List<int>     indexes = new List<int>();

        positions.Add(new Vector3(-1, 0, 0));
        positions.Add(new Vector3( 0, 1, 0));
        positions.Add(new Vector3( 1, 0, 0));

        indexes.Add(0);
        indexes.Add(1);
        indexes.Add(2);

        mesh.SetVertices(positions);
        mesh.SetIndices(indexes, MeshTopology.Triangles, 0, true);
    }
}
