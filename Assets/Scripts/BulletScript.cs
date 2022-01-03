/*
 * Haochen Liu
 * 260917834
 * COMP521 A1
 */
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    void OnCollisionEnter()
    {
        // When collision happens, the bullet will be destroyed
        // and the status of whether there is a bullet in game
        // will be reset.
        Destroy(gameObject);
        PlayerFire.ResetBullet();
        Debug.Log("bullet destroyed");
    }
}
