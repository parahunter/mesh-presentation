using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExampleBasicTexturedSquare : MonoBehaviour 
{
    Mesh mesh;

    public Gradient gradient;

    MeshRenderer meshRenderer;
    Texture2D texture;

    float scaling = 0.01f;
    int width = 512;

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

        Vector2[] uvs = new Vector2[4];
        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(0, 1);
        uvs[2] = new Vector2(1, 1);
        uvs[3] = new Vector2(1, 0);
        mesh.uv = uvs;
        
        //assign triangles
        int[] triangles = new int[6] { 0, 1, 2, 2, 3, 0 };
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;

        meshRenderer = GetComponent<MeshRenderer>();
        

        texture = new Texture2D(width, width);
        UpdateTexture();
        meshRenderer.sharedMaterial.mainTexture = texture;

        
    }

    void Update()
    {
        UpdateTexture();
    }

    void UpdateTexture()
    {
        Color[] pixels = new Color[width*width];

        for(int x = 0 ; x < width ; x++)
        {
            for(int y = 0 ; y < width ; y++)
            {
                float t = Mathf.PerlinNoise(x * scaling, y * scaling + Time.time);
                pixels[x + y * width] = gradient.Evaluate(t);
            }
        }

        texture.SetPixels(pixels);
        texture.Apply();
    }
}
