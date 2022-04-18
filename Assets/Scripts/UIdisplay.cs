using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIdisplay : MonoBehaviour
{
    [SerializeField] PlayerManager player;

    public GameObject scoreTxt;

    public AudioSource music;

    void Start()
    {
        music.Play(); 
    }


    void Update()
    {
        
    }

    public void UpdateScore()
    {
        scoreTxt.GetComponent<TextMeshProUGUI>().text = string.Empty;

        string displayTxt = "";
        displayTxt = "Score: " + player.score.ToString();

        scoreTxt.GetComponent<TextMeshProUGUI>().text = displayTxt;
    }
}
