using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
	//“G‚ÌHP
	[SerializeField]
	private int hp = 5;

	public void SetHp(int hp)
	{
		this.hp = hp;
	}

	public int GetHp()
	{
		return hp;
	}
}
