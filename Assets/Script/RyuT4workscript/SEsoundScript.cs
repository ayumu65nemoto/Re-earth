using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SEsoundScript : MonoBehaviour
{
	private AudioSource audioSource;

	public void Event()
	{
		audioSource.Play();
	}
}
