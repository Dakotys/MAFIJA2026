using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame(int sceneNumber)
   {
      SceneManager.LoadSceneAsync(sceneNumber);
        
   }
    public void SstartNewGame(int sceneNumber)
    {
        SceneManager.LoadSceneAsync(sceneNumber);
        GlobalVars.ResetToDefaults();

    }
    public void Quit()
    {
        Application.Quit();
    }

}
