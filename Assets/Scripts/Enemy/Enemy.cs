using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Shooting _shooting;
    [SerializeField] float _shootDelay;

    private bool _isWork;

    private void Awake()
    {
        _isWork = true;
    }

    private void OnEnable()
    {
        StartCoroutine(Shoots());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    private IEnumerator Shoots()
    {
        var waitForDelay = new WaitForSeconds(_shootDelay);

        while (_isWork)
        {
            yield return waitForDelay;

            _shooting.Shoot();
        }
    }
}
