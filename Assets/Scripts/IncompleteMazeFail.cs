/*
 * Haochen Liu
 * 260917834
 * COMP521 A1
 */
using UnityEngine;

public class IncompleteMazeFail : MonoBehaviour
{
    void OnTriggerEnter(Collider others)
    {
        // check whether player is at the last row of maze
        // and it is the first time that player is here
        if (others.tag == "Player" && Tree_Spawn.destroyCount<12)
        {
            Debug.Log("Game Over - Falling onto incomplete maze!");
            FindObjectOfType<GameManager>().Over("Game Over - You fell onto an incomplete maze!");

        }


    }
}
