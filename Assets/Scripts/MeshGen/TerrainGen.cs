using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : BaseMeshGenerator
{
    public Vector2 size = new Vector2(10.0f, 10.0f);
    public int     subdivisions = 16;
    public float   textureScale = 1.0f;

    protected override void FillMesh(Mesh mesh)
    {
        List<Vector3>   positions = new List<Vector3>();
        List<Vector2>   uv = new List<Vector2>();
        List<int>       indexes = new List<int>();

        Vector3 basePos = new Vector3(-size.x * 0.5f, 0.0f, -size.y * 0.5f);
        Vector2 quadSize = size / (subdivisions - 1);

        for (int z = 0; z < subdivisions; z++)
        {
            for (int x = 0; x < subdivisions; x++)
            {
                float px = x * quadSize.x;
                float pz = z * quadSize.y;
                float y = GetHeight(px, pz);

                positions.Add(new Vector3(px, y, pz) + basePos);
                uv.Add(new Vector2(x * textureScale, z * textureScale));

                if ((z < (subdivisions - 1) && (x < (subdivisions - 1))))
                {
                    indexes.Add(z * subdivisions + x);
                    indexes.Add((z + 1) * subdivisions + x);
                    indexes.Add((z + 1) * subdivisions + x + 1);

                    indexes.Add(z * subdivisions + x);
                    indexes.Add((z + 1) * subdivisions + x + 1);
                    indexes.Add(z * subdivisions + x + 1);
                }
            }
        }

        mesh.SetVertices(positions);
        mesh.SetUVs(0, uv);
        mesh.SetIndices(indexes, MeshTopology.Triangles, 0, true);

        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }

    protected virtual float GetHeight(float x, float y)
    {
        return 0.0f;
    }
}
