using UnityEngine;
using System.Collections;

public class TitleCameraRotate : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(0, 5, 0) * Time.deltaTime);
    }
}