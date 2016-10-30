using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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
			
		print("number " + combineTargets.Length);
		
		List<CombinedMeshGroup> meshGroups = new List<CombinedMeshGroup>();
		
		int i = 0;
		for (i = 0; i < combineTargets.Length; i++)
		{
			MeshFilter meshFilter = combineTargets[i].GetComponent<MeshFilter>();

			print("meshfilter name " + meshFilter.sharedMesh.name);

			CombinedMeshGroup meshGroup = meshGroups.Find((mg) => mg.meshName == meshFilter.sharedMesh.name);

			if (meshGroup != null)
			{
				meshGroup.meshFilters.Add(meshFilter);
				print("combining");
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
				meshGroup.meshFilters[i].gameObject.SetActive(false);
				i++;
			}

			GameObject go = new GameObject("combined meshes - " + k);
			print(go.name);

			go.transform.parent = transform;

			MeshFilter meshFilter = go.AddComponent<MeshFilter>();
			meshFilter.mesh = new Mesh();
			meshFilter.mesh.CombineMeshes(combine);
						
			MeshRenderer meshRenderer = go.AddComponent<MeshRenderer>();
			meshRenderer.materials = meshGroup.materials;
		}
	}
}
