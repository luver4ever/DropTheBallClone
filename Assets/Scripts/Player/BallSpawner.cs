using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform _ball;

    public UnityAction BallSpawned;

    private void Awake()
    {
        _ball.position = transform.position;
        BallSpawned?.Invoke();
    }
    public void SpawnBall()
    {
        _ball.position = transform.position;
        BallSpawned?.Invoke();
    }
}
