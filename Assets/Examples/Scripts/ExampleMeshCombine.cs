using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Example on how to use Mesh.Combine to reduce drawcalls
//Please not that here I use the name of the mesh to determine if they can be combined together.
//A more robust approach would be to see if two meshes share the same material in the same order but
//to keep this simple I opted for using the name instead

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class ExampleMeshCombine : MonoBehaviour
{
	[SerializeField] float rotationSpeed = 10f;

	class CombinedMeshGroup
	{
		public string meshName;
		public Material[] materials;
		public List<MeshFilter> meshFilters = new List<MeshFilter>();
	}
		
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.C))
			DoCombine();

		transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
	}

	void DoCombine()
	{
		GameObject[] combineTargets = GameObject.FindGameObjectsWithTag("BatchingTarget");
		
		List<CombinedMeshGroup> meshGroups = new List<CombinedMeshGroup>();
		
		int i = 0;
		for (i = 0; i < combineTargets.Length; i++)
		{
			MeshFilter meshFilter = combineTargets[i].GetComponent<MeshFilter>();

			CombinedMeshGroup meshGroup = meshGroups.Find((mg) => mg.meshName == meshFilter.sharedMesh.name);

			if (meshGroup != null)
			{
				meshGroup.meshFilters.Add(meshFilter);
			}
			else
			{
				meshGroup = new CombinedMeshGroup();
				MeshRenderer meshRenderer = combineTargets[i].GetComponent<MeshRenderer>();
				meshGroup.meshName = meshFilter.sharedMesh.name;
				meshGroup.materials = meshRenderer.materials;
				meshGroup.meshFilters.Add(meshFilter);

				meshGroups.Add(meshGroup);
			}		
		}

		for (int k = 0; k < meshGroups.Count; k++)
		{
			CombinedMeshGroup meshGroup = meshGroups[k];

			CombineInstance[] combine = new CombineInstance[meshGroup.meshFilters.Count];

			i = 0;
			while (i < meshGroup.meshFilters.Count)
			{
				combine[i].mesh = meshGroup.meshFilters[i].sharedMesh;
				combine[i].transform = meshGroup.meshFilters[i].transform.localToWorldMatrix;
				Destroy(meshGroup.meshFilters[i].gameObject);
				i++;
			}

			GameObject go = new GameObject("combined mesh - " + meshGroup.meshName);
			print(go.name);

			go.transform.parent = transform;

			MeshFilter meshFilter = go.AddComponent<MeshFilter>();
			meshFilter.mesh = new Mesh();
			meshFilter.mesh.CombineMeshes(combine);
						
			MeshRenderer meshRenderer = go.AddComponent<MeshRenderer>();
			meshRenderer.materials = meshGroup.materials;
		}
	}

	void OnGUI()
	{
		GUILayout.Label("Press C to combine meshes");
		GUILayout.Label("When you do you can see the amount of batches (draw calls) goes down");
	}
}
