using UnityEngine;
using Cinemachine;

public class CinemachinePOVExtension : CinemachineExtension
{
    private InputManager inputManager;
    private Vector3 startingRotation;

    [SerializeField]
    private float horizontalSpeed = 70f;
    [SerializeField]
    private float verticalSpeed = 70f;
    [SerializeField]
    private float clampAngle = 80f;


    protected override void Awake()
    {
        inputManager = InputManager.Instance;
        base.Awake();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase virtualCamera, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (virtualCamera.Follow) {
            if (stage == CinemachineCore.Stage.Aim) {
                if (startingRotation == null) {
                    startingRotation = transform.localRotation.eulerAngles;
                }
                Vector2 deltaInput = inputManager.GetMouseDelta();
                startingRotation.x += deltaInput.x * Time.deltaTime * verticalSpeed;
                startingRotation.y += deltaInput.y * Time.deltaTime * horizontalSpeed;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
            }
        }
    }
}
