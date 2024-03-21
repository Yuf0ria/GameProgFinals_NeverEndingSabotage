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
    public GameObject Chatbox;

    [Header("Story Progression")]
    public TextMeshProUGUI manager_talk;
    public string managerTalk;
    public GameObject managerTalkUI;
    public bool nearManager;
    public int MTalkCount;

    [Header("The Button")]
    public GameObject StartGame;

    /// <summary>
    /// LOADING THE SCENE
    /// </summary>

    void Start()
    {
        MTalkCount = 0;
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
                MTalkCount++;
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
            if (MTalkCount == 0)
            { 
                thoughts = "That's the manager. I should talk to him."; 
            }
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
        pm.MaxmoveSpeed = 0;
        switch (MTalkCount)
        {
            case 1:
                thoughtsUI.SetActive(false);
                managerTalkUI.SetActive(true);
                managerTalk = "Thanks for coming in all of a sudden.";
                thoughts = "";
                break;
            case 2:
                thoughtsUI.SetActive(true);
                managerTalkUI.SetActive(false);
                managerTalk = "";
                thoughts = "What's the problem?";
                break;
            case 3:
                thoughtsUI.SetActive(false);
                managerTalkUI.SetActive(true);
                managerTalk = "It's that time of the year for the company again... The deadline is coming for our most recent project and... 'They' are coming...";
                thoughts = "";
                break;
            case 4:
                thoughtsUI.SetActive(true);
                managerTalkUI.SetActive(false);
                managerTalk = "";
                thoughts = "They? Who's 'They?";
                break;
            case 5:
                thoughtsUI.SetActive(false);
                managerTalkUI.SetActive(true);
                managerTalk = "The very banes of our developers, Nico. Depression, Power Outages, Internet Cutoffs. You name it.";
                thoughts = "";
                break;
            case 6:
                thoughtsUI.SetActive(true);
                managerTalkUI.SetActive(false);
                managerTalk = "";
                thoughts = "And? Don't we have... Ways to handle all that?";
                break;
            case 7:
                thoughtsUI.SetActive(false);
                managerTalkUI.SetActive(true);
                managerTalk = "You don't understand, Nico. I'm not talking about them in a conceptual sense. I mean they are literally going to attack our devs.";
                thoughts = "";
                break;
            case 8:
                thoughtsUI.SetActive(true);
                managerTalkUI.SetActive(false);
                managerTalk = "";
                thoughts = "What?! You have got to be kidding me. It's all a joke, right?";
                break;
            case 9:
                thoughtsUI.SetActive(false);
                managerTalkUI.SetActive(true);
                managerTalk = "Oh I wish I was too. If I was joking, you could tell.";
                thoughts = "";
                break;
            case 10:
                thoughtsUI.SetActive(true);
                managerTalkUI.SetActive(false);
                managerTalk = "";
                thoughts = "So what am I supposed to do?";
                break;
            case 11:
                thoughtsUI.SetActive(false);
                managerTalkUI.SetActive(true);
                managerTalk = "Take this bat. [LEFT CLICK] to hit them. If you need a boost from us, [RIGHT CLICK] to call us.";
                thoughts = "";
                break;
            case 12:
                thoughtsUI.SetActive(true);
                managerTalkUI.SetActive(false);
                managerTalk = "";
                thoughts = "Sir... This is just a normal bat...";
                break;
            case 13:
                thoughtsUI.SetActive(false);
                managerTalkUI.SetActive(true);
                managerTalk = "It may look like that, but once you swing it, you'll feel the difference. Now go! Fight! Protect the other devs so we can make it to the deadline!";
                thoughts = "";
                break;
            case 14:
                thoughtsUI.SetActive(false);
                managerTalkUI.SetActive(false);
                managerTalk = "";
                thoughts = "";
                StartGame.SetActive(true);
                Chatbox.SetActive(false);
                break;
        }
    }
}
