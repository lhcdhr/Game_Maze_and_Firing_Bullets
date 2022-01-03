/*
 * Haochen Liu
 * 260917834
 * COMP521 A1
 */
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameover = false;
    public Text info;
    // Start is called before the first frame update
    
    /// <summary>
    /// Game over, and display the losing message.
    /// </summary>
    /// <param name="message"></param> the message to display
    public void Over(string message)
    {
        if (gameover == false) {
            gameover = true;
            info.text = message;
            // restart the game after a short delay
            Invoke("Restart", 3f);
        }

    }
    /// <summary>
    /// Reset the condition checks and reload the scene.
    /// </summary>
    public void Restart() 
    {
        Tree_Spawn.destroyCount = 0;
        TeleportScript.collideCheck = false;
        Tree_Spawn.collideCheck = false;
        PlayerFire.bulletCheck = false;
        SceneManager.LoadScene("GameScene");
    }
}
