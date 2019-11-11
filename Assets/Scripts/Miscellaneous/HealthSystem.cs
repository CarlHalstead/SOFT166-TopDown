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
    private UnityEvent OnHealthChanged = new UnityEvent();

    [SerializeField]
    private UnityFloatEvent OnHealthChangePercentage = new UnityFloatEvent();

    [SerializeField]
    private UnityIntEvent OnDamaged = new UnityIntEvent();

    [SerializeField]
    private UnityIntEvent OnHealed = new UnityIntEvent();

    private void Start()
    {
        health = maxHealth;
    }

    public void ChangeHealth(int change)
    {
        health += change;
        health = Mathf.Clamp(health, 0, maxHealth);

        OnHealthChanged.Invoke();
        OnHealthChangePercentage.Invoke(health / (float)maxHealth);

        if (change < 0)
            OnDamaged.Invoke(health);

        if (change > 0)
            OnHealed.Invoke(health);

        if (health == 0)
            OnDeath.Invoke();

    }

    [ContextMenu("Take Damage (1)")]
    public void DEBUG_TakeOneDamage()
    {
        ChangeHealth(-1);
    }

    [ContextMenu("Take Damage (5)")]
    public void DEBUG_TakeFiveDamage()
    {
        ChangeHealth(-1);
    }

    private void OnValidate()
    {
        health = maxHealth;
    }
}
