using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Experimental.U2D.Animation;

/// <summary>
/// Dropdown menu to choose skin of player
/// </summary>
public class SkinSelector : MonoBehaviour
{
    [SerializeField]
    private Text textLabel;
    [SerializeField]
    private Dropdown dropdown;
    public string SkinCategoryLabel = "PlayerSkin";

    /// <summary>
    /// Creates drop down menu for picking skin for the given player
    /// </summary>
    /// <param name="playerNumber">Player number</param>
    /// <param name="resolver">Sprite resolver, that pics sprite from sprite library</param>
    /// <param name="labels">Labels of sprites in sprite library, that are put into drop down menu</param>
    public void Init(int playerNumber, SpriteResolver resolver, string[] labels)
    {
        textLabel.text = "Player" + (playerNumber+1).ToString(); //label next to the dropdown menu
        List<Dropdown.OptionData> skinLabels = new List<Dropdown.OptionData>();

        foreach (string label in labels)
        {
            Dropdown.OptionData data = new Dropdown.OptionData(label);
            skinLabels.Add(data);
        }
        
        dropdown.options = skinLabels;

        //selecting from dropdown
        dropdown.onValueChanged.AddListener(optionIndex =>
        {
            string label = labels[optionIndex]; //gets label by index of what is chosen
            resolver.SetCategoryAndLabel(SkinCategoryLabel, label); //changes skin via resolver
        });
    }
}
