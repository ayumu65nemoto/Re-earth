using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlScenesScript : MonoBehaviour
{

	public void StringArgFunction(string s)
	{
		SceneManager.LoadScene(s);
	}
}