using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JourneyEmbark : MonoBehaviour
{    
    public void BeginJourney()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
