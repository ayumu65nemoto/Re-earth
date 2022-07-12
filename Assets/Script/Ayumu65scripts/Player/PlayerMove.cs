using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController cCon;
	private Rigidbody rb;
    private Vector3 velocity;
    [SerializeField]
    private float Speed;
	private float walkSpeed;
    private Animator animator;
	private MyState state;

	private int avoidCount;
	private int attackCount;
	private int speedCount;
	private int powerCount;
	public int attackPower;
	[SerializeField]
	public int Power;

	public float jumpPower = 10f;
	public GameObject cam;
	public Vector3 Cam_forward;
	public Vector3 move_forward;
	public Vector3 InputMagnitude;
	public float InputHorizontal;
	public float InputVertical;
	public float InputB;
	public float gravity;
	//�@���C���΂��ʒu
	[SerializeField]
	private Transform rayPosition;
	//�@���C�̋���
	[SerializeField]
	private float rayRange = 1.0f;
	//�@���C���n�ʂɓ��B���Ă��邩�ǂ���
	private bool isGround = false;
	//�@�������ɋ����I�ɉ������
	[SerializeField]
	private Vector3 addForceDownPower = Vector3.down;

	private AudioSource audioSource;
	[SerializeField]
	private AudioClip attackVoice1;
	[SerializeField]
	private AudioClip attackVoice2;
	[SerializeField]
	private AudioClip attackVoice3;
	[SerializeField]
	private AudioClip damageVoice;
	[SerializeField]
	private AudioClip avoidVoice;
	[SerializeField]
	private AudioClip speedUpVoice;

	public enum MyState
	{
		Normal,
		Damage,
		Attack,
		Fall
	};

	public void SetState(MyState tempState)
	{
		if (tempState == MyState.Normal)
		{
			state = MyState.Normal;
		}
		else if (tempState == MyState.Attack)
		{
			velocity = Vector3.zero;
			state = MyState.Attack;
			animator.SetTrigger("Attack");
		}
	}

	// Start is called before the first frame update
	void Start()
    {
        cCon = GetComponent<CharacterController>();
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
        velocity = Vector3.zero;
		avoidCount = 5;
		attackCount = 0;
		speedCount = 3;
		powerCount = 3;
		walkSpeed = Speed;
		audioSource = GetComponent<AudioSource>();
	}


	// Update is called once per frame
	void Update()
	{
		if (state == MyState.Normal) {
			if (!cCon.isGrounded)
			{

				if (Physics.Linecast(rayPosition.position, (rayPosition.position - transform.up * rayRange)))
				{
					isGround = true;
				}
				else
				{
					isGround = false;
				}

				//�@�ڒn�m�F�p�Ƀ��C�����o��
				Debug.DrawLine(rayPosition.position, (rayPosition.position - transform.up * rayRange), Color.red);
				velocity.y += Physics.gravity.y * Time.deltaTime;
				cCon.Move(velocity * Time.deltaTime);
				animator.SetBool("Fall", true);
			}

			if (cCon.isGrounded || isGround)
			{
				//velocity.y = 0f;  //Y�����ւ̑��x���[���ɂ���
				animator.SetBool("Fall", false);
								  //�@�n�ʂɐڒn���Ă鎞�͑��x��������
				if (cCon.isGrounded)
				{
					velocity = Vector3.zero;
					//�@���C���΂��Đڒn�m�F�̏ꍇ�͏d�͂����͓������Ă����A�O�㍶�E�͏�����
				}
				else
				{
					velocity = new Vector3(0f, velocity.y, 0f);
				}

				InputHorizontal = Input.GetAxis("Horizontal");  //���̓���
				InputVertical = Input.GetAxis("Vertical");      //�c�̓���
				var input = new Vector3(InputHorizontal, 0f, InputVertical);

				//�@�����L�[������������Ă���
				if (input.magnitude > 0f
					&& !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")
					&& !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2")
					&& !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack3")
				)
				{
					animator.SetFloat("Speed", input.magnitude);
				}
				else
				{
					animator.SetFloat("Speed", 0f);
				}

				//if (Input.GetKeyDown(KeyCode.Space)
				//&& !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump")
				//)
				//{
				//	animator.SetTrigger("Jump");
				//	velocity.y += jumpPower;
				//}

				if (Input.GetKeyDown(KeyCode.E))
                {
					if (speedCount > 0)
                    {
						StartCoroutine("SpeedUp");
						speedCount -= 1;
					}
				}

				if (Input.GetKeyDown(KeyCode.Z))
                {
					if (powerCount > 0)
                    {
						StartCoroutine("PowerUp");
						powerCount -= 1;
                    }
                }

				//Vector3.Scale(a, b); -> a��b���|�����u�O�����x�N�g���v���擾�ł���
				Cam_forward = Vector3.Scale(cam.transform.forward, new Vector3(1, 0, 1)).normalized;    //�u�J�����́v����

				move_forward = Cam_forward * InputVertical + cam.transform.right * InputHorizontal;

				velocity = move_forward * walkSpeed + new Vector3(0, velocity.y, 0);

				velocity.y += Physics.gravity.y * Time.deltaTime;

				cCon.Move(velocity * Time.deltaTime);

				//�ړ������Ɍ�����ς���
				//Vector3.zero -> Vector3(0, 0, 0) x, y, z�Ƃ��ɑS�ĂO�̏��
				//�u!=�v-> �������Ȃ�
				if (move_forward != Vector3.zero)
				{
					this.transform.rotation = Quaternion.LookRotation(move_forward);
					//Debug.Log("a");
				}

				if (Input.GetKeyDown("joystick button 3") || Input.GetKeyDown(KeyCode.Q))
				{
					if (avoidCount > 0)
					{
						audioSource.PlayOneShot(avoidVoice);
						velocity = move_forward * walkSpeed * 100 + new Vector3(0, velocity.y, 0);
						cCon.Move(velocity * Time.deltaTime);
						avoidCount -= 1;
					}
				}
			}

			if (Input.GetButtonDown("Fire1")
					&& !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")
					&& !animator.IsInTransition(0)
				)
			{
				attackCount += 1;
				animator.SetTrigger("Attack");
				SetState(MyState.Attack);
				//Debug.Log(state);
				if (attackCount  < 3)
                {
					audioSource.PlayOneShot(attackVoice1);
				}
				
				if (attackCount == 3)
                {
					audioSource.PlayOneShot(attackVoice3);
					attackCount = 0;
				}
			}
		}
	}

	public void TakeDamage(Transform enemyTransform)
	{
		audioSource.PlayOneShot(damageVoice);
		state = MyState.Damage;
		velocity = Vector3.zero;
		animator.SetTrigger("Damage");
		GetComponent<PlayerStatus>().Damage();
	}

	public void TakeBossDamage(Transform enemyTransform)
    {
		audioSource.PlayOneShot(damageVoice);
		state = MyState.Damage;
		velocity = Vector3.zero;
		animator.SetTrigger("Damage");
		GetComponent<PlayerStatus>().BossDamage();
	}

	IEnumerator SpeedUp()
	{
		audioSource.PlayOneShot(speedUpVoice);
		walkSpeed *= 5.0f;
		yield return new WaitForSeconds(3.0f);
		walkSpeed = Speed;
	}

	IEnumerator PowerUp()
	{
		audioSource.PlayOneShot(speedUpVoice);
		attackPower *= 5;
		yield return new WaitForSeconds(3.0f);
		attackPower = Power;
	}

	public int Attack()
    {
		return attackPower;
    }
}
