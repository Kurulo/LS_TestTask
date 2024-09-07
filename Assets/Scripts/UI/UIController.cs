using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text _timerText;

    private GameController _gameController;

    [Inject]
    private void Construct(GameController gameController) {
        _gameController = gameController;
    } 

    void Start() {
        
    }

    void Update() {
        if (_gameController.State == GameController.GameState.Running) {
            float time = _gameController.GamePlayTime;

            int hours = Mathf.FloorToInt( time / 3600);
            int minutes = Mathf.FloorToInt((time % 3600) / 60);
            int seconds = Mathf.FloorToInt(time % 60);

            // Форматування та виведення залежно від пройденого часу
            if (hours > 0) {
                _timerText.text = string.Format("Time: {0:00}:{1:00}:{2:00}", hours, minutes, seconds);
            }
            else if (minutes > 0) {
                _timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
            }
            else {
                _timerText.text = string.Format("Time: 0:{0:00}", seconds);
            }
        }       
    }
}
