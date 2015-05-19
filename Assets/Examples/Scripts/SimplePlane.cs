using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimplePlane : MonoBehaviour 
{
    Mesh mesh;
    MeshCollider meshCollider;

    public int width = 100;
    public float heightModifier = 10f;
    public float noiseModifier = 0.1f;

	void Start () 
    {
        mesh = new Mesh();
        meshCollider = GetComponent<MeshCollider>();

        GeneratePoints();
        GenerateTriangles();
        mesh.RecalculateNormals(); //requires triangles are set first, otherwise it does not know the topology

        GetComponent<MeshFilter>().mesh = mesh;
        meshCollider.sharedMesh = mesh;

	}

    void Update()
    {
        GeneratePoints();
        mesh.RecalculateNormals();

        meshCollider.sharedMesh = null;
        meshCollider.sharedMesh = mesh;
        

    }

        	
    void GeneratePoints()
    {
        Vector3[] vertices = new Vector3[width * width];

        for(int x = 0 ; x < width ; x++)
        {
            for(int y = 0 ; y < width ; y++)
            {
                float height = Mathf.PerlinNoise((x + Time.time) * noiseModifier, (y + Time.time) * noiseModifier) * heightModifier;

                vertices[x + width * y] = new Vector3( x - width / 2, height, y - width / 2);
            }
        }

        mesh.vertices = vertices;

        
    }



    void GenerateTriangles()
    {
        int[] triangles = new int[(width - 1) * (width - 1) * 6];

        int triangleIndex = 0;
        for (int x = 0; x < width - 1; x++)
        {
            for (int y = 0; y < width - 1; y++)
            {
                int vertexIndex = x * width + y;

                triangles[triangleIndex + 0] = vertexIndex;
                triangles[triangleIndex + 1] = vertexIndex + width;
                triangles[triangleIndex + 2] = vertexIndex + width + 1;

                triangles[triangleIndex + 3] = vertexIndex;
                triangles[triangleIndex + 4] = vertexIndex + width + 1;
                triangles[triangleIndex + 5] = vertexIndex + 1;
                                
                triangleIndex += 6;
            }
        }

        mesh.triangles = triangles;
    }


}
