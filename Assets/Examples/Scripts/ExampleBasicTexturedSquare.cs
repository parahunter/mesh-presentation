using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExampleBasicTexturedSquare : MonoBehaviour 
{
    Mesh mesh;

    public Gradient gradient;

    MeshRenderer meshRenderer;
    Texture2D texture;

    void Awake()
    {
        mesh = new Mesh();

        //assign points
        Vector3[] vertices = new Vector3[4] { new Vector3(-1, -1, 0), new Vector3(-1, 1, 0), new Vector3(1, 1, 0), new Vector3(1, -1, 0) };
        mesh.vertices = vertices;

        //assign normals
        Vector3[] normals = new Vector3[4] { new Vector3(0, 0, -1), new Vector3(0, 0, -1), new Vector3(0, 0, -1), new Vector3(0, 0, -1) };
        mesh.normals = normals;

        //assign uvs
        Vector2[] uvs = new Vector2[4] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0) };
        mesh.uv = uvs;

        //assign triangles
        int[] triangles = new int[6] { 0, 1, 2, 2, 3, 0 };
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh; //assign mesh
    }

    public float scaling = 0.01f;
    public int width = 512;

    void Start()
    {
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
