using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class CustomPrism : BaseMeshGenerator
{
    [ReorderableList]
    public List<float>      angles;
    [ReorderableList]
    public List<float>      heights;
    [ReorderableList]
    public List<Vector2>    radius;

    protected override void FillMesh(Mesh mesh)
    {
        if (angles.Count < 3)
        {
            Debug.LogError("At least 3 angles have to be set!");
            return;
        }
        if (heights.Count < 2)
        {
            Debug.LogError("At least 2 height have to be set!");
            return;
        }
        if (radius.Count != heights.Count)
        {
            Debug.LogError("Radius and heights have to have the same size");
            return;
        }

        List<Vector3> positions = new List<Vector3>();
        List<Vector2> uv = new List<Vector2>();
        List<int> indexes = new List<int>();

        // Add bottom center
        positions.Add(new Vector3(0.0f, heights[0], 0.0f));
        uv.Add(new Vector2(0, 1));

        // Add bottom loop for 
        AddLoop(angles, radius[0], heights[0], 1.0f, false, ref positions, ref uv);

        float totalHeight = Mathf.Abs(heights[heights.Count - 1] - heights[0]);

        for (int yIndex = 0; yIndex < heights.Count; yIndex++)
        {
            float y = heights[yIndex];

            AddLoop(angles, radius[yIndex], y, 1 - (y / totalHeight), true, ref positions, ref uv);
        }

        AddLoop(angles, radius[radius.Count - 1], heights[heights.Count - 1], 0, false, ref positions, ref uv);

        // Add top
        int topIndex = positions.Count;
        positions.Add(new Vector3(0.0f, heights[heights.Count - 1], 0.0f));
        uv.Add(new Vector2(0, 0));

        // Add bottom cap indexes
        for (int i = 0; i < angles.Count; i++)
        {
            indexes.Add(0);
            indexes.Add(i + 1);
            indexes.Add(((i + 1) % (angles.Count)) + 1);
        }

        // Addd middle indexes
        int baseIndex = angles.Count + 1;
        for (int i = 0; i < heights.Count - 1; i++)
        {
            int currRow = baseIndex + i * angles.Count * 2;
            int nextRow = baseIndex + (i + 1) * angles.Count * 2;

            for (int j = 0; j < angles.Count; j++)
            {
                indexes.Add(currRow + j * 2 + 1);
                indexes.Add(nextRow + j * 2 + 1);
                indexes.Add(nextRow + ((j + 1) * 2) % (angles.Count * 2));

                indexes.Add(currRow + j * 2 + 1);
                indexes.Add(nextRow + ((j + 1) * 2) % (angles.Count * 2));
                indexes.Add(currRow + ((j + 1) * 2) % (angles.Count * 2));
            }
        }

        baseIndex = baseIndex + heights.Count * angles.Count * 2;
        // Add top cap indexes
        for (int i = 0; i < angles.Count; i++)
        {
            indexes.Add(topIndex);
            indexes.Add(baseIndex + (i + 1) % (angles.Count));
            indexes.Add(baseIndex + i);
        }

        mesh.SetVertices(positions);
        mesh.SetUVs(0, uv);
        mesh.SetIndices(indexes, MeshTopology.Triangles, 0, true);

        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }

    void AddLoop(List<float> angles, Vector2 radius, float height, float v, bool doubleVertex,
                 ref List<Vector3> positions, ref List<Vector2> uv)
    {
        foreach (var angle in angles)
        {
            float angleRadians = Mathf.Deg2Rad * angle;
            positions.Add(new Vector3(radius.x * Mathf.Cos(angleRadians),
                                      height,
                                      radius.y * Mathf.Sin(angleRadians)));
            uv.Add(new Vector3(angle / 360.0f, v));

            if (doubleVertex)
            {
                positions.Add(new Vector3(radius.x * Mathf.Cos(angleRadians),
                                          height,
                                          radius.y * Mathf.Sin(angleRadians)));
                uv.Add(new Vector3(angle / 360.0f, v));
            }
        }
    }

    private void OnValidate()
    {
        UpdateMesh();
    }
}
