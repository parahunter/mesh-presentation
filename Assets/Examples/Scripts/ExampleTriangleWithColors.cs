using UnityEngine;
using System.Collections;

public class ExampleTriangleWithColors : MonoBehaviour
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

		//assign triangles
		int[] triangles = new int[3] { 0, 1, 2 };
		mesh.triangles = triangles;

		GetComponent<MeshFilter>().mesh = mesh;
	}

	[SerializeField] float speed = 90f;

	void Update()
	{
		Color[] colors = new Color[3];

		float offset = Time.time * speed;

		colors[0] = ColorFromHue(0 + offset);
		colors[1] = ColorFromHue(120 + offset);
		colors[2] = ColorFromHue(240 + offset);
		
		mesh.colors = colors;
	}

	//source https://en.wikipedia.org/wiki/HSL_and_HSV#From_HSV
	Color ColorFromHue(float h)
	{
		h = Mathf.Repeat(h, 360f);

		h /= 60;            // sector 0 to 5
		float s = 1; float v = 1; //saturation and value is both set to max
		float c = s * v;
		
		//HSV to RGB conversion
		Color returnCol = new Color();
		returnCol.a = 1.0f;

		int i;
		float f, p, q, t;

		if (s == 0)
		{
			// achromatic (grey)
			returnCol.r = v;
			returnCol.g = v;
			returnCol.b = v;
			return returnCol;
		}
		
		i = (int)System.Math.Floor((double)h);
		f = h - i;          // factorial part of h
		p = v * (1 - s);
		q = v * (1 - s * f);
		t = v * (1 - s * (1 - f));
		switch (i)
		{
			case 0:
				returnCol.r = v;
				returnCol.g = t;
				returnCol.b = p;
				break;
			case 1:
				returnCol.r = q;
				returnCol.g = v;
				returnCol.b = p;
				break;
			case 2:
				returnCol.r = p;
				returnCol.g = v;
				returnCol.b = t;
				break;
			case 3:
				returnCol.r = p;
				returnCol.g = q;
				returnCol.b = v;
				break;
			case 4:
				returnCol.r = t;
				returnCol.g = p;
				returnCol.b = v;
				break;
			default:        // case 5:
				returnCol.r = v;
				returnCol.g = p;
				returnCol.b = q;
				break;
		}

		return returnCol;
	}
}