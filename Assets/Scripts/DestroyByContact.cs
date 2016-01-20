using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
     GameController gameController;
     public int scoreValue;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
         if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
         if (gameController == null)
         {
             Debug.Log("Cannot find 'GameController' script");
         }
    }
    void OnTriggerEnter(Collider other)
    {

        //Debug.Log("trigger: "+ other.gameObject.name);
        if (other.gameObject.name.Contains("Player"))
        {
            AudioSource audio1 = GetComponent<AudioSource>();
            if (gameObject.name.Contains("Warp"))
            {
                
               // Debug.Log("warp");
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                other.gameObject.transform.rotation = Quaternion.identity;
               
                
            }
            else if (gameObject.name.Contains("Coin"))
            {
                //updateScore
                gameController.AddNewScore(scoreValue);
               // Debug.Log("coin picked up");
            }
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            audio1.Play();
            Destroy(gameObject, audio1.clip.length);
        }
    }
	

}
