using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Experimental.U2D.Animation;

public class SkinSelector : MonoBehaviour
{
    [SerializeField]
    private Text textLabel;
    [SerializeField]
    private Dropdown dropdown;
    public string SkinCategoryLabel = "PlayerSkin";

    public void Init(int playerNumber, SpriteResolver resolver, string[] labels)
    {
        textLabel.text = "Player" + (playerNumber+1).ToString();
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
            resolver.SetCategoryAndLabel(SkinCategoryLabel, label);
        });
    }
}
