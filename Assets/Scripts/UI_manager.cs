using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// script for updating the miles on the screen
public class UI_manager : MonoBehaviour
{
    // reference to the text
    [SerializeField] private Text _milesText;
    
    // update miles (through spawn manager) and display on screen
    public void updateMiles(int miles)
    {
        _milesText.text = "Miles: " + miles;
    }
}
