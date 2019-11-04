using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform target = null;

    [Header("Configurables")]
    [SerializeField]
    private float smoothing = 5f;

    [SerializeField]
    private float adjustmentAngle = 0f;

    private void Update()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;

        float zRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion newRotation = Quaternion.Euler(0f, 0f, zRotation + adjustmentAngle);

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * smoothing);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
