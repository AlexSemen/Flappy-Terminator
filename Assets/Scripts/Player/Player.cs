using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    [SerializeField] private Shooting _shooting;
    private PlayerMover _playerMover;

    public event UnityAction GameOver;
    private bool _isGameOver;

    public bool IsGameOver => _isGameOver;

    private void Awake()
    {
        _isGameOver = true;

        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (_isGameOver == false && Input.GetMouseButtonDown(0))
        {
            _shooting.Shoot();
        }
    }

    public void Restart()
    {
        _playerMover.Restart();
        _isGameOver = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isGameOver = true;
        GameOver?.Invoke();
    }
}
