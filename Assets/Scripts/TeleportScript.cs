/*
 * Haochen Liu
 * 260917834
 * COMP521 A1
 */
using UnityEngine;
using UnityEngine.UI;

public class TeleportScript : MonoBehaviour
{
    public GameObject player;
    // whether player hit the box collider(whether player has won)
    public static bool collideCheck = false;
    // celebration particle effect
    public GameObject celebration;
    // just to provide rotation
    public GameObject teleportDestination;
    public Text message;


    void OnTriggerEnter(Collider others) 
    {
        // check whether player is at the last row of maze
        // and it is the first time that player is here
        if (others.tag == "Player" && collideCheck == false) 
        {
            // mark arrival - teleport will only work once
            collideCheck = true;
            
            Vector3 p1 = new Vector3(62, 62, 212);
            Vector3 p2 = new Vector3(80, 62, 212);
            // instantiaed the celebration particle effects
            GameObject v1 = Instantiate(celebration, p1, teleportDestination.transform.rotation);
            GameObject v2 = Instantiate(celebration, p2, teleportDestination.transform.rotation);
            // teleport player to winning area
            player.transform.position = new Vector3(76, 72, 204);
            message.text = "You have won the game!";
        }


    }
    
}
