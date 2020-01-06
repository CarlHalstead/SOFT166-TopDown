using UnityEngine;

/// <summary>
/// This is an extremely primitive script where the sole purpose is to move a GameObject right at a fixed speed.
/// This is used on the main menu just to add some atmosphere where zombies can run across the screen.
/// </summary>
public class DumbMove : MonoBehaviour
{
	[Header("Configurables")]
	[SerializeField]
	private Vector3 destinationOffset = new Vector3();

	[SerializeField]
	private float moveSpeedMinimum = 5f;

	[SerializeField]
	private float moveSpeedMaximum = 10f;

	private float moveSpeed = 0f;

	private Rigidbody2D rb = null;

	private Vector3 targetDestination = new Vector3();

    private void Awake()
    {
		rb = GetComponent<Rigidbody2D>();   
    }

	private void OnEnable()
	{
		moveSpeed = Random.Range(moveSpeedMinimum, moveSpeedMaximum);

		targetDestination = transform.position + destinationOffset;
	}

	private void Update()
    {
		rb.MovePosition(transform.position + (Vector3.right * (moveSpeed * Time.deltaTime)));

		if (Vector3.Distance(transform.position, targetDestination) < 0.25f)
			gameObject.SetActive(false);
	}
}
