/*
 * Haochen Liu
 * 260917834
 * COMP521 A1
 */
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // when there is a bullet in the scene, it will be true
    public static bool bulletCheck = false;
    // where the projectile/bullet is shoot out from
    public Transform barrel;
    // projectile/bullet
    public Rigidbody bullet;
    
    /// <summary>
    /// Is called when the bullet get destroyed.
    /// Then there is no bullet in game, reset the status
    /// in order to fire another bullet/projectile.
    /// </summary>
    public static void ResetBullet() {
        bulletCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            // only fire a bullet when there is no bullet in the scene
            if (bulletCheck == false)
            {             
                Rigidbody bullet_out = (Rigidbody)Instantiate(bullet,barrel.position, barrel.rotation);
                // fire the bullet to the barrel(main camera) direction
                bullet_out.AddForce(barrel.transform.forward * 1000);
                // now there is a bullet in the scene
                bulletCheck = true;
            }
            // otherwise don't fire
            else {
                Debug.Log("One bullet at a time!");
            }
        }
    }
}
