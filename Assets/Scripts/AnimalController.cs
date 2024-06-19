using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedMultiplier;
    public int hungerNeed;
    public int score;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rb.velocity = transform.forward * (_speed * Time.deltaTime * _speedMultiplier);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
