using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController cCon;
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

	public GameObject cam;
	public Vector3 Cam_forward;
	public Vector3 move_forward;
	public Vector3 InputMagnitude;
	private float InputHorizontal;
	private float InputVertical;
	public float InputB;
	public float gravity;
	//　レイを飛ばす位置
	[SerializeField]
	private Transform rayPosition;
	//　レイの距離
	[SerializeField]
	private float rayRange = 3.0f;
	//　レイが地面に到達しているかどうか
	private bool isGround = false;
	//　下方向に強制的に加える力
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

	public bool avoidSkill;
	public bool speedSkill;
	public float avoidTime;
	public float speedTime;

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
		animator = GetComponent<Animator>();
        velocity = Vector3.zero;
		avoidCount = 5;
		attackCount = 0;
		speedCount = 5;
		powerCount = 5;
		walkSpeed = Speed;
		audioSource = GetComponent<AudioSource>();
		attackPower = Power;
		avoidSkill = true;
		speedSkill = true;
		avoidTime = 0f;
		speedTime = 0f;
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

				//　接地確認用にレイを視覚化
				Debug.DrawLine(rayPosition.position, (rayPosition.position - transform.up * rayRange), Color.red);
				velocity.y += Physics.gravity.y * Time.deltaTime;
				cCon.Move(velocity * Time.deltaTime);
				animator.SetBool("Fall", true);
			}

			if (cCon.isGrounded || isGround)
			{
				//velocity.y = 0f;  //Y方向への速度をゼロにする
				animator.SetBool("Fall", false);
								  //　地面に接地してる時は速度を初期化
				//if (cCon.isGrounded)
				//{
				//	velocity = Vector3.zero;
				//	//　レイを飛ばして接地確認の場合は重力だけは働かせておく、前後左右は初期化
				//}
				//else
				//{
				//	velocity = new Vector3(0f, velocity.y, 0f);
				//}

				InputHorizontal = Input.GetAxis("Horizontal");  //横の入力
				InputVertical = Input.GetAxis("Vertical");      //縦の入力
				var input = new Vector3(InputHorizontal, 0f, InputVertical);

				//　方向キーが多少押されている
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

                if (speedSkill == true)
				{
					if (Input.GetKeyDown("joystick button 4") || Input.GetKeyDown(KeyCode.E))
					{
						if (speedCount > 0)
						{
							StartCoroutine("SpeedUp");
							speedCount -= 1;
							speedSkill = false;
						}
					}
				}

				if (speedSkill == false)
				{
					speedTime += Time.deltaTime;
					if (speedTime >= 5)
					{
						speedSkill = true;
						speedTime = 0.0f;
					}
				}

				//Vector3.Scale(a, b); -> aとbを掛けた「三次元ベクトル」を取得できる
				Cam_forward = Vector3.Scale(cam.transform.forward, new Vector3(1, 0, 1)).normalized;    //「カメラの」正面

				move_forward = Cam_forward * InputVertical + cam.transform.right * InputHorizontal;

				velocity = move_forward * walkSpeed;

				cCon.Move(velocity * Time.deltaTime);

				//移動方向に向きを変える
				//Vector3.zero -> Vector3(0, 0, 0) x, y, zともに全て０の状態
				if (move_forward != Vector3.zero)
				{
					this.transform.rotation = Quaternion.LookRotation(move_forward);
					//Debug.Log("a");
				}

				if (avoidSkill == true)
				{
					if (Input.GetKeyDown("joystick button 5") || Input.GetKeyDown(KeyCode.Q))
					{
						if (avoidCount > 0)
						{
							audioSource.PlayOneShot(avoidVoice);
							velocity = move_forward * walkSpeed * 50 + new Vector3(0, velocity.y, 0);
							cCon.Move(velocity * Time.deltaTime);
							avoidCount -= 1;
							avoidSkill = false;
						}
					}
				}

				if (avoidSkill == false)
				{
					avoidTime += Time.deltaTime;
					if (avoidTime >= 5)
					{
						avoidSkill = true;
						avoidTime = 0.0f;
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

	public void TakeHeal()
    {
		GetComponent<PlayerStatus>().Heal();
    }

	IEnumerator SpeedUp()
	{
		audioSource.PlayOneShot(speedUpVoice);
		walkSpeed *= 1.5f;
		yield return new WaitForSeconds(5.0f);
		walkSpeed = Speed;
	}
}
