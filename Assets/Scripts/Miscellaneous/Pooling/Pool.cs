using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pool
{
	[SerializeField]
	private string poolName = string.Empty;

	public string PoolName => poolName;

	[SerializeField]
	private GameObject poolObject = null;

	[SerializeField]
	private int poolStartAmount = 5;

	[SerializeField]
	private List<GameObject> poolAvailableObjects = new List<GameObject>();

	private Transform poolParent = null;

	public void Initialise()
	{
		poolAvailableObjects = new List<GameObject>(poolStartAmount);

		for (int i = 0; i < poolStartAmount; i++)
		{
			Create();
		}
	}

	public GameObject Get()
	{
		for (int i = 0; i < poolAvailableObjects.Count; i++)
		{
			if (poolAvailableObjects[i].activeInHierarchy == false)
				return poolAvailableObjects[i];
		}

		return Create();
	}

	public void Reset()
	{
		for (int i = 0; i < poolAvailableObjects.Count; i++)
		{
			poolAvailableObjects[i].SetActive(false);
		}
	}

	public void SetParent(Transform parent)
	{
		GameObject newParent = new GameObject(poolName);
		newParent.transform.SetParent(parent);

		poolParent = newParent.transform;
	}

	private GameObject Create()
	{
		GameObject newObj = GameObject.Instantiate(poolObject);
		newObj.SetActive(false);

		if (poolParent != null)
			newObj.transform.SetParent(poolParent);

		poolAvailableObjects.Add(newObj);

		return newObj;
	}

}
