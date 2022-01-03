/*
 * Haochen Liu
 * 260917834
 * COMP521 A1
 */
using UnityEngine;

public class JumpBackFail : MonoBehaviour
{
    void OnTriggerEnter(Collider others)
    {
        // If player jump back to the canyon after willing, game over.
        if (others.tag == "Player" && TeleportScript.collideCheck == true)
        {
            Debug.Log("Game Over - Jumped back after winning!");
            FindObjectOfType<GameManager>().Over("Game Over - You jumped back after winning!");
        }


    }
}
