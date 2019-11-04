using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private GameObject prefabToSpawn = null;

    [Header("Configurables")]
    [SerializeField]
    private float adjustmentAngle = 0f;

    [SerializeField]
    private float spawnAreaRange = 3f;

    public void Spawn()
    {
        Vector3 randomPosition = transform.position + (Vector3)(Random.insideUnitCircle * spawnAreaRange);

        Spawn(randomPosition);
    }

    private void Spawn(Vector3 position)
    {
        Vector3 rotationDegrees = transform.eulerAngles;
        rotationDegrees.z += adjustmentAngle;

        Quaternion rotation = Quaternion.Euler(rotationDegrees);

        Instantiate(prefabToSpawn, position, rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, spawnAreaRange);
    }
}
