using UnityEngine;
using System.Collections;

public class ExampleStaticBatchingUtility : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.B))
		{
			DoCombine();
		}
	}

	void OnGUI()
	{
		GUILayout.Label("Hit B to perform static batching. Note how it brings the batching count down");
	}

	void DoCombine()
	{
		GameObject[] batchTargets = GameObject.FindGameObjectsWithTag("BatchingTarget");

		StaticBatchingUtility.Combine(batchTargets, gameObject);
	}

}
