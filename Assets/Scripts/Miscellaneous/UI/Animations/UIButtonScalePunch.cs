using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonScalePunch : MonoBehaviour, IPointerEnterHandler
{
	[Header("Configurables")]
	[SerializeField]
	private Vector3 punchScale = new Vector3(1.125f, 1.125f, 1.125f);

	public void OnPointerEnter(PointerEventData data)
	{
		data.pointerEnter.transform.DOPunchScale(punchScale, 0.2f);
	}
}
