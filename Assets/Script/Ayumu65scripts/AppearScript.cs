using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearScript : MonoBehaviour
{
    //�@�o��������G�����Ă���
    [SerializeField] GameObject[] enemys;
    //�@���ɓG���o������܂ł̎���
    [SerializeField] float appearNextTime;
    //�@���̏ꏊ����o������G�̐�
    [SerializeField] int maxNumOfEnemys;
    //�@�����l�̓G���o�����������i�����j
    private int numberOfEnemys;
    //�@�҂����Ԍv���t�B�[���h
    private float elapsedTime;
    //�@���̃L�����Ƃ̋���
    public float radius;
    [SerializeField] GameObject Player;

    private int vecX;
    private int vecZ;
    private int fieldSize = 25;

    // Start is called before the first frame update
    void Start()
    {
        numberOfEnemys = 0;
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //�@���̏ꏊ����o������ő吔�𒴂��Ă��牽�����Ȃ�
        if (numberOfEnemys >= maxNumOfEnemys)
        {
            return;
        }
        //�@�o�ߎ��Ԃ𑫂�
        elapsedTime += Time.deltaTime;

        //�@�o�ߎ��Ԃ��o������
        if (elapsedTime > appearNextTime)
        {
            elapsedTime = 0f;

            AppearEnemy();
        }
    }

    //�G�o�����\�b�h
    void AppearEnemy()
    {
        vecX = Random.Range(-fieldSize, fieldSize);
        vecZ = Random.Range(-fieldSize, fieldSize);
        //vecX = 0;
        //vecZ = 20;
        //�o��������G�������_���ɑI��
        var randomValue = Random.Range(0, enemys.Length);
        //�@�G�̌����������_���Ɍ���
        var randomRotationY = Random.value * 360f;

        var enemy = Instantiate(enemys[randomValue], new Vector3(vecX, 0, vecZ), Quaternion.Euler(0f, randomRotationY, 0f));
        var ene = enemy.GetComponent<EnemyShot>();
        if (ene != null)
        {
            ene.player = Player;
        }

        var ene2 = enemy.GetComponent<EnemyMove2>();
        if (ene2 != null)
        {
            ene2.player = Player;
        }

        numberOfEnemys++;
        elapsedTime = 0f;
    }
}
