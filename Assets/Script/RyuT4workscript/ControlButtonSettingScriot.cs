using UnityEngine;
using System.Collections;
using UnityEngine.UI; // UIコンポーネントの使用

public class ControlButtonSettingScript : MonoBehaviour
{
	Button Title;


	void Start()
	{
		// ボタンコンポーネントの取得
		Title = GameObject.Find("/Canvas/Button1").GetComponent<Button>();

		// 最初に選択状態にしたいボタンの設定
		Title.Select();
	}
}