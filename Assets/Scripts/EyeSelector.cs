using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using System.Linq;

/// <summary>
/// Class for selecting skin of eyes
/// </summary>
public class EyeSelector : MonoBehaviour
{
    SpriteLibraryAsset libraryAsset;
    SpriteResolver resolver;
    string skinCategoryLabel = "Eyes";

    /// <summary>
    /// Selects random eyes from the list of available eye skins
    /// </summary>
    public void SelectRandomEyes()
    {
        string[] labels = libraryAsset.GetCategorylabelNames(skinCategoryLabel).ToArray();
        int randomIndex = Random.Range(0, labels.Length);
        string label = labels[randomIndex];
        resolver.SetCategoryAndLabel(skinCategoryLabel, label);
    }
    private void Awake()
    {
        libraryAsset = GetComponent<SpriteLibrary>().spriteLibraryAsset; //fetches sprite library (list of sprites for given player)
        resolver = GetComponent<SpriteResolver>();
    }
}
