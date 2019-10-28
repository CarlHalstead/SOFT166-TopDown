using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [Header("Configurables")]
    [SerializeField]
    private int maxHealth = 10;

    [SerializeField]
    private int health = 10;

    [Header("Events")]
    [SerializeField]
    private UnityEvent OnDeath = new UnityEvent();

    [SerializeField]
    private UnityIntEvent OnDamaged = new UnityIntEvent();

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);

        OnDamaged.Invoke(health);

        if (health == 0)
            OnDeath.Invoke();
    }

    private void OnValidate()
    {
        health = maxHealth;
    }
}
