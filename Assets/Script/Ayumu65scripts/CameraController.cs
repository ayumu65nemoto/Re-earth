using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;    //Transform型をいれる
    public float distance = 9.0f;  //float型が入る
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

        var angles = transform.eulerAngles;     //このゲームオブジェクト（カメラ）の角度
        x = angles.y;   //「y」の値を取得（代入）
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

            //実際にゲーム内に反映
            transform.rotation = rotation;
            transform.position = position;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        //マウススクロールの値は動かさないと0になるのでここで保存する
        //float scrollLog += Input.GetAxis("Mouse ScrollWheel");
        float view = cam.fieldOfView - scroll * 10;

        cam.fieldOfView = Mathf.Clamp(value: view, min: 0.1f, max: 100.0f);

        //Cameraの位置、Z軸にスクロール分を加える
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
