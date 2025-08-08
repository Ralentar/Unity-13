using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _target;

    private float _timeWait = 1f;
    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_timeWait);
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (enabled)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);
            bullet.Initialize(direction);

            yield return _wait;

            Destroy(bullet.gameObject);
        }
    }
}