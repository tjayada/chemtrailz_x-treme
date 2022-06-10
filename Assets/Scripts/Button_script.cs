using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

// This script contains all of the scenes a button could take you
public class Button_script : MonoBehaviour
{
    // Loads the actual Game 
    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }	
    
    // This buttons brings you to the menu
    public void BackButton()
    {
        SceneManager.LoadScene("Menu");
    }	
    
    // This button brings you to the "how everything works" page
    public void HowToButton()
    {
        SceneManager.LoadScene("What");
    }	
    
    // This brings you to the credits, so the producers of the game
    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }	
    
    public void QuitButton()
    {
       Application.Quit();
    }	
    
}   