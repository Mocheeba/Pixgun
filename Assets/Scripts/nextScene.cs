using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene: MonoBehaviour 
{
	void OnEnable()
	{
		SceneManager.LoadScene("Dungeon_Marcel_Produkcja 1",LoadSceneMode.Single);
	}
}

