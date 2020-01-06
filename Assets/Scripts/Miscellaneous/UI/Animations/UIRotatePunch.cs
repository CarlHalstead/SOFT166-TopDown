using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIRotatePunch : MonoBehaviour, IPointerEnterHandler
{
	[Header("Configurables")]
	[SerializeField]
	private Vector3 punchRotation = new Vector3(2f, 2f, 2f);

	public void OnPointerEnter(PointerEventData eventData)
	{
		eventData.pointerEnter.transform.DOPunchRotation(punchRotation, 0.2f);
	}
}
