using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderGen : BaseMeshGenerator
{
    public float    height = 1.0f;
    public float    radius = 0.25f;
    public int      subdivisions = 8;

    protected override void FillMesh(Mesh mesh)
    {
        List<Vector3>   positions = new List<Vector3>();
        List<int>       indexes = new List<int>();

        float angleInc = (Mathf.PI * 2.0f) / subdivisions;
        float angle = 0.0f;

        for (int i = 0; i < subdivisions; i++)
        {
            Vector3 p1 = new Vector3(radius * Mathf.Cos(angle), 0.0f, radius * Mathf.Sin(angle));
            Vector3 p2 = p1 + Vector3.up * height;

            positions.Add(p1);
            positions.Add(p2);

            angle += angleInc;
        }

        for (int i = 0; i < subdivisions; i++)
        {
            indexes.Add(i * 2); indexes.Add(i * 2 + 1); indexes.Add(((i + 1) % subdivisions) * 2 + 1);
            indexes.Add(i * 2); indexes.Add(((i + 1) % subdivisions) * 2 + 1); indexes.Add(((i + 1) % subdivisions) * 2);
        }

        // Bottom cap
        positions.Add(Vector3.zero);
        int bottomIndex = positions.Count - 1;

        angle = 0.0f;
        for (int i = 0; i < subdivisions; i++)
        {
            Vector3 p = new Vector3(radius * Mathf.Cos(angle), 0.0f, radius * Mathf.Sin(angle));

            positions.Add(p);

            angle += angleInc;

            indexes.Add(bottomIndex);
            indexes.Add(bottomIndex + i + 1);
            indexes.Add(bottomIndex + (i + 1) % subdivisions + 1);
        }

        positions.Add(Vector3.up * height);
        int topIndex = positions.Count - 1;

        angle = 0.0f;
        for (int i = 0; i < subdivisions; i++)
        {
            Vector3 p = new Vector3(radius * Mathf.Cos(angle), height, radius * Mathf.Sin(angle));

            positions.Add(p);

            angle += angleInc;

            indexes.Add(topIndex);
            indexes.Add(topIndex + (i + 1) % subdivisions + 1);
            indexes.Add(topIndex + i + 1);
        }

        mesh.SetVertices(positions);
        mesh.SetIndices(indexes, MeshTopology.Triangles, 0, true);

        mesh.RecalculateNormals();
    }
}

