using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    private Vector2 _dir;

    private void Awake()
    {
        Destroy(gameObject, 25f / _speed);
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _dir);
    }

    public void SetDirection(Vector2 dir)
    {
        _dir = dir;
    }
}
