using UnityEngine;

public class GameController : MonoBehaviour
{
    private static float _gamePlayTime = 0f;
    public float GamePlayTime { get { return _gamePlayTime; } }

    public GameState State;
    private float _startTime;

    public enum GameState {
        Pause, 
        Loading,
        Running,
        Quiet
    }

    private void Start() {
        State = GameState.Running;
        _gamePlayTime = 0f;
        _startTime = Time.time;
    }

    private void Update() {
        if (State == GameState.Running) {
            _gamePlayTime = Time.time - _startTime;
        }
    }
}
