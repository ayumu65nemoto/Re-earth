using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivityController : MonoBehaviour
{
    public enum SensitivityType { xSpeed, ySpeed }

    [SerializeField]
    SensitivityType sensitivityType = 0;

    Slider slider;
    CameraManager cameraManager;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        cameraManager = GameObject.FindWithTag("SoundManager")?.GetComponent<CameraManager>(); //SoundManagerÇéQè∆

        switch (sensitivityType)
        {
            case SensitivityType.xSpeed:
                slider.value = cameraManager.xSpeed;
                break;
            case SensitivityType.ySpeed:
                slider.value = cameraManager.ySpeed;
                break;

        }
    }

    public void OnSenseChanged()
    {
        switch (sensitivityType)
        {
            case SensitivityType.xSpeed:
                cameraManager.xSpeed = slider.value;
                break;
            case SensitivityType.ySpeed:
                cameraManager.ySpeed = slider.value;
                break;
        }
    }
}
