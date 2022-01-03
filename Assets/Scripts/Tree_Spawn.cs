/*
 * Haochen Liu
 * 260917834
 * COMP521 A1
 */
using System.Collections.Generic;
using UnityEngine;

public class Tree_Spawn : MonoBehaviour
{
    // to make sure trees only generate once
    public static bool collideCheck = false;
    // prefab of trees to spawn
    public Rigidbody tree;
    // the empty object with box collider
    public GameObject spawnWall;
    // number of trees destroyed by the projectile
    public static int destroyCount = 0;

    void OnTriggerEnter(Collider others)
    {
        // when the box collider is hit by player at the FIRST time
        if(others.tag == "Player" && collideCheck == false)
        {
            Debug.Log("spawn detector hit");

            // From now on, future collisions with the box collider will not be handled.
            // Trees will spawn only once in a game.
            collideCheck = true;
            var random = new System.Random();
            // store used coordinates to avoid overlapping
            HashSet<(int, int)> used_coord = new HashSet<(int, int)>();
            // initialize
            for (int i = 0; i < 66; i++){
                while (true)
                {
                    // get x coord and z coord within limited range
                    int x = random.Next(4, 25);
                    int z = random.Next(13, 22);
                    // if this coordinate is not used, then spawn a tree
                    // otherwise try a new coordinate
                    if (!used_coord.Contains((x, z))) {
                        used_coord.Add((x, z));
                        Vector3 position = new Vector3(10+x*4, 64.8f, 45+z*4);
                        Rigidbody tree_out = Instantiate(tree, position,spawnWall.transform.rotation);
                        break;
                    }
                }
            }
        }        
    }
}
