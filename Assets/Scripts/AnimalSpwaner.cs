using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalSpwaner : MonoBehaviour
{
    [SerializeField] private Transform _left;
    [SerializeField] private Transform _right;
    [SerializeField] private float _interval;
    [SerializeField] private GameObject[] _animalsPrefabs;
    
    private float _currentTime;
    private float _randomPosition;
    private bool _isSpawning;

    private void Update()
    {
        _isSpawning = true;
        if (_currentTime >= 0)
        {
            _currentTime -= Time.deltaTime;
            _isSpawning = false;
        }
        else
        {
            _currentTime = _interval;
            _isSpawning = true;
        }
        
        HandleSpawn();
    }

    private void HandleSpawn()
    {
        if (!_isSpawning) return;
        Debug.Log("Spawn");
        _randomPosition = Random.Range(_left.position.x, _right.position.x);
        transform.position = new Vector3(_randomPosition, 0, 27);
        Instantiate(_animalsPrefabs[Random.Range(0, _animalsPrefabs.Length)], transform.position, transform.rotation);
    }
}
