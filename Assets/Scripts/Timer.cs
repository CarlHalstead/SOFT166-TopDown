using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [Header("Configurables")]
    [SerializeField]
    private float timeBetweenEvents = 1f;

    [SerializeField]
    private bool isRepeating = false;

    [Header("Events")]
    [SerializeField]
    private UnityEvent OnTimerTriggered = new UnityEvent();

    private void Start()
    {
        if (isRepeating == true)
            InvokeRepeating(nameof(TriggerTimer), 0, timeBetweenEvents);
        else
            Invoke(nameof(TriggerTimer), timeBetweenEvents);
    }

    private void TriggerTimer()
    {
        OnTimerTriggered.Invoke();
    }
}
