using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    private Vector2 _dir;

    private Rigidbody2D _rb2D;

    private void Awake()
    {
        Destroy(gameObject, 25f / _speed);
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb2D.velocity = _dir * _speed;
    }

    public void SetDirection(Vector2 dir)
    {
        _dir = dir;
    }
}
