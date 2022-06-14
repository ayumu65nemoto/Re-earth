using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController cCon;
	private Rigidbody rb;
    private Vector3 velocity;
    [SerializeField]
    private float walkSpeed;
    private Animator animator;
	private MyState state;
	private int avoidCount;
	public float jumpPower = 10f;
	public GameObject cam;
	public Vector3 Cam_forward;
	public Vector3 move_forward;
	public Vector3 InputMagnitude;
	public float InputHorizontal;
	public float InputVertical;
	//　レイを飛ばす位置
	[SerializeField]
	private Transform rayPosition;
	//　レイの距離
	[SerializeField]
	private float rayRange = 1.0f;
	//　レイが地面に到達しているかどうか
	private bool isGround = false;
	//　下方向に強制的に加える力
	[SerializeField]
	private Vector3 addForceDownPower = Vector3.down;

	public enum MyState
	{
		Normal,
		Damage,
		Attack
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

			}

			if (cCon.isGrounded || isGround)
			{
				//　地面に接地してる時は速度を初期化
				if (cCon.isGrounded)
				{
					velocity = Vector3.zero;
					//　レイを飛ばして接地確認の場合は重力だけは働かせておく、前後左右は初期化
				}
				else
				{
					velocity = new Vector3(0f, velocity.y, 0f);
				}

				InputHorizontal = Input.GetAxis("Horizontal");  //横の入力
				InputVertical = Input.GetAxis("Vertical");      //縦の入力
				var input = new Vector3(InputHorizontal, 0f, InputVertical);

				//　方向キーが多少押されている
				if (input.magnitude > 0f
					&& !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")
				)
				{
					animator.SetFloat("Speed", input.magnitude);
				}
				else
				{
					animator.SetFloat("Speed", 0f);
				}

				if (Input.GetKeyDown(KeyCode.Q))
                {
					if (avoidCount > 0)
                    {
						velocity += input.normalized * walkSpeed * 300;
						cCon.Move(velocity * Time.deltaTime);
						avoidCount -= 1;
					}
				}

				/*if (Input.GetKeyDown(KeyCode.Space)
				&& !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump")
				)
				{
					animator.SetTrigger("Jump");
					velocity.y += jumpPower;
				}*/

				/*if (Input.GetKeyDown(KeyCode.Space))
				{
					velocity.y += jumpPower;
					Debug.Log("Jump");
				}*/

				//Vector3.Scale(a, b); -> aとbを掛けた「三次元ベクトル」を取得できる
				Cam_forward = Vector3.Scale(cam.transform.forward, new Vector3(1, 0, 1)).normalized;    //「カメラの」正面

				move_forward = Cam_forward * InputVertical + cam.transform.right * InputHorizontal;

				velocity = move_forward * walkSpeed + new Vector3(0, velocity.y, 0);

				cCon.Move(velocity * Time.deltaTime);

				//移動方向に向きを変える
				//Vector3.zero -> Vector3(0, 0, 0) x, y, zともに全て０の状態
				//「!=」-> 等しくない
				if (move_forward != Vector3.zero)
				{
					this.transform.rotation = Quaternion.LookRotation(move_forward);
					//Debug.Log("a");
				}
			}

			/*if (Input.GetKeyDown("space") && cCon.isGrounded)
			{
				cCon.Move(new Vector3(0, jumpPower, 0));
			}*/

			if (Input.GetButtonDown("Fire1")
					&& !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")
					&& !animator.IsInTransition(0)
				)
			{
				animator.SetTrigger("Attack");
				SetState(MyState.Attack);
				//Debug.Log(state);
			}
		}
	}

	public void TakeDamage(Transform enemyTransform)
	{
		state = MyState.Damage;
		velocity = Vector3.zero;
		animator.SetTrigger("Damage");
		//Debug.Log("Damage");
	}
}
