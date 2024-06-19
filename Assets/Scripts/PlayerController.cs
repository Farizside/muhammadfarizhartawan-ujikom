using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private GameObject _foodPrefabs;

    private CharacterController _controller;
    private Animator _animator;
    private float _horizontal;
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _controller.Move(new Vector3(_horizontal * _movementSpeed * Time.deltaTime, 0f, 0f));

        if (Input.GetButtonDown("Fire1"))
        {
            HandleShot();
        }
        
        HandleAnimation();
    }

    private void HandleAnimation()
    {
        if (_horizontal == 0)
        {
            _animator.SetBool(IsMoving, false);
            _animator.SetFloat(Horizontal, 0);
        }

        if (_horizontal > 0)
        {
            _animator.SetBool(IsMoving, true);
            _animator.SetFloat(Horizontal, 1);
        }else if (_horizontal < 0)
        {
            _animator.SetBool(IsMoving, true);
            _animator.SetFloat(Horizontal, -1);
        }
    }

    private void HandleShot()
    {
        Instantiate(_foodPrefabs, transform.position, Quaternion.identity);
    }
}
