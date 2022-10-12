using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralCircleMesh : MonoBehaviour
{
    Mesh mesh;
    List<Vector3> vertices;
    List<Vector3> normals;
    List<Vector2> uvVertices;
    List<int> triangles;
    public int nStep;
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
        Debug.Log(vertices.Count);
        Debug.Log(uvVertices.Count);
        for (int i = 0; i < vertices.Count; i++)
        {
            Debug.Log("VERTEX: " + vertices[i]);
            Debug.Log("UV: " + uvVertices[i]);
        }
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvVertices.ToArray();
        mesh.normals = normals.ToArray();
        mesh.RecalculateNormals();
    }

    void CreateShape()
    {
        Vector3 position = transform.position;
        float angleStep = 360 / nStep;
        Quaternion rotateQuat;
        Quaternion rotateQuat2;
        Vector3 firstPos;
        Vector3 secondPos;
        
        vertices.Add(position);
        uvVertices.Add((Vector2)position + new Vector2(0.5f, 0.5f));
        
        for (int i = 0; i < nStep-1; i++)
        {
            rotateQuat = Quaternion.AngleAxis(angleStep * i, Vector3.forward);
            rotateQuat2 = Quaternion.AngleAxis(angleStep * (i + 1), Vector3.forward);
            firstPos = position + rotateQuat * Vector3.left / 2;
            secondPos = position + rotateQuat2 * Vector3.left / 2;
            if(!vertices.Contains((Vector2)firstPos)) vertices.Add((Vector2)firstPos);
            if(!vertices.Contains((Vector2)secondPos)) vertices.Add((Vector2)secondPos);
            if(!uvVertices.Contains((Vector2)firstPos + new Vector2(0.5f, 0.5f))) uvVertices.Add((Vector2)firstPos + new Vector2(0.5f, 0.5f));
            if(!uvVertices.Contains((Vector2)secondPos + new Vector2(0.5f, 0.5f))) uvVertices.Add((Vector2)secondPos + new Vector2(0.5f, 0.5f));
            triangles.Add(vertices.IndexOf(position));
            triangles.Add(vertices.IndexOf(secondPos));
            triangles.Add(vertices.IndexOf(firstPos));
        }
        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(vertices.Count-1);
    }
}
