using Cinemachine;
using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraSwitch : NetworkBehaviour
{
    [SerializeField] private CinemachineVirtualCamera firstPersonCam;
    [SerializeField] protected CinemachineVirtualCamera thirdPersonCam;

    private bool isThirdPerson = false;

    public override void OnStartClient()
    {
        if(!IsOwner)
        {
            firstPersonCam.enabled = false;
            thirdPersonCam.enabled = false;
            enabled = false;
            return;
        }

        SetCamera(false);
    }

    private void Update()
    {
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            isThirdPerson = true;
            SetCamera(isThirdPerson);
        }
        else
        {
            isThirdPerson = false;
            SetCamera(false);
        }
    }

    private void SetCamera(bool third)
    {
        if(third)
        {
            thirdPersonCam.Priority = 20;
            firstPersonCam.Priority = 10;
        }
        else
        {
            firstPersonCam.Priority = 20;
            thirdPersonCam.Priority = 10;
        }
    }
}
