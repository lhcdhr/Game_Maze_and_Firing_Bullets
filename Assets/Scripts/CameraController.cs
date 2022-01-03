/*
 * Haochen Liu
 * 260917834
 * COMP521 A1
 */
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    // mouse data
    private float X; 
    private float Y;
    // sensitivity of mouse
    public float sen; 
    // accumulate the value of up down
    public float xRot;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // get the value of left/right and up/down move of mouse
        X = Input.GetAxis("Mouse X") * sen * Time.deltaTime;
        Y = Input.GetAxis("Mouse Y") * sen * Time.deltaTime;

        // Y will reset to 0 when mouse is not on the move
        // then we can accumulate the change of Y by doing this
        // otherwise camera will have problem looking up and down.
        xRot -= Y;
        // limit the up-down rotation - otherwise camera could flip around and around
        xRot = Mathf.Clamp(xRot, -80f, 80f);

        //(0,1,0) * x. When mouse moves left/right,
        // player(together with all children) rotates with the mouse.
        player.Rotate(Vector3.up * X);
        // Rotates the camera up and down, this will not affected by the rotation of player.
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);

    }
}