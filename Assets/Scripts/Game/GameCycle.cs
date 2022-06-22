using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCycle : MonoBehaviour
{
    [SerializeField] private BlockSpawner _spawner;
    [SerializeField] private LineMover _mover;
    [SerializeField] private EndAttempTrigger _endTrigger;
    [SerializeField] private Transform _allLines;
    [SerializeField] private LoseTrigger _loseTrigger;
    [SerializeField] private MainMenuView _menu;
    [Header("Game Settings")]
    [SerializeField] private AnimationCurve _spawnCurve;
    [Header("Ball Settings")]
    [SerializeField] private BallShooter _shooter;
    [SerializeField] private BallSpawner _ballSpawner;
    [Header("Player Components")]
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Rigidbody2D _rigidbody;

    private float _inGameTime;
    private float _generateChance;

    private void OnEnable()
    {
        _ballSpawner.BallSpawned += OnBallSpawn;
        _endTrigger.AttempEnded += OnAttempEnd;
        _shooter.BallShooted += OnBallShoot;
        _loseTrigger.PlayerLose += OnPlayerLose;
        _menu.GameStarted += OnGameStart;
    }
    private void OnDisable()
    {
        _ballSpawner.BallSpawned -= OnBallSpawn;
        _endTrigger.AttempEnded -= OnAttempEnd;
        _shooter.BallShooted -= OnBallShoot;
        _loseTrigger.PlayerLose -= OnPlayerLose;
        _menu.GameStarted -= OnGameStart;
    }

    private void OnGameStart()
    {
        StartCoroutine(StartCreation()); 
    }

    private void OnPlayerLose()
    {
        _input.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Start()
    {
        _input.enabled = false;
        
    }
    private void Update()
    {
        _generateChance = _spawnCurve.Evaluate(_inGameTime);
        _inGameTime += Time.deltaTime / 60;
    }
    private void OnAttempEnd()
    {
        _spawner.CreateLine(_allLines, (int)_generateChance * 10);
        _mover.MoveAllLines(_allLines);
        _ballSpawner.SpawnBall();
    }
    
    private IEnumerator StartCreation()
    {
        int numberOfLines = UnityEngine.Random.Range(2, 4);
        var waitForSeconds = new WaitForSeconds(1.5f);
        for(int i = 0; i < numberOfLines; i++)
        {
            _spawner.CreateLine(_allLines, 20);
            _mover.MoveAllLines(_allLines);

            yield return waitForSeconds;
        }
        _input.enabled = true;
    }
    private void OnBallShoot()
    {
        _input.enabled = false;
    }
    private void OnBallSpawn()
    {
        _rigidbody.gravityScale = 0f;
        _rigidbody.velocity = new Vector2(0f, 0f);
        _input.enabled = true;
    }
}
