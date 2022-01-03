/*
 * Haochen Liu
 * 260917834
 * COMP521 A1
 */
using UnityEngine;
using UnityEngine.UI;


public class ScoreText : MonoBehaviour
{

    public Text countText; 
    // Update is called once per frame
    void Update()
    {
        // update how many trees has been destroyed on screen
        countText.text = Tree_Spawn.destroyCount.ToString();
    }
}
