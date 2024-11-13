using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _spawnRate = 10;
    [SerializeField] private float _playerRange;
    [SerializeField] private float _enemyRange;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _enemyLayer;

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnRate)
        {
            if (PlayerIsRange() == true && PlaceIsClear() == true)
            {
                _timer = 0;
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemy, transform.position, Quaternion.identity);
    }

    private bool PlayerIsRange()
    {
        return Physics.CheckSphere(transform.position, _playerRange, _playerLayer);
    }

    private bool PlaceIsClear()
    {
        return !Physics.CheckSphere(transform.position, _enemyRange, _enemyLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _playerRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _enemyRange);
    }
}
