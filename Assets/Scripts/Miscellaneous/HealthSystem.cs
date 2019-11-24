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
	private UnityStatChangedEvent OnHealthChanged = new UnityStatChangedEvent();

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

		OnHealthChanged.Invoke(new OnStatChangedEventArgs(
			current: health,
			currentAsPercentage: health / (float)maxHealth
		));

        if (change < 0)
            OnDamaged.Invoke(health);

        if (change > 0)
            OnHealed.Invoke(health);

        if (health == 0)
            OnDeath.Invoke();

    }

    private void OnValidate()
    {
        health = maxHealth;
    }
}
