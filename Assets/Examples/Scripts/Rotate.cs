using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rotate : MonoBehaviour 
{
    public float rotationSpeed = 20f;
	
	// Update is called once per frame
	void Update () 
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
	}
}
