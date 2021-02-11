using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorVertex : BaseMeshGenerator
{
    public Color color1 = Color.red;
    public Color color2 = Color.green;
    public Color color3 = Color.yellow;

    protected override void FillMesh(Mesh mesh)
    {
        List<Vector3>   positions = new List<Vector3>();
        List<Color>     colors = new List<Color>();
        List<int>       indexes = new List<int>();

        positions.Add(new Vector3(-1, 0, 0));
        positions.Add(new Vector3(0, 1, 0));
        positions.Add(new Vector3(1, 0, 0));

        colors.Add(color1);
        colors.Add(color2);
        colors.Add(color3);

        indexes.Add(0);
        indexes.Add(1);
        indexes.Add(2);

        mesh.SetVertices(positions);
        mesh.SetColors(colors);
        mesh.SetIndices(indexes, MeshTopology.Triangles, 0, true);
    }
}
