using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public bool isPaused;
    public bool isGameOver;
    public float time;

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _scoreText1;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private GameObject _gameOverCanvas;

    private void Update()
    {
        HandleUI();
        StartTimer();
        if (isGameOver)
        {
            HandleGameOver();
        }
        if (Input.GetButtonDown("Cancel"))
        {
            HandlePause();
        }
    }
    
    private void StartTimer()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            isGameOver = true;
        }
    }

    private void HandleUI()
    {
        if (isPaused)
        {
            _pauseCanvas.SetActive(true);
        }
        else
        {
            _pauseCanvas.SetActive(false);
        }

        _scoreText.text = "Score : " + score;
        _scoreText1.text = "Score : " + score;
        _timerText.text = "Timer : " + Math.Floor(time);
    }

    public void HandlePause()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
        }
    }

    public void HandleMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void HandleRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HandleGameOver()
    {
        _gameOverCanvas.SetActive(true);
    }
}
