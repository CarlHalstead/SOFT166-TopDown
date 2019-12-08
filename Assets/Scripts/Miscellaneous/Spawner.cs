using UnityEngine;

public class Spawner : MonoBehaviour
{
	[Header("Configurables")]
	[SerializeField]
	private string poolObjectToSpawn = string.Empty;

    [SerializeField]
    private float adjustmentAngle = 0f;

    [SerializeField]
    private float spawnAreaRange = 3f;

	[SerializeField]
	private Vector3 spawnAreaOffset = Vector3.zero;

    public void Spawn()
    {
        Vector3 randomPosition = transform.position + (Vector3)(Random.insideUnitCircle * spawnAreaRange);

        Spawn(randomPosition + spawnAreaOffset);
    }

    private void Spawn(Vector3 position)
    {
        Vector3 rotationDegrees = transform.eulerAngles;
        rotationDegrees.z += adjustmentAngle;

        Quaternion rotation = Quaternion.Euler(rotationDegrees);

		GameObject newObj = PoolManager.Instance.Get(poolObjectToSpawn);
		newObj.transform.position = position;
		newObj.transform.rotation = rotation;
		newObj.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + spawnAreaOffset, spawnAreaRange);
    }
}
