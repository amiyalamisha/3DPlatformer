using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIdisplay : MonoBehaviour
{
    [SerializeField] PlayerManager player;

    public GameObject scoreTxt;         // gameobject is the TMP that displays the score text
    public AudioSource music;           //  background game music

    void Start()
    {
        music.Play();                   // plays music in background on loop
    }

    public void UpdateScore()
    {
        scoreTxt.GetComponent<TextMeshProUGUI>().text = string.Empty;       // clears string text first

        // new string to display
        string displayTxt = "";
        displayTxt = "Score: " + player.score.ToString();       // putting together the string

        scoreTxt.GetComponent<TextMeshProUGUI>().text = displayTxt;         // displaying the updated score and text
    }
}
