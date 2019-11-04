using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform target = null;

    [Header("Configurables")]
    [SerializeField]
    private float speed = 5f;

    private void Update()
    {
        if (target != null)
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 0.01f);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
