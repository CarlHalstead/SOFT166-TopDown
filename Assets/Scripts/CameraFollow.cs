using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform target;

    [Header("Configurables")]
    [SerializeField]
    private float smoothing = 5f;

    private void LateUpdate()
    {
        Vector3 newPos = new Vector3(
            target.position.x,
            target.position.y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(transform.position, newPos, smoothing * 0.001f);
    }
}
