using UnityEngine;
using System.Collections;

public class ExampleStaticBatchingUtility : MonoBehaviour
{
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
		GUILayout.Label("You will also see that if you try and move one of the game objects after they have been batched the mesh will stay at it's current location");
	}

	void DoCombine()
	{
		GameObject[] batchTargets = GameObject.FindGameObjectsWithTag("BatchingTarget");

		StaticBatchingUtility.Combine(batchTargets, gameObject);
	}

}
