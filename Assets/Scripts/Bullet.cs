using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [Header("Configurables")]
    [SerializeField]
    private float moveSpeed = 500f;

    [SerializeField]
    private int damage = 1;

    private Rigidbody2D rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.AddForce(transform.up * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthSystem health = collision.GetComponent<HealthSystem>();

        if (health != null)
            health.TakeDamage(damage);

        Destroy();
    }

    private void OnBecameInvisible()
    {
        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
