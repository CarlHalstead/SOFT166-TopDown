using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private GameObject prefabToSpawn = null;

    [Header("Configurables")]
    [SerializeField]
    private float adjustmentAngle = 0f;

    public void Spawn()
    {
        Vector3 rotationDegrees = transform.eulerAngles;
        rotationDegrees.z += adjustmentAngle;

        Quaternion rotation = Quaternion.Euler(rotationDegrees);

        Instantiate(prefabToSpawn, transform.position, rotation);
    }
}
