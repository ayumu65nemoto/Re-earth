using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public enum EnemyState
    {
        Walk,
        Wait,
        Chase,
        Attack,
        Freeze,
        Damage,
        Dead
    };

    private CharacterController cCon;
    private Animator animator;
    private Vector3 destination;    //目的地
    [SerializeField]
    private float walkSpeed = 1.0f; //移動スピード
    private Vector3 velocity;   //速度
    private Vector3 direction;  //移動方向
    private bool arrived;   //到着フラグ
    private SetPosition setPosition;
    private PlayerMove playerMove;
    [SerializeField]
    private float waitTime = 5f;
    private float elapsedTime;  //経過時間
    private EnemyState state;
    private Transform playerTransform;  //プレイヤーの位置
    [SerializeField]
    private float freezeTime = 0.5f;    //フリーズ時間
    [SerializeField]
    private BossStatus bossStatus;
    [SerializeField]
    private SphereCollider sCol;

    public static int deadEnemyBoss;
    public static int clear;

    private int powerCount;
    public int attackPower;
    [SerializeField]
    public int Power = 1;
    [SerializeField]
    private AudioClip speedUpVoice;
    public bool attackSkill;
    public float lapsedTime;

    public GameObject deadEffect;
    public GameObject hitEffect;

    [SerializeField]
    SoundManager soundManager;
    [SerializeField]
    AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        clear = 0;
        deadEnemyBoss = 0;
        cCon = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        setPosition = GetComponent<SetPosition>();
        bossStatus = GetComponent<BossStatus>();
        sCol = GetComponent<SphereCollider>();
        setPosition.CreateRandomPosition();
        destination = setPosition.GetDestination();
        velocity = Vector3.zero;
        arrived = false;
        elapsedTime = 0f;
        SetState(EnemyState.Walk);
        playerMove = GetComponent<PlayerMove>();
        powerCount = 3;
        attackPower = Power;
        attackSkill = true;
        lapsedTime = 0f;
        soundManager = GameObject.FindWithTag("SoundManager")?.GetComponent<SoundManager>(); //SoundManagerを参照
    }

    // Update is called once per frame
    void Update()
    {
        if (state == EnemyState.Walk || state == EnemyState.Chase)
        {
            if (state == EnemyState.Chase)
            {
                setPosition.SetDestination(playerTransform.position);
            }
            if (cCon.isGrounded)
            {
                velocity = Vector3.zero;
                animator.SetFloat("Speed", 2.0f);
                direction = (setPosition.GetDestination() - transform.position).normalized;
                transform.LookAt(new Vector3(setPosition.GetDestination().x, transform.position.y, setPosition.GetDestination().z));
                velocity = direction * walkSpeed;
                //Debug.Log(destination);
            }

            if (state == EnemyState.Walk)
            {
                if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 0.9f)
                {
                    SetState(EnemyState.Wait);
                    animator.SetFloat("Speed", 0.0f);
                }
            }
            else if(state == EnemyState.Chase)
            {
                if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 2.0f)
                {
                    SetState(EnemyState.Attack);
                }
            }

        }
        else if(state == EnemyState.Wait)
        {
            elapsedTime += Time.deltaTime;

            if(elapsedTime > waitTime)
            {
                SetState(EnemyState.Walk);
            }
        }
        else if(state == EnemyState.Freeze)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > freezeTime)
            {
                SetState(EnemyState.Walk);
            }
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        cCon.Move(velocity * Time.deltaTime);

        if (attackSkill == true)
        {
            if (Input.GetKeyDown("joystick button 3") || Input.GetKeyDown(KeyCode.C))
            {
                if (powerCount > 0)
                {
                    StartCoroutine("PowerUp");
                    powerCount -= 1;
                    attackSkill = false;
                }
            }
        }

        if (attackSkill == false)
        {
            lapsedTime += Time.deltaTime;
            if (lapsedTime >= 5)
            {
                attackSkill = true;
                lapsedTime = 0.0f;
            }
        }
    }

    public void TakeDamage()
    {
        soundManager.PlaySe(clip);
        bossStatus.SetHp(bossStatus.GetHp() - attackPower);
        GenerateHitEffect();
        if (bossStatus.GetHp() <= 0)
        {
            Dead();
            deadEnemyBoss += 1000;
            clear = 1;
        }
    }

    void Dead()
    {
        SetState(EnemyState.Dead);
        GenerateDeadEffect();
    }

    public void SetState(EnemyState tempState, Transform targetObj = null)
    {
        state = tempState;

        if (tempState == EnemyState.Walk)
        {
            arrived = false;
            elapsedTime = 0f;
            setPosition.CreateRandomPosition();
        }
        else if (tempState == EnemyState.Chase)
        {
            arrived = false;
            playerTransform = targetObj;
        }
        else if (tempState == EnemyState.Wait)
        {
            elapsedTime = 0f;
            arrived = true;
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 0f);
        }
        else if (tempState == EnemyState.Attack)
        {
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 0f);
            animator.SetBool("Attack", true);
        }
        else if (tempState == EnemyState.Freeze)
        {
            elapsedTime = 0f;
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 0f);
            animator.SetBool("Attack", false);
        }
        else if (tempState == EnemyState.Dead)
        {
            animator.SetTrigger("Dead");
            Destroy(this.gameObject, 1f);
            velocity = Vector3.zero;
        }
    }

    public EnemyState GetState()
    {
        return state;
    }

    public static int GetdeadEnemyBoss()
    {
        return deadEnemyBoss;
    }

    public static int GetdeadEnemyclear()
    {
        return clear;
    }

    IEnumerator PowerUp()
    {
        attackPower *= 2;
        yield return new WaitForSeconds(5.0f);
        attackPower = Power;
    }

    void GenerateDeadEffect()
    {
        //エフェクトを生成する
        GameObject dead_effect = Instantiate(deadEffect) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        dead_effect.transform.position = gameObject.transform.position;
        //エフェクトを消す
        Destroy(dead_effect, 2.0f);
    }

    void GenerateHitEffect()
    {
        //エフェクトを生成する
        GameObject hit_effect = Instantiate(hitEffect) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        hit_effect.transform.position = gameObject.transform.position;
        //エフェクトを消す
        Destroy(hit_effect, 1.5f);
    }
}
