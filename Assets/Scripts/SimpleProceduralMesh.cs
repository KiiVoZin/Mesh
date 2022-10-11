using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SimpleProceduralMesh : MonoBehaviour
{
    [SerializeField] float XTileCount, YTileCount;
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
        foreach (var vector in vertices)
        {
            Debug.Log(vector);
        }
        //mesh.vertices = vertices.ToArray();
        //mesh.triangles = triangles.ToArray();
        //mesh.uv = uvVertices.ToArray();
        //mesh.RecalculateNormals();
    }
    void CreateShape()
    {
        Vector3 scale = transform.localScale;
        for (int i = 0; i <= YTileCount; i++)
        {
            for (int j = 0; j <= XTileCount; j++)
            {
                vertices.Add(new Vector3(j*scale.x/XTileCount, 0, i*scale.z/YTileCount));
                uvVertices.Add(new Vector2(j*scale.x/XTileCount, i*scale.z/YTileCount));
            }
            
        }

        for (int i = 0; i < vertices.Count; i++)
        {

        }

        /*uvVertices = new Vector2[]
        {
            new Vector3(0, 0),
            new Vector3(0, 1),
            new Vector3(1, 0),
            new Vector3(1, 1)
        };
        triangles = new int[]
        {
            0, 1, 2, 1, 3, 2
        };*/
    }


}
