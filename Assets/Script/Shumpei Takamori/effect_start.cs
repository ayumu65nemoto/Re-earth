using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect_start : MonoBehaviour
{

	//�@�o��������G�t�F�N�g
	[SerializeField]
	private GameObject effectObject;
	//�@�G�t�F�N�g�������b��
	[SerializeField]
	private float deleteTime;
	//�@�G�t�F�N�g�̏o���ʒu�̃I�t�Z�b�g�l
	[SerializeField]
	private float offset;

	// Use this for initialization
	void Start()
	{

		//�@�Q�[���I�u�W�F�N�g���Ŏ��ɃG�t�F�N�g���C���X�^���X��
		var instantiateEffect = GameObject.Instantiate(effectObject, transform.position + new Vector3(0f, offset, 0f), Quaternion.identity) as GameObject;
		Destroy(instantiateEffect, deleteTime);
	}
}