using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Events")]
    [SerializeField]
    private UnityTransformEvent OnEnemySpawned = new UnityTransformEvent();

    private GameObject player = null;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        OnEnemySpawned.Invoke(player.transform);
    }

    public void AddScore()
    {
        player.GetComponent<PlayerStats>().AddScore(1);
    }
}
