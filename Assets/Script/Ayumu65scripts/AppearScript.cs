using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearScript : MonoBehaviour
{
    //　出現させる敵を入れておく
    [SerializeField] GameObject[] enemys;
    //　次に敵が出現するまでの時間
    [SerializeField] float appearNextTime;
    //　この場所から出現する敵の数
    [SerializeField] int maxNumOfEnemys;
    //　今何人の敵を出現させたか（総数）
    public int numberOfEnemys;
    //　待ち時間計測フィールド
    private float elapsedTime;
    //　他のキャラとの距離
    public float radius;
    [SerializeField] GameObject Player;
    [SerializeField] public PlayerMove playerMove;
    [SerializeField] public AppearScript appearScript;

    private int vecX;
    private int vecZ;
    private int fieldSize = 25;

    public int deadCount;
    public int deadCount2;

    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        numberOfEnemys = 0;
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //　この場所から出現する最大数を超えてたら何もしない
        if (numberOfEnemys >= maxNumOfEnemys)
        {
            return;
        }
        //　経過時間を足す
        elapsedTime += Time.deltaTime;

        //　経過時間が経ったら
        if (elapsedTime > appearNextTime)
        {
            elapsedTime = 0f;

            AppearEnemy();
        }
    }

    //敵出現メソッド
    public void AppearEnemy()
    {
        vecX = Random.Range(-fieldSize, fieldSize);
        vecZ = Random.Range(-fieldSize, fieldSize);
        //vecX = 0;
        //vecZ = 20;
        //出現させる敵をランダムに選ぶ
        var randomValue = Random.Range(0, enemys.Length);
        //　敵の向きをランダムに決定
        var randomRotationY = Random.value * 360f;

        var enemy = Instantiate(enemys[randomValue], new Vector3(vecX, 0, vecZ), Quaternion.Euler(0f, randomRotationY, 0f));

        //EnemyMove2にPlayerを渡す処理
        var ene = enemy.GetComponent<EnemyMove2>();
        if (ene != null)
        {
            ene.player = Player;
        }

        var ene2 = enemy.GetComponent<EnemyMove>();
        if (ene2 != null)
        {
            ene2.appearScript = appearScript;
        }

        var ene3 = enemy.GetComponent<EnemyMove2>();
        if (ene3 != null)
        {
            ene3.appearScript = appearScript;
        }

        numberOfEnemys++;
        elapsedTime = 0f;
    }
}
