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
    private Vector3 destination;    //�ړI�n
    [SerializeField]
    private float walkSpeed = 1.0f; //�ړ��X�s�[�h
    private Vector3 velocity;   //���x
    private Vector3 direction;  //�ړ�����
    private bool arrived;   //�����t���O
    private SetPosition setPosition;
    private PlayerMove playerMove;
    [SerializeField]
    private float waitTime = 5f;
    private float elapsedTime;  //�o�ߎ���
    private EnemyState state;
    private Transform playerTransform;  //�v���C���[�̈ʒu
    [SerializeField]
    private float freezeTime = 0.5f;    //�t���[�Y����
    [SerializeField]
    private EnemyStates enemyStates;
    [SerializeField]
    private SphereCollider sCol;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip damageSound;

    public static int deadEnemyBoss;
    public static int clear;

    // Start is called before the first frame update
    void Start()
    {
        clear = 0;
        deadEnemyBoss = 0;
        cCon = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        setPosition = GetComponent<SetPosition>();
        enemyStates = GetComponent<EnemyStates>();
        sCol = GetComponent<SphereCollider>();
        setPosition.CreateRandomPosition();
        destination = setPosition.GetDestination();
        velocity = Vector3.zero;
        arrived = false;
        elapsedTime = 0f;
        SetState(EnemyState.Walk);
        audioSource = GetComponent<AudioSource>();
        playerMove = GetComponent<PlayerMove>();
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
                if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 0.7f)
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
    }

    public void TakeDamage()
    {
        audioSource.PlayOneShot(damageSound);
        enemyStates.SetHp(enemyStates.GetHp() - playerMove.attackPower);
        if (enemyStates.GetHp() <= 0)
        {
            Dead();
            deadEnemyBoss += 1000;
            clear = 1;
        }
    }

    void Dead()
    {
        SetState(EnemyState.Dead);
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
        else if (tempState == EnemyState.Damage)
        {
            velocity = Vector3.zero;
            animator.SetBool("Attack", false);
            animator.SetTrigger("Damage");
        }
        else if (tempState == EnemyState.Dead)
        {
            animator.SetTrigger("Dead");
            Destroy(this.gameObject, 3f);
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
}
