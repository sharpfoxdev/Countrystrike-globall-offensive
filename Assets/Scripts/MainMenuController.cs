using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.InputSystem;

/// <summary>
/// Controls main menu
/// </summary>
public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    int numberOfPlayers = 4;
    [SerializeField]
    GameObject playerPrefab;
    [SerializeField]
    SkinSelector skinSelector = default;
    [SerializeField]
    GameObject controlsMenu;
    [SerializeField]
    GameObject playerManager;

    SpriteLibrary spriteLibrary = default;
    List<GameObject> dummyPlayers = new List<GameObject>(); //used to set up skins, further set up of players is done in Multiplayer manager (linking with control schemes)
    SpriteLibraryAsset libraryAsset;

    /// <summary>
    /// Sets up sprite library, is called right before OnEnable
    /// </summary>
    private void Awake()
    {
        spriteLibrary = playerPrefab.GetComponentInChildren<SpriteLibrary>(); //fetches sprite library (list of sprites for given player)
        libraryAsset = spriteLibrary.spriteLibraryAsset;
    }

    /// <summary>
    /// Called after in the beginning and after gameOver to set up menu, spawn characters and set their 
    /// </summary>
    public void OnEnable()
    {
        GameObject[] selectorsDummy = GameObject.FindGameObjectsWithTag("SkinSelector");
        foreach (GameObject selector in selectorsDummy) //so that we delete old SkinSelectors from last game, otherwise, we would create new ones over old ones
        {
            Destroy(selector);
        }
        dummyPlayers.Clear();
        for (int i = 0; i < numberOfPlayers; i++)
        {
            GameObject player = Instantiate(playerPrefab);
            player.SetActive(false); //so it doesnt render
            player.GetComponent<Player>().PlayerNumber = i;
            player.GetComponentInChildren<EyeSelector>().SelectRandomEyes(); 
            //sprite resolver chooses sprite from sprite library, it is in the child Body of Player
            AddUISkinSelector(player.GetComponentInChildren<SpriteResolver>(), i); //so every player changes sprites separately according to what's chosen in the menu
            dummyPlayers.Add(player);
        }
    }


    /// <summary>
    /// Creates list of drop down menus to choose skins from
    /// </summary>
    /// <param name="resolver">Takes care of resolving which sprite froom SpriteLibrary should be used</param>
    /// <param name="playerNUmber">Player's number to distinguish between players</param>
    public void AddUISkinSelector(SpriteResolver resolver, int playerNUmber)
    {
        string[] labels = libraryAsset.GetCategorylabelNames("PlayerSkin").ToArray(); //gets labels from library of sprites
        SkinSelector selector = Instantiate(skinSelector, transform);
        selector.Init(playerNUmber, resolver, labels);
    }



    /// <summary>
    /// Sets up new game
    /// </summary>
    public void PlayButtonClicked()
    {
        for (int i = dummyPlayers.Count - 1; i >= 0; i--)//going in reverse, because I am deleting from list while iterating it, which messes up indexes when iterating normally
        {
            if (dummyPlayers[i].GetComponentInChildren<SpriteResolver>().GetLabel() == "None"){ //we delete players that we don't want to play with
                GameObject player = dummyPlayers[i];
                dummyPlayers.RemoveAt(i);
                Destroy(player);
            }
        }
        MultiplayerManager multiplayerManager = playerManager.GetComponent<MultiplayerManager>();
        multiplayerManager.Init(dummyPlayers); 
        foreach(GameObject player in dummyPlayers) //destroys dummy players, otherwise there would be copies, as they will be instantiated once more with control schemes in MultiplayerManager
        {
            Destroy(player);
        }
        gameObject.SetActive(false); //shows game area
    }

    /// <summary>
    /// Shuts down the application
    /// </summary>
    public void ExitButtonClicked()
    {
        Application.Quit();
    }

    /// <summary>
    /// Goes to controls menu
    /// </summary>
    public void ControlsButtonClicked()
    {
        controlsMenu.SetActive(true);
    }
}
