using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMenuScene: MonoBehaviour 
{
	void OnEnable()
	{
		SceneManager.LoadScene("Menu",LoadSceneMode.Single);
	}
}

