using Pathfinding;
using UnityEngine;

public class EnemyPathFinder : MonoBehaviour
{
	[Header("References")]
	private Transform target;

	private IAstarAI ai;

	private void Awake()
	{
		ai = GetComponent<IAstarAI>();
	}

	private void Update()
	{
		if (target != null)
		{
			if (ai != null)
			{
				ai.destination = target.position;
				ai.SearchPath();
			}
		}
	}

	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}
}
