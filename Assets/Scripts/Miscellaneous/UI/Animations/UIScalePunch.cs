using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIScalePunch : MonoBehaviour, IPointerEnterHandler
{
	[Header("Configurables")]
	[SerializeField]
	private Vector3 punchScale = new Vector3(0.15f, 0.15f, 0.15f);

	public void OnPointerEnter(PointerEventData eventData)
	{
		eventData.pointerEnter.transform.DOPunchScale(punchScale, 0.2f);
	}
}
