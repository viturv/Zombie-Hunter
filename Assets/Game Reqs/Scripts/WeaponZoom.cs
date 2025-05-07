using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{  
    [SerializeField] FirstPersonController FPSController;
    [SerializeField] Camera FpsCamera;
    [SerializeField] float ZoomedOutFov = 60f;
    [SerializeField] float ZoomedInFov = 30f;

    [SerializeField] float ZoomedInSensi = 0.7f;
    [SerializeField] float ZoomedOutSensi = 1f;

    bool ZoomedInToggle = false;

    void OnDisable()
    {
        ZoomOut();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(ZoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }    
    }

    private void ZoomOut()
    {
        ZoomedInToggle = false;
        FpsCamera.fieldOfView = ZoomedOutFov;
        FPSController.RotationSpeed = ZoomedOutSensi;
    }

    private void ZoomIn()
    {
        ZoomedInToggle = true;
        FpsCamera.fieldOfView = ZoomedInFov;
        FPSController.RotationSpeed = ZoomedInSensi;
    }
}
