using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for handling section of menu with controls
/// </summary>
public class ControlsMenu : MonoBehaviour
{
    /// <summary>
    /// Disables this menu and returns to main menu
    /// </summary>
    public void BackButtonPressed()
    {
        gameObject.SetActive(false);
    }
}
