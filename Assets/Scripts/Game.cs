using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private List<Spawner> _spawners;

    public event UnityAction Restart;

    private void OnEnable()
    {
        _player.GameOver += GameOver;
    }

    private void OnDisable()
    {
        _player.GameOver -= GameOver;
    }

    private void Start()
    {
        _startPanel.SetActive(true);
        _gameOverPanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        _player.Restart();
        Restart?.Invoke();

        foreach (Spawner spawner in _spawners)
        {
            spawner.ResetPool();
        }

        Time.timeScale = 1;
    }

    private void GameOver()
    {
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
