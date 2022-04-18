using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] UIdisplay display;
    [SerializeField] CharacterControllerMove charControl;

    public int score = 0;

    public Material defaultMat;
    public Material redMat;

    void Start()
    {
        defaultMat = gameObject.GetComponent<MeshRenderer>().material; 
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //charControl.moveDirection.y = charControl.jumpSpeed;

            gameObject.GetComponent<MeshRenderer>().material = redMat;
        }
    }
}
