using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public void PlayGame() 
    {
        ManageScene("CharacterCreationScene"); // This loads the Character Creation Scene
    }

    public void Options() 
    {
        ManageScene("OptionsFromMainMenuScene"); // This loads the Options Scene
    }

    public void Credits()
    {
        ManageScene("CreditsScene"); // This loads the Credits Scene
    }

    public void QuitGame()
    {
        Application.Quit(); // This forcibly terminates the program.
    }

    public void ManageScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene); // This loads the scene with the name that has been placed within the parameters.
    }
}
