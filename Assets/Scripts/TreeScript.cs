/*
 * Haochen Liu
 * 260917834
 * COMP521 A1
 */
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    // Rigidbody wall to instantiate the maze
    public Rigidbody wallRight;
    public Rigidbody wallDown;

    void OnCollisionEnter()
    {
        // destroy the bullet
        Destroy(gameObject);
        // Accumulates when tree is destroyed by the projectile.
        Tree_Spawn.destroyCount++;
        Debug.Log(Tree_Spawn.destroyCount + " tree(s) destroyed");
        // Instantiate a row of maze according to the number of trees destroyed.
        // The maze is of size 6*12.
        if (Tree_Spawn.destroyCount <= 12) {
            int row = Tree_Spawn.destroyCount;
            int i = 12 - row;
            for (int j = 0; j < 6; j++)
            {
                MazeGenerator.Cell current_cell = MazeGenerator.Maze.GetMaze().GetCell(i, j);
                if (current_cell.right == true)
                {
                    // instantiate the wall at designated coordinate
                    Vector3 position = new Vector3((62.3f + 4 * j), (30.5f), (192.68f - 4.5f * i));
                    Rigidbody wall_r = Instantiate(wallRight, position, Quaternion.identity);
                }

                if (current_cell.down == true)
                {
                    // instantiate the wall at designated coordinate
                    Vector3 position = new Vector3((60.57f + 4 * j), (30.5f), (190.43f - 4.5f * i));
                    Rigidbody wall_d = Instantiate(wallDown, position, Quaternion.identity);
                }
            }
        }
    }
    



}
