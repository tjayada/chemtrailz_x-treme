using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// script for the buttons that show up at the end of the game
public class EndButton_script : MonoBehaviour
{
    // reference to the "play again" and the "back to the menu" buttons
    public GameObject AgainButton;
    public GameObject BackButton;

    void Start()
    {
        // at the start of the game the buttons will be invisible
        AgainButton.SetActive(false);
        BackButton.SetActive(false);
        
    }

    // function to make buttons visible again
    public void ShowButtons()
    {
        // make buttons visible
        AgainButton.SetActive(true);
        BackButton.SetActive(true);
    }
    
    // play again button starts the game scene again
    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }	
    
    // go back button loads the menu scene
    public void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }	
}
