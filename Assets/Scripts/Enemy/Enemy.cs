using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Events")]
    [SerializeField]
    private UnityTransformEvent OnEnemySpawned = new UnityTransformEvent();

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        OnEnemySpawned.Invoke(player.transform);
    }
}
