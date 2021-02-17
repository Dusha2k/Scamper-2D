using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _vertical;
    [SerializeField] private float _changeTime = 3.0f;
    [SerializeField] private Rigidbody2D _rigidbody2d;
    private float _timer;
    private int _direction = 1;

    // Start is called before the first frame update
    void Start()
    {
       _timer = _changeTime;
    }

    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            _direction = -_direction;
            _timer = _changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = _rigidbody2d.position;

        if (_vertical)
        {
            position.y = position.y + Time.deltaTime * _speed * _direction; ;
        }
        else
        {
            position.x = position.x + Time.deltaTime * _speed * _direction; ;
        }
        _rigidbody2d.MovePosition(position);
    }
}
