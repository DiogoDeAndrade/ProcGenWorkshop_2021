using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderGenUV : BaseMeshGenerator
{
    public float    height = 1.0f;
    public float    radius = 0.25f;
    public int      subdivisions = 8;
    public float    noiseAmplitude;
    public Vector2  noiseFrequency;

    protected override void FillMesh(Mesh mesh)
    {
        List<Vector3>   positions = new List<Vector3>();
        List<Vector2>   uv = new List<Vector2>();
        List<int>       indexes = new List<int>();

        float uInc = 1.0f / subdivisions;
        float u = 0.0f;
        float angleInc = (Mathf.PI * 2.0f) * uInc;
        float angle = 0.0f;

        for (int i = 0; i <= subdivisions; i++)
        {
            Vector3 p1 = new Vector3(radius * Mathf.Cos(angle), 0.0f, radius * Mathf.Sin(angle));
            Vector3 p2 = p1 + Vector3.up * height;

            positions.Add(p1); uv.Add(new Vector2(u, 1.0f));
            positions.Add(p2); uv.Add(new Vector2(u, 0.0f));

            angle += angleInc;
            u += uInc;
        }

        for (int i = 0; i < subdivisions; i++)
        {
            indexes.Add(i * 2); indexes.Add(i * 2 + 1); indexes.Add((i + 1) * 2 + 1);
            indexes.Add(i * 2); indexes.Add((i + 1) * 2 + 1); indexes.Add((i + 1) * 2);
        }

        // Bottom cap
        positions.Add(Vector3.zero); uv.Add(new Vector2(0.5f, 1.0f));
        int bottomIndex = positions.Count - 1;

        angle = 0.0f;
        u = 0.0f;
        for (int i = 0; i <= subdivisions; i++)
        {
            Vector3 p = new Vector3(radius * Mathf.Cos(angle), 0.0f, radius * Mathf.Sin(angle));
            Vector2 uvCoord = new Vector2(0.5f * Mathf.Cos(angle) + 0.5f, 0.5f * Mathf.Sin(angle) + 0.5f);

            positions.Add(p); uv.Add(uvCoord);

            angle += angleInc;
            u += uInc;
        }

        for (int i = 0; i < subdivisions; i++)
        { 
            indexes.Add(bottomIndex);
            indexes.Add(bottomIndex + i + 1);
            indexes.Add(bottomIndex + i + 1 + 1);
        }

        positions.Add(Vector3.up * height); uv.Add(new Vector2(0.5f, 0.5f));
        int topIndex = positions.Count - 1;

        angle = 0.0f;
        u = 0.0f;
        for (int i = 0; i <= subdivisions; i++)
        {
            Vector3 p = new Vector3(radius * Mathf.Cos(angle), height, radius * Mathf.Sin(angle));
            Vector2 uvCoord = new Vector2(0.5f * Mathf.Cos(angle) + 0.5f, 0.5f * Mathf.Sin(angle) + 0.5f);

            positions.Add(p); uv.Add(uvCoord);

            angle += angleInc;
            u += uInc;
        }

        for (int i = 0; i < subdivisions; i++)
        { 
            indexes.Add(topIndex);
            indexes.Add(topIndex + i + 1 + 1);
            indexes.Add(topIndex + i + 1);
        }

        mesh.SetVertices(positions);
        mesh.SetUVs(0, uv);
        mesh.SetIndices(indexes, MeshTopology.Triangles, 0, true);

        mesh.RecalculateNormals();

        List<Vector3> normals = new List<Vector3>();
        mesh.GetNormals(normals);

        normals[0] = Vector3.right;
        normals[1] = Vector3.right;
        normals[subdivisions * 2] = Vector3.right;
        normals[subdivisions * 2 + 1] = Vector3.right;

        mesh.SetNormals(normals);

        DoPerlinNoise(mesh);
    }

    void DoPerlinNoise(Mesh mesh)
    {
        var positions = mesh.vertices;
        var normals = mesh.normals;

        for (int i = 0; i < positions.Length; i++)
        {
            float x = positions[i].x * positions[i].z * noiseFrequency.x;
            float y = positions[i].y * positions[i].z * noiseFrequency.y;

            positions[i] = positions[i] + noiseAmplitude * normals[i] * Mathf.PerlinNoise(x, y);
        }

        mesh.vertices = positions;
    }

    private void Update()
    {
        UpdateMesh();
    }
}

