using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using JetBrains.Annotations;

public class OfficeScene : MonoBehaviour
{
    /// <summary>
    /// THE OFFICE SCENE IS THE INTRO OF THE GAME.
    /// YOU ARE FREE TO ROAM AROUND UNTIL YOU TALK TO THE MANAGER
    /// </summary>

    [Header("Other Scripts")]
    public PlayerMovement pm;

    [Header("Thoughts")]
    public TextMeshProUGUI player_thoughts;
    public string thoughts;
    public GameObject thoughtsUI;

    [Header("Story Progression")]
    public TextMeshProUGUI manager_talk;
    public string managerTalk;
    public GameObject managerTalkUI;
    public bool nearManager;
    public int TalkCount;

    [Header("The Button")]
    public GameObject StartGame;

    /// <summary>
    /// LOADING THE SCENE
    /// </summary>

    void Start()
    {
        TalkCount = 0;
        nearManager = false;

        thoughtsUI.SetActive(true);
        managerTalkUI.SetActive(false);
        StartGame.SetActive(false);
        thoughts = "I'm here now. Where is the manager?";
    }

    /// <summary>
    /// UPDATE
    /// </summary>
    
    void Update()
    {
        player_thoughts.text = thoughts.ToString();
        manager_talk.text = managerTalk.ToString();

        if (nearManager == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                TalkCount++;
                ManagerInteract(); //Start of Story
                Debug.Log("Story Starting");
            }
        } else { pm.moveSpeed = 6; }
    }

    /// <summary>
    /// OBSERVING THE DIFFERENT NPCS. YOU CAN'T TALK TO THEM *YET*
    /// </summary>
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Manager"))
        {
            nearManager = true;
            if (TalkCount == 0)
            { thoughts = "That's the manager. I should talk to him."; }
        } else { nearManager = false; }

        if (collision.CompareTag("Kwindy"))
        { thoughts = "That's Kwindy. They aren't kidding, he's really happy."; }

        if (collision.CompareTag("Chris"))
        { thoughts = "That's Chris. Do they really sleep during work?"; }

        if (collision.CompareTag("Jenny"))
        { thoughts = "That's Jenny. The manager told me to not go any closer..."; } 

        if (collision.CompareTag("Llyod"))
        { thoughts = "That's Llyod. Looks like he's going through something."; } 
    }

    //Starting the game by starting the dialogue
    void ManagerInteract()
    {
        pm.moveSpeed = 0;
        switch (TalkCount)
        {
            case 1:
                thoughtsUI.SetActive(false);
                managerTalkUI.SetActive(true);
                managerTalk = "Ah, you're here.";
                thoughts = "";
                break;
            case 2:
                thoughtsUI.SetActive(true);
                managerTalkUI.SetActive(false);
                managerTalk = "";
                thoughts = "Yeah.";
                break;
            case 3:
                thoughtsUI.SetActive(false);
                managerTalkUI.SetActive(true);
                managerTalk = "Are you ready?";
                thoughts = "";
                break;
            case 4:
                thoughtsUI.SetActive(true);
                managerTalkUI.SetActive(false);
                managerTalk = "";
                thoughts = "Mhm.";
                break;
            case 5:
                thoughtsUI.SetActive(false);
                managerTalkUI.SetActive(false);
                managerTalk = "";
                thoughts = "";
                StartGame.SetActive(true);
                break;
        }
    }
}
