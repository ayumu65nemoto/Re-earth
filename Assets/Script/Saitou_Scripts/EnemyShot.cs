using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject player;           //プレイヤー
    public GameObject ball;             //敵が発射する弾オブジェクト
    public float ballSpeed = 8.0f;      //弾のスピード
    public Transform shotPoint;

    void Start()
    {
        //transform.LookAt(player.transform);
        StartCoroutine("BallShot");
    }

    void Update()
    {
        //transform.LookAt(player.transform);     //プレイヤーのいる方向に向く
    }

    public void BallShot()
    {
        var shot = Instantiate(ball, shotPoint.position, Quaternion.identity);
        shot.GetComponent<Rigidbody>().velocity = transform.forward.normalized * ballSpeed;
        /*return new WaitForSeconds(4.3f);*/                                                  //次の弾が出るまでの時間
    }
}