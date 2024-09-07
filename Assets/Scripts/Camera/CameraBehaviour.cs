using Cinemachine;
using UnityEngine;
using Zenject;

public class CameraBehavior : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;
    private PlayerController _playerController;

    [Inject] 
    private void Construct(PlayerController playerController) {
        _playerController = playerController;
    }

    private void Start() {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();

        StartSetup();
    }

    private void StartSetup() {
        _virtualCamera.Follow = _playerController.transform;
        _virtualCamera.LookAt = _playerController.transform;
    }
}
