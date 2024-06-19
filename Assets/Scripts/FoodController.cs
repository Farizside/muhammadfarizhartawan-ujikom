using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    [SerializeField] private float _lifetime;
    [SerializeField] private float _speed;
    [SerializeField] private int _hungerValue;

    private Rigidbody _rb;
    private GameManager _gm;

    private void Awake()
    {
        Debug.Log("Shoot");
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * _speed);
        _gm = FindObjectOfType<GameManager>();
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
            var target = other.GetComponent<AnimalController>();
            if (target.hungerNeed > 0)
            {
                target.hungerNeed -= _hungerValue;
                if (target.hungerNeed <= 0)
                {
                    _gm.score += target.score;
                    Destroy(other.gameObject);
                }
            }
            Destroy(gameObject);
        }
    }
}
