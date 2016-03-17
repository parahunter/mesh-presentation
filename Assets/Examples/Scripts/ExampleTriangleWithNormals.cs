using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExampleTriangleWithNormals : MonoBehaviour 
{

    Mesh mesh;

    void Start()
    {
        mesh = new Mesh();

        //assign points
        Vector3[] vertices = new Vector3[3];
        vertices[0] = new Vector3(-1, -1, 0);
        vertices[1] = new Vector3(0, 0.8f, 0);
        vertices[2] = new Vector3(1, -1, 0);
        mesh.vertices = vertices;

        Vector3[] normals = new Vector3[3];
        normals[0] = Vector3.back; normals[1] = Vector3.back; normals[2] = Vector3.back;
        mesh.normals = normals;

        //assign triangles
        int[] triangles = new int[3] { 0, 1, 2 };
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
