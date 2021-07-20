using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    int numberOfPlayers = 4;
    [SerializeField]
    GameObject playerPrefab;
    SpriteLibrary spriteLibrary;
    [SerializeField]
    SkinSelector skinSelector = default;

    List<GameObject> players = new List<GameObject>();
    SpriteLibraryAsset libraryAsset => spriteLibrary.spriteLibraryAsset;
    [SerializeField]
    GameObject controlsMenu;

    public void AddUISkinSelector(SpriteResolver resolver, int playerNUmber)
    {
        string[] labels = libraryAsset.GetCategorylabelNames("PlayerSkin").ToArray();
        SkinSelector selector = Instantiate(skinSelector, transform);
        selector.Init(playerNUmber, resolver, labels);
    }
    private void Start()
    {
        spriteLibrary = playerPrefab.GetComponentInChildren<SpriteLibrary>();

        for (int i = 0; i < numberOfPlayers; i++)
        {
            GameObject player = Instantiate(playerPrefab);
            player.SetActive(false); //so it doesnt render
            player.GetComponent<Player>().PlayerNumber = i;
            AddUISkinSelector(player.GetComponentInChildren<SpriteResolver>(), i);
            players.Add(player);
        }
    }
    public void OnEnable()
    {
        GameObject[] selectors = GameObject.FindGameObjectsWithTag("SkinSelector");
        foreach(GameObject selector in selectors)
        {
            Destroy(selector);
        }
        players.Clear();
        for (int i = 0; i < numberOfPlayers; i++)
        {
            GameObject player = Instantiate(playerPrefab);
            player.SetActive(false); //so it doesnt render
            player.GetComponent<Player>().PlayerNumber = i;
            AddUISkinSelector(player.GetComponentInChildren<SpriteResolver>(), i);
            players.Add(player);
        }
    }
    public void PlayButtonClicked()
    {
        for (int i = players.Count - 1; i >= 0; i--)//going in reverse, because I am deleting from list while iterating it
        {
            if (players[i].GetComponentInChildren<SpriteResolver>().GetLabel() == "None"){
                GameObject player = players[i];
                players.RemoveAt(i);
                Destroy(player);
            }
        }
        GameObject playerManager = GameObject.Find("PlayerManager");
        MultiplayerManager multiplayerManager = playerManager.GetComponent<MultiplayerManager>();
        multiplayerManager.players = players;
        multiplayerManager.Init();
        foreach(GameObject player in players)
        {
            Destroy(player);
        }
        gameObject.SetActive(false);
    }
    public void ExitButtonClicked()
    {
        Application.Quit();
    }
    public void ControlsButtonClicked()
    {
        controlsMenu.SetActive(true);
    }
}
