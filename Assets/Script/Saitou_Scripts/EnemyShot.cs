using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject player;           //�v���C���[
    public GameObject ball;             //�G�����˂���e�I�u�W�F�N�g
    public float ballSpeed = 5.0f;      //�e�̃X�s�[�h

    void Start()
    {
        //transform.LookAt(player.transform);
        StartCoroutine("BallShot");
    }

    void Update()
    {
        //transform.LookAt(player.transform);     //�v���C���[�̂�������Ɍ���
    }

    //IEnumerator BallShot()
    //{
    //    while (true)
    //    {
    //        var shot = Instantiate(ball, transform.position, Quaternion.identity);
    //        shot.GetComponent<Rigidbody>().velocity = transform.forward.normalized * ballSpeed;
    //        yield return new WaitForSeconds(4.3f);                                                  //���̒e���o��܂ł̎���
    //    }
    //}

    public void BallShot()
    {
        var shot = Instantiate(ball, transform.position, Quaternion.identity);
        shot.GetComponent<Rigidbody>().velocity = transform.forward.normalized * ballSpeed;
        /*return new WaitForSeconds(4.3f);*/                                                  //���̒e���o��܂ł̎���
    }
}