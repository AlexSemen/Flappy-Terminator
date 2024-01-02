using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _tapForñe;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _startPosition = transform.position;
        _startRotation = transform.rotation;

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _player.IsGameOver == false)
        {
            _rigidbody2D.velocity = new Vector2(0, _tapForñe);
            transform.rotation = _maxRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Restart()
    {
        _rigidbody2D.velocity = Vector3.zero;
        transform.position = _startPosition;
        transform.rotation = _startRotation;
    }
}
