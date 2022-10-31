using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
  public Animator transition;

  public float transitionTime = 1f;

   void Update()
   {
        if(Input.GetMouseButtonDown(3))
        {
            LoadNextLevel();
        }
   }

   public void LoadNextLevel()
   
   {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
   }

   IEnumerator LoadLevel(int levelIndex)
   {
        // PlayAnimation
        transition.SetTrigger("Start");
        
         // Wait
         yield return new WaitForSeconds(transitionTime); // pouse before continue 

         // Load scene

         SceneManager.LoadScene(levelIndex);
   }
}
