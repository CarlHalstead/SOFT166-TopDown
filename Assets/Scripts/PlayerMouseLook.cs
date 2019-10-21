using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseLook : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Camera cam = null;

    [Header("Configurables")]
    [SerializeField]
    private float smoothing = 5f;

    [SerializeField]
    private float adjustmentAngle = 0f;

    private void Update()
    {
        Vector3 target = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (target - transform.position).normalized;

        float zRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion newRotation = Quaternion.Euler(0f, 0f, zRotation + adjustmentAngle);

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * smoothing);
    }
}
