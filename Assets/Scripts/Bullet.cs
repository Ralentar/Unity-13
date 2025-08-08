using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    private float _speed = 25;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(Vector3 direction)
    {
        _rigidbody.velocity = direction * _speed;
        transform.up = direction;
    }
}