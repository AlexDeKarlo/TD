using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;
    private float _damage;
    private Transform _enemy;
    private Vector3 _targetPos;

    public void SetTarget(float speed, float damage, Transform enemy)
    {
        _speed = speed;
        _damage = damage;
        _enemy = enemy;
    }

    private void Update()
    {
        if (_enemy != null)
            _targetPos = _enemy.position;

        if (transform.position == _targetPos) 
            Destroy(gameObject);

        transform.position = Vector3.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);

        transform.LookAt(_targetPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<EnemyDamageable>()) 
            other.GetComponent<EnemyDamageable>().ApplyDamage(_damage);

        Destroy(gameObject);
    }
}
