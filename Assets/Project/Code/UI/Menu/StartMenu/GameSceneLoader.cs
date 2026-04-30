using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Code.UI.Menu.StartMenu
{
    public class GameSceneLoader 
    {
        private const string GameScene = "GameScene";
        
        public void LoadGameScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(GameScene);
        }
    }
}
