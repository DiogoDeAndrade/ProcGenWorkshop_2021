using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multimaterial : BaseMeshGenerator
{
    public Material secondMaterial;

    protected override void FillMesh(Mesh mesh)
    {
        List<Vector3> positions = new List<Vector3>();
        List<int> indexes1 = new List<int>();
        List<int> indexes2 = new List<int>();

        positions.Add(new Vector3(-1, 0, 0));
        positions.Add(new Vector3( 0, 1, 0));
        positions.Add(new Vector3( 1, 0, 0));
        positions.Add(new Vector3( 0, -1, 0));

        indexes1.Add(0);
        indexes1.Add(1);
        indexes1.Add(2);

        indexes2.Add(0);
        indexes2.Add(2);
        indexes2.Add(3);

        mesh.SetVertices(positions);
        mesh.subMeshCount = 2;
        mesh.SetIndices(indexes1, MeshTopology.Triangles, 0, true);
        mesh.SetIndices(indexes2, MeshTopology.Triangles, 1, true);

        GetComponent<MeshRenderer>().materials = new Material[] { material, secondMaterial };
    }
}
