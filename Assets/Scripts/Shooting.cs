using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : ObjectPool
{
    [SerializeField] private GameObject _prefab;

    private GameObject _newObject;
    private Game _game;

    private void Awake()
    {
        Initialize(_prefab);

        _game = FindObjectOfType<Game>();
    }

    private void OnEnable()
    {
        _game.Restart += ResetPool;
    }

    private void OnDisable()
    {
        _game.Restart -= ResetPool;
    }

    public void Shoot()
    {
        if (TryGetObject(out _newObject))
        {
            SetObject(_newObject, transform.position);
        }
    }

    private void SetObject(GameObject newObject, Vector2 position)
    {
        newObject.transform.position = position;
        newObject.transform.rotation = transform.rotation;
        newObject.SetActive(true);
    }
}
