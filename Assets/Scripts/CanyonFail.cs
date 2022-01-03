/*
 * Haochen Liu
 * 260917834
 * COMP521 A1
 */
using UnityEngine;

public class CanyonFail : MonoBehaviour
{
    void OnTriggerEnter(Collider others)
    {
        // falling into the canyon from the start side results in game over
        if (others.tag == "Player" && TeleportScript.collideCheck == false)
        {
            Debug.Log("Game Over - Falling into the canyon!");
            FindObjectOfType<GameManager>().Over("Game Over - You fell into the canyon!");

        }


    }
}
