using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public AudioSource pickSnd;         // sound effect for picking flower
    [SerializeField] UIdisplay display;
    [SerializeField] CharacterControllerMove charControl;

    public int score = 0;       // keeping track of score & number of flowers picked


    // triggering the flowers
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "flower")
        {
            Destroy(other.gameObject);      // when player hits a flower it deletes the flower object
            pickSnd.PlayOneShot(pickSnd.clip, 1.0f);        // plays a sound effect to show you picked it

            score++;        // adds to the score
            display.UpdateScore();          // calls the UpdateScore() function from the UIdisplay class everytime score changes
        }
    }
}
