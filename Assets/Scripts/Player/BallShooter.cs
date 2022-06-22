using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallShooter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PlayerInput _input;


    public UnityAction BallShooted;
    private void OnEnable()
    {
        _input.DirectionSetted += OnDirectionSet;

    }
    private void OnDisable()
    {
        _input.DirectionSetted -= OnDirectionSet;

    }
    private void OnDirectionSet(Vector2 direction)
    {
        direction.Normalize();

        _rigidbody.gravityScale = 1f;

        _rigidbody.velocity = direction * _speed;

        BallShooted?.Invoke();
    }

}
