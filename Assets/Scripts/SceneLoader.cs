using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
  
   
   private void Start()
    {
      StartCoroutine( CorLoadScene());
    }
    IEnumerator CorLoadScene()
    {
        var scene = SceneManager.LoadSceneAsync(LevelSelector.NameLevel);
        scene.allowSceneActivation = false;

       while (scene.progress > 90) 
        { 
        
            yield return null;
        }
       scene.allowSceneActivation = true;
    }
}
