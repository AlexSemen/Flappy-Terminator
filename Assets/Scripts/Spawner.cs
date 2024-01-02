  using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] float _spamDelay;
    [SerializeField] float _spamMaxY;
    [SerializeField] float _spamMinY;

    private bool _isWork;
    private GameObject _newObject;

    private void Awake()
    {
        Initialize(_prefabs);

        _isWork = true;
    }

    private void Start()
    {
        StartCoroutine(Spam());
    }

    private void SetObject(GameObject newObject, Vector2 position)
    {
        newObject.transform.position = position;
        newObject.SetActive(true);
    }

    private IEnumerator Spam()
    {
        var waitForDelay = new WaitForSeconds(_spamDelay);

        while (_isWork)
        {
            if (TryGetObject(out _newObject))
            {
                SetObject(_newObject, new Vector2(transform.position.x, Random.Range(_spamMinY, _spamMaxY)));
            }

            yield return waitForDelay;
        }
    }
}
