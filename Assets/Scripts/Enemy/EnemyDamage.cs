using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [Header("Configurables")]
    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private float damageResetTime = 0.25f;

    private Collider2D enemyCollider = null;

    private void Awake()
    {
        enemyCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthSystem health = collision.GetComponent<HealthSystem>();

        if (health != null)
            health.ChangeHealth(-damage);

        enemyCollider.enabled = false;

        Invoke(nameof(ResetTrigger), damageResetTime);
    }

    private void ResetTrigger()
    {
        enemyCollider.enabled = true;
    }
}
