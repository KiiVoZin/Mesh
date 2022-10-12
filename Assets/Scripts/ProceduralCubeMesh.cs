using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralCubeMesh : MonoBehaviour
{
    [SerializeField] int XTileCount, YTileCount;
    Mesh mesh;

    List<Vector3> vertices;
    List<Vector3> normals;
    List<Vector2> uvVertices;
    List<int> triangles;
    private void OnEnable()
    {
        vertices = new List<Vector3>();
        uvVertices = new List<Vector2>();
        triangles = new List<int>();
        normals = new List<Vector3>();
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
        mesh.normals = normals.ToArray();
        // mesh.RecalculateNormals();
    }
    void CreateShape()
    {
        List<Vector3> tempVertices = new List<Vector3>();
        List<Vector2> tempUvVertices = new List<Vector2>();
        List<int> tempTriangles = new List<int>();
        Vector3 scale = transform.localScale;
        //BOTTOM FACE
        for (int i = 0; i <= YTileCount; i++)
        {
            for (int j = 0; j <= XTileCount; j++)
            {
                Vector3 vertex = new Vector2(j/ XTileCount, i/ YTileCount);
                //vertex += new Vector3(0, scale.y, 0);
                tempVertices.Add(new Vector3(vertex.x, 0, 1 - vertex.y) - Vector3.one/2);
                tempUvVertices.Add(vertex - Vector3.one/2);
                normals.Add(Vector3.down);
            }
            
        }
        
        for (int i = vertices.Count; i < tempVertices.Count - XTileCount-1 + vertices.Count; i++)
        {
            if ((i + 1) % (XTileCount + 1) == 0)
            {
                continue;
            }
            
            tempTriangles.Add(i);
            tempTriangles.Add(i+XTileCount+1);
            tempTriangles.Add(i+1);
            
            tempTriangles.Add(i+XTileCount+1);
            tempTriangles.Add(i+XTileCount+2);
            tempTriangles.Add(i+1);
        }
        vertices.AddRange(tempVertices);
        uvVertices.AddRange(tempUvVertices);
        triangles.AddRange(tempTriangles);
        tempVertices.Clear();
        tempUvVertices.Clear();
        tempTriangles.Clear();
        //FRONT FACE
        for (int i = 0; i <= YTileCount; i++)
        {
            for (int j = 0; j <= XTileCount; j++)
            {
                Vector3 vertex = new Vector2(j/ XTileCount, i/ YTileCount);
                //vertex += new Vector3(0, scale.y, 0);
                tempVertices.Add(new Vector3(vertex.x, vertex.y, 0) - Vector3.one/2);
                tempUvVertices.Add(vertex - Vector3.one/2);
                normals.Add(Vector3.back);
            }
            
        }
        
        for (int i = vertices.Count; i < tempVertices.Count - XTileCount-1 + vertices.Count; i++)
        {
            if ((i + 1) % (XTileCount + 1) == 0)
            {
                continue;
            }
            
            tempTriangles.Add(i);
            tempTriangles.Add(i+XTileCount+1);
            tempTriangles.Add(i+1);
            
            tempTriangles.Add(i+XTileCount+1);
            tempTriangles.Add(i+XTileCount+2);
            tempTriangles.Add(i+1);
        }
        vertices.AddRange(tempVertices);
        uvVertices.AddRange(tempUvVertices);
        triangles.AddRange(tempTriangles);
        tempVertices.Clear();
        tempUvVertices.Clear();
        tempTriangles.Clear();
        //UPPER FACE
        for (int i = 0; i <= YTileCount; i++)
        {
            for (int j = 0; j <= XTileCount; j++)
            {
                Vector3 vertex = new Vector2(j/ XTileCount, i/ YTileCount);
                tempVertices.Add(new Vector3(vertex.x, 1, vertex.y) - Vector3.one/2);
                tempUvVertices.Add(vertex - Vector3.one/2);
                normals.Add(Vector3.up);
            }
            
        }
        
        for (int i = vertices.Count; i < tempVertices.Count - XTileCount-1 + vertices.Count; i++)
        {
            if ((i + 1) % (XTileCount + 1) == 0)
            {
                continue;
            }
            
            tempTriangles.Add(i);
            tempTriangles.Add(i+XTileCount+1);
            tempTriangles.Add(i+1);
            
            tempTriangles.Add(i+XTileCount+1);
            tempTriangles.Add(i+XTileCount+2);
            tempTriangles.Add(i+1);
        }
        vertices.AddRange(tempVertices);
        uvVertices.AddRange(tempUvVertices);
        triangles.AddRange(tempTriangles);
        tempVertices.Clear();
        tempUvVertices.Clear();
        tempTriangles.Clear();
        
        //LEFT FACE
        for (int i = 0; i <= YTileCount; i++)
        {
            for (int j = 0; j <= XTileCount; j++)
            {
                Vector3 vertex = new Vector2(j/ XTileCount, i/ YTileCount);
                tempVertices.Add(new Vector3(0, vertex.y, 1 - vertex.x) - Vector3.one/2);
                tempUvVertices.Add(vertex - Vector3.one/2);
                normals.Add(Vector3.left);
            }
            
        }
        
        for (int i = vertices.Count; i < tempVertices.Count - XTileCount-1 + vertices.Count; i++)
        {
            if ((i + 1) % (XTileCount + 1) == 0)
            {
                continue;
            }
            
            tempTriangles.Add(i);
            tempTriangles.Add(i+XTileCount+1);
            tempTriangles.Add(i+1);
            
            tempTriangles.Add(i+XTileCount+1);
            tempTriangles.Add(i+XTileCount+2);
            tempTriangles.Add(i+1);
        }
        vertices.AddRange(tempVertices);
        uvVertices.AddRange(tempUvVertices);
        triangles.AddRange(tempTriangles);
        tempVertices.Clear();
        tempUvVertices.Clear();
        tempTriangles.Clear();
        //RIGHT FACE
        for (int i = 0; i <= YTileCount; i++)
        {
            for (int j = 0; j <= XTileCount; j++)
            {
                Vector3 vertex = new Vector2(j/ XTileCount, i/ YTileCount);
                tempVertices.Add(new Vector3(1, vertex.y, vertex.x) - Vector3.one/2);
                tempUvVertices.Add(vertex - Vector3.one/2);
                normals.Add(Vector3.right);
            }
            
        }
        
        for (int i = vertices.Count; i < tempVertices.Count - XTileCount-1 + vertices.Count; i++)
        {
            if ((i + 1) % (XTileCount + 1) == 0)
            {
                continue;
            }
            
            tempTriangles.Add(i);
            tempTriangles.Add(i+XTileCount+1);
            tempTriangles.Add(i+1);
            
            tempTriangles.Add(i+XTileCount+1);
            tempTriangles.Add(i+XTileCount+2);
            tempTriangles.Add(i+1);
        }
        vertices.AddRange(tempVertices);
        uvVertices.AddRange(tempUvVertices);
        triangles.AddRange(tempTriangles);
        tempVertices.Clear();
        tempUvVertices.Clear();
        tempTriangles.Clear();
        
        //BACK FACE
        for (int i = 0; i <= YTileCount; i++)
        {
            for (int j = 0; j <= XTileCount; j++)
            {
                Vector3 vertex = new Vector2(j/ XTileCount, i / YTileCount);
                tempVertices.Add(new Vector3(1 - vertex.x, vertex.y, 1) - Vector3.one/2);
                tempUvVertices.Add(vertex - Vector3.one/2);
                normals.Add(Vector3.forward);
            }
            
        }
        
        for (int i = vertices.Count; i < tempVertices.Count - XTileCount-1 + vertices.Count; i++)
        {
            if ((i + 1) % (XTileCount + 1) == 0)
            {
                continue;
            }
            
            tempTriangles.Add(i);
            tempTriangles.Add(i+XTileCount+1);
            tempTriangles.Add(i+1);
            
            tempTriangles.Add(i+XTileCount+1);
            tempTriangles.Add(i+XTileCount+2);
            tempTriangles.Add(i+1);
        }
        vertices.AddRange(tempVertices);
        uvVertices.AddRange(tempUvVertices);
        triangles.AddRange(tempTriangles);
        tempVertices.Clear();
        tempUvVertices.Clear();
        tempTriangles.Clear();
    }


}