using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScore;

    [SerializeField] private GameObject MenuGameOver;
    private LogicTetrominos LogicTetrominos;

    void Start()
    {
        //LogicTetrominos = GameObject;
    }

    
    void Update()
    {
        ScoreText.text = "Score: " + GameManager.Score;
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
