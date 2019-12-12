using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Camera cam = null;

    [Header("Configurables")]
    [SerializeField]
    private float smoothing = 5f;

    [SerializeField]
    private float adjustmentAngle = 0f;

	[Header("Debug")]
	[SerializeField]
	private ControllerTypes controllerType = ControllerTypes.MOUSE_KEYBOARD;

	private enum ControllerTypes
	{
		MOUSE_KEYBOARD,
		CONTROLLER_XBOX
	}

    private void Update()
    {
		if (Input.GetAxis("HorizontalRightStick") != 0f ||
			Input.GetAxis("VerticalRightStick") != 0f)
		{
			controllerType = ControllerTypes.CONTROLLER_XBOX;
		}
		else if (Input.GetAxis("Mouse X") != 0f ||
				Input.GetAxis("Mouse Y") != 0f)
		{
			controllerType = ControllerTypes.MOUSE_KEYBOARD;
		}

		if (controllerType == ControllerTypes.MOUSE_KEYBOARD)
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;

			Vector3 target = cam.ScreenToWorldPoint(Input.mousePosition);
			Vector3 direction = (target - transform.position).normalized;

			float zRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			Quaternion newRotation = Quaternion.Euler(0f, 0f, zRotation + adjustmentAngle);

			transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * smoothing);
		}
		else if(controllerType == ControllerTypes.CONTROLLER_XBOX)
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;

			float xAxis = Input.GetAxis("HorizontalRightStick");
			float yAxis = Input.GetAxis("VerticalRightStick");

			if (xAxis != 0f || yAxis != 0f)
			{
				Vector3 direction = new Vector3(xAxis, yAxis).normalized;

				float zRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

				Quaternion newRotation = Quaternion.Euler(0f, 0f, zRotation + adjustmentAngle);

				transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * smoothing);
			}
		}
    }
}
