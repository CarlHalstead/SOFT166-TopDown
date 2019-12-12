using Pathfinding;
using UnityEngine;

public class EnemyPathFinder : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private Transform target;

	private IAstarAI ai;


	private void Awake()
	{
		ai = GetComponent<IAstarAI>();
	}

	/// <summary>
	/// The reason we do not call SearchPath() manually here is because 
	/// that is already handled by AILerp and its Repeat Rate value.
	/// There is no reason to recalculate the path every single frame 
	/// and the effects of which will mostly go unnoticed compared
	/// to just calling it single digit times per second.
	/// </summary>
	private void Update()
	{
		if(target != null)
			if(ai != null)
				ai.destination = target.position;
	}

	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}
}
