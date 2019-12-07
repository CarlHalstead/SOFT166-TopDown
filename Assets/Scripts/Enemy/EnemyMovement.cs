using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform target = null;

    [Header("Configurables")]
    [SerializeField]
    private float speed = 5f;

	private Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (target != null)
			rb.MovePosition(Vector3.MoveTowards(transform.position, target.position, speed * 0.01f));
	}

	public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
