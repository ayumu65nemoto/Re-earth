using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;    //Transform�^�������
    public float distance = 9.0f;  //float�^������
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;
    public float yMinLimit = -45f;
    public float yMaxLimit = 85f;
    private float x = 0.0f;
    private float y = 0.0f;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        var angles = transform.eulerAngles;     //���̃Q�[���I�u�W�F�N�g�i�J�����j�̊p�x
        x = angles.y;   //�uy�v�̒l���擾�i����j
        y = angles.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            var rotation = Quaternion.Euler(y, x, 0);
            var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            //���ۂɃQ�[�����ɔ��f
            transform.rotation = rotation;
            transform.position = position;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        //�}�E�X�X�N���[���̒l�͓������Ȃ���0�ɂȂ�̂ł����ŕۑ�����
        //float scrollLog += Input.GetAxis("Mouse ScrollWheel");
        float view = cam.fieldOfView - scroll * 10;

        cam.fieldOfView = Mathf.Clamp(value: view, min: 0.1f, max: 100.0f);

        //Camera�̈ʒu�AZ���ɃX�N���[������������
        //transform.localPosition
        //    = new Vector3(transform.localPosition.x,
        //    transform.localPosition.y,
        //    transform.localPosition.z + scrollLog);
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) { angle += 360; }
        if (angle > 360) { angle -= 360; }
        return Mathf.Clamp(angle, min, max);
    }
}
