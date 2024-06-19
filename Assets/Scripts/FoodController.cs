using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    [SerializeField] private float _lifetime;
    [SerializeField] private float _speed;
    [SerializeField] private float _hungerValue;

    private Rigidbody _rb;

    private void Awake()
    {
        Debug.Log("Shoot");
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * _speed );
    }

    private void Update()
    {
        StartTimer();
    }

    private void StartTimer()
    {
        if (_lifetime >= 0)
        {
            _lifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            Debug.Log(other.name);
        }
    }
}
