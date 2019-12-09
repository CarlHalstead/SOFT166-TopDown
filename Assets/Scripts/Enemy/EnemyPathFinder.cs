using Pathfinding;
using UnityEngine;

public class EnemyPathFinder : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private Transform target;

	[Header("Configurables")]
	[SerializeField]
	private float timeBetweenPathingUpdates = 0.5f;

	private IAstarAI ai;

	private float timerPathing;

	private void Awake()
	{
		ai = GetComponent<IAstarAI>();
	}

	private void Start()
	{
		GetPath();
	}

	private void Update()
	{
		timerPathing += Time.deltaTime;

		if (timerPathing > timeBetweenPathingUpdates)
		{
			timerPathing -= timeBetweenPathingUpdates;

			GetPath();
		}
	}

	private void GetPath()
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
