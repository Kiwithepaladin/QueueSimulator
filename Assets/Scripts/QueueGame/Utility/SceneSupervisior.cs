using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FillingGround.QueueGame.Utilities
{
    public class SceneSupervisior : MonoBehaviour
    {
        public static SceneSupervisior Instance;

        private void Awake() 
        {
            if(Instance != null)
            {
                Destroy(this); 
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            //Currently hard coded for simpleicity sake
            StartCoroutine(LoadLevelAsync("QueueGameMiniGamesScene"));
            
        }
        private IEnumerator LoadLevelAsync(string newSceneName)
        {
            if(IsSceneLoaded(newSceneName))
            {
                yield return null;
            }
            else
            {
                AsyncOperation progress = SceneManager.LoadSceneAsync(newSceneName,LoadSceneMode.Additive);
                while(!progress.isDone)
                {
                    yield return null;
                }
            }
        }
        public bool IsSceneLoaded(string sceneName_no_extention) 
        {
            for(int i = 0; i<SceneManager.sceneCount; ++i) 
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if(scene.name == sceneName_no_extention)
                    return true;
            }
            return false;
        }
    }
}
