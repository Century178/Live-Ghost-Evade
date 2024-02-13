using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Text _scoreText;
    [SerializeField] private float _scoreRate = 5;
    [SerializeField] private int _scoreValue = 50;
    private int _score;

    [HideInInspector] public bool IsDead; //When you want a variable public but don't need to change it, keep it hidden.

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        IsDead = false;
        _score = 0;

        InvokeRepeating(nameof(Increment), 0, 1f / _scoreRate);
    }

    private void Update()
    {
        if (IsDead && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Increment()
    {
        if (IsDead) return;

        _score++;
        _scoreText.text = _score.ToString();
    }

    public void ScoreUp()
    {
        if (IsDead) return;

        _score += _scoreValue;
        _scoreText.text = _score.ToString();
    }

    public void Death()
    {
        IsDead = true;
        _scoreText.text = "Final Score: " + _score.ToString() + "\n \n Left click to start a new run."; //"\n" creates a new line.
    }
}
