using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Text text;
    
   private void Start()
    {
        if (Application.isMobilePlatform)
        {
            text.text = "Загрузка, пожалуйста подождите...(На мобильных устройствах она дольше, но игра того стоит!)";
        }
      StartCoroutine( CorLoadScene(LevelSelector.NameLevel));
    }
    IEnumerator CorLoadScene(string name)
    {
        var scene = SceneManager.LoadSceneAsync(name);
        scene.allowSceneActivation = false;

       while (scene.progress > 90) 
        { 
        
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        scene.allowSceneActivation = true;
    }
}
