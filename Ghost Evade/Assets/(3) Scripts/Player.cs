using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 _killZone = new Vector2(10, 6);

    private bool _extraHit;

    private SpriteRenderer _sr;
    [SerializeField] private Color _oneHit, _twoHits;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();

        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Camera.main refers to the camera with the "MainCamera" tag.

        transform.position = mousePos;

        if (Mathf.Abs(transform.position.x) > Mathf.Abs(_killZone.x) || Mathf.Abs(transform.position.y) > Mathf.Abs(_killZone.y))
        {
            GameManager.Instance.Death();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (_extraHit)
            {
                _extraHit = false;
                _sr.color = _oneHit;
                return;
            }

            GameManager.Instance.Death();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Score"))
        {
            GameManager.Instance.ScoreUp();
        }

        if (collision.gameObject.CompareTag("Powerup"))
        {
            _extraHit = true;
            _sr.color = _twoHits;
        }

        Destroy(collision.gameObject);
    }
}
