using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMenuTrigger: MonoBehaviour 
{
	void OnEnable()
	{
		SceneManager.LoadScene("Menu",LoadSceneMode.Single);
	}
}

