using UnityEngine;
using System.Collections;
using UnityEngine.UI; // UI�R���|�[�l���g�̎g�p

public class ControlButtonSettingScript : MonoBehaviour
{
	Button Title;


	void Start()
	{
		// �{�^���R���|�[�l���g�̎擾
		Title = GameObject.Find("/Canvas/Button1").GetComponent<Button>();

		// �ŏ��ɑI����Ԃɂ������{�^���̐ݒ�
		Title.Select();
	}
}