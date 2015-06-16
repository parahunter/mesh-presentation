using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExampleBasicSquare : MonoBehaviour
{
    Mesh mesh;

    void Start()
    {
        mesh = new Mesh();

        //assign points
        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(-1, -1, 0);
        vertices[1] = new Vector3(-1, 1, 0);
        vertices[2] = new Vector3(1, 1, 0);
        vertices[3] = new Vector3(1, -1, 0);
        mesh.vertices = vertices;

        //assign normals
        Vector3[] normals = new Vector3[4];
        normals[0] = new Vector3(0, 0, -1);
        normals[1] = new Vector3(0, 0, -1);
        normals[2] = new Vector3(0, 0, -1);
        normals[3] = new Vector3(0, 0, -1);
        mesh.normals = normals;

        //assign triangles
        int[] triangles = new int[6] { 0, 1, 2, 2, 3, 0};
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;
    }
}



