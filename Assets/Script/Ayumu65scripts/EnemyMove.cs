using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public enum EnemyState
    {
        Walk,
        Wait,
        Chase,
        Attack,
        Freeze
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
    [SerializeField]
    private float waitTime = 5f;
    private float elapsedTime;  //�o�ߎ���
    private EnemyState state;
    private Transform playerTransform;  //�v���C���[�̈ʒu
    [SerializeField]
    private float freezeTime = 0.5f;    //�t���[�Y����

    // Start is called before the first frame update
    void Start()
    {
        cCon = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        setPosition = GetComponent<SetPosition>();
        setPosition.CreateRandomPosition();
        destination = setPosition.GetDestination();
        velocity = Vector3.zero;
        arrived = false;
        elapsedTime = 0f;
        SetState(EnemyState.Walk);
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
                if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 1.3f)
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
    }

    public EnemyState GetState()
    {
        return state;
    }
}
