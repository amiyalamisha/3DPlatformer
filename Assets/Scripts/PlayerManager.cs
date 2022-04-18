using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] UIdisplay display;

    public int score = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "flower")
        {
            Destroy(other.gameObject);
            score++;

            display.UpdateScore();
        }
    }
}