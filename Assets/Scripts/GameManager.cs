using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const float SpawnFrequency = 0.4f;
    public AudioSource AudioSource;
    
    public Meteor Metoer1;
    public Meteor Metoer2;
    private float _elapsed;

    public TMP_Text _scoreUi;
    private float _score;
    private float _highscore;

    private float _timeScale = 1.0f;
    
    private void Update()
    {
        if (_timeScale < 1.0f)
        {
            _timeScale += Time.deltaTime * 0.5f;
            AudioSource.pitch = Time.timeScale = _timeScale;
        }
        else if (_timeScale > 1.0f)
        {
            AudioSource.pitch = Time.timeScale = _timeScale = 1f;
        }
        
        _elapsed += Time.deltaTime;
        if (_elapsed >= SpawnFrequency)
        {
            _elapsed = 0f;

            var meteorToSpawn = Random.value > 0.5 ? Metoer1 : Metoer2;
            var meteor = Instantiate(meteorToSpawn);
            meteor.transform.position = new Vector3((Random.value * 16f) - 8f, 6f, 0f);
        }

        _score += Time.deltaTime;
        if (_highscore < _score)
            _highscore = _score;
        _scoreUi.text = $"Score: {_score:F2}\r\nHighscore: {_highscore:F2}";
    }

    public void Hit()
    {
        _score = 0f;
        AudioSource.pitch = Time.timeScale = _timeScale = 0.5f;
    }
}
