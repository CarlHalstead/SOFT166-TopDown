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
	private float moveSpeed = 10f;

	private Rigidbody2D rb = null;

	private Vector3 targetDestination = new Vector3();

    private void Awake()
    {
		rb = GetComponent<Rigidbody2D>();   
    }

	private void Start()
	{
		targetDestination = transform.position + destinationOffset;
	}

	private void Update()
    {
		rb.MovePosition(transform.position + (Vector3.right * (moveSpeed * Time.deltaTime)));

		if (Vector3.Distance(transform.position, targetDestination) < 0.2f)
			gameObject.SetActive(false);
	}
}
