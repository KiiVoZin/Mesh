using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralPlaneMesh : MonoBehaviour
{
    [SerializeField] int XTileCount, YTileCount;
    Mesh mesh;

    List<Vector3> vertices;
    List<Vector2> uvVertices;
    List<int> triangles;
    private void OnEnable()
    {
        vertices = new List<Vector3>();
        uvVertices = new List<Vector2>();
        triangles = new List<int>();
        mesh = new Mesh {
            name = "Procedural Mesh"
        };
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateMesh();
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvVertices.ToArray();
        mesh.RecalculateNormals();
    }
    void CreateShape()
    {
        Vector3 scale = transform.localScale;
        for (int i = 0; i <= YTileCount; i++)
        {
            for (int j = 0; j <= XTileCount; j++)
            {
                vertices.Add(new Vector3(j*scale.x/XTileCount, 0, i*scale.z/YTileCount) - new Vector3(0.5f, 0, 0.5f));
                uvVertices.Add(new Vector2(j*scale.x/XTileCount, i*scale.z/YTileCount) - Vector2.one/2);
            }
            
        }

        for (int i = 0; i < vertices.Count - XTileCount-1; i++)
        {
            if ((i + 1) % (XTileCount + 1) == 0)
            {
                continue;
            }
            
            triangles.Add(i);
            triangles.Add(i+XTileCount+1);
            triangles.Add(i+1);
            
            triangles.Add(i+XTileCount+1);
            triangles.Add(i+XTileCount+2);
            triangles.Add(i+1);
        }
        


    }


}