using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineZoomController : CinemachineExtension
{
    [SerializeField] float zoomSpeed;
    [SerializeField, Range(1, 90)] float minFieldOfView;
    [SerializeField, Range(90, 179)] float maxFieldOfView;

    public override bool RequiresUserInput => true;

    float mouseScroolWheelAxisValue;
    float currentFieldOfView;

    void Update()
    {
        mouseScroolWheelAxisValue += Input.GetAxis("Mouse ScrollWheel");
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage != CinemachineCore.Stage.Aim) return;

        if (!Mathf.Approximately(mouseScroolWheelAxisValue,0))
        {
            float updatedFieldOfView = currentFieldOfView - mouseScroolWheelAxisValue * zoomSpeed;
            float minFieldOfView = this.minFieldOfView - state.Lens.FieldOfView;
            float maxFieldOfView = this.maxFieldOfView - state.Lens.FieldOfView;

            currentFieldOfView = Mathf.Clamp(updatedFieldOfView,
                                             minFieldOfView,
                                             maxFieldOfView);
            mouseScroolWheelAxisValue = 0;
        }

        state.Lens.FieldOfView += currentFieldOfView;
    }
}
