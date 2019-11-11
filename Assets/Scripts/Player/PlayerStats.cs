using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Configurables")]
    [SerializeField]
    private int currentScore = 0;

    [Header("Events")]
    [SerializeField]
    private UnityIntEvent OnScoreAdded = new UnityIntEvent();

    public void AddScore(int score)
    {
        currentScore += score;

        OnScoreAdded.Invoke(currentScore);
    }
}
