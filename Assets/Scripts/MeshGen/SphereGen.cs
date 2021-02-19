using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGen : BaseMeshGenerator
{
    public Vector3 size = Vector3.one;
    public int     latDivs = 8;
    public int     lonDivs = 8;
    public float   noiseAmplitude;
    public Vector2 noiseFrequency;

    protected override void FillMesh(Mesh mesh)
    {
        List<Vector3> positions = new List<Vector3>();
        List<int>     indexes = new List<int>();

        float lonAngInc = (Mathf.PI * 2) / lonDivs;
        float latAngInc = Mathf.PI / (latDivs - 1);

        float lat = 0.0f;
        
        for (int y = 0; y < latDivs; y++)
        {
            float lon = 0.0f;

            for (int x = 0; x < lonDivs; x++)
            {
                Vector3 p = new Vector3();
                p.x = size.x * Mathf.Sin(lat) * Mathf.Cos(lon);
                p.y = -size.y * Mathf.Cos(lat);
                p.z = size.z * Mathf.Sin(lat) * Mathf.Sin(lon);

                positions.Add(p);

                lon += lonAngInc;
            }

            lat += latAngInc;
        }

        for (int y = 0; y < latDivs - 1; y++)
        {
            for (int x = 0; x < lonDivs; x++)
            {
                indexes.Add(x + y * lonDivs);
                indexes.Add(x + (y + 1) * lonDivs);
                indexes.Add(((x + 1) % lonDivs) + (y + 1) * lonDivs);

                indexes.Add(x + y * lonDivs);
                indexes.Add(((x + 1) % lonDivs) + (y + 1) * lonDivs);
                indexes.Add(((x + 1) % lonDivs) + y * lonDivs);
            }
        }

        mesh.SetVertices(positions);
        mesh.SetIndices(indexes, MeshTopology.Triangles, 0, true);

        mesh.RecalculateNormals();

        DoPerlinNoise(mesh);

        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
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

    private void OnValidate()
    {
        UpdateMesh();
    }
}
