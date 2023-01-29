using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyConfig _enemyConfig;
    public EnemyConfig Config => _enemyConfig;
}
