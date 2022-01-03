/*
 * Haochen Liu
 * 260917834
 * COMP521 A1
 */
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    /// <summary>
    /// Each cell of maze has its
    /// right wall and down wall.
    /// </summary>
    public class Cell
    {
        // whether this cell has the wall
        public bool right = true;
        public bool down = true;
    } 
    /// <summary>
    /// Maze object stores the necessary information of
    /// instanting the maze in game.
    /// </summary>
    public class Maze
    {
        public Cell[] cells;
        public static Maze maze = new Maze();

        /// <summary>
        /// Constructor of Maze.
        /// Using binary tree algorithm to generate a perfect maze.
        /// The maze will be of size 6*12, which means n = 12.
        ///
        /// The generated maze will be stored in public field cells,
        /// and it will be used to instantiate the walls of maze in
        /// the game later.
        /// </summary>
        public Maze()
        {
            // there will be 6*12 = 72 cells
            cells = new Cell[72];

            // initialize each cell.
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = new Cell();
            }

            // Generate 72 unique randon numbers for deciding which wall to
            // take down. 
            // The reason I do it in this way is that System.Random and 
            // Random in UnityEngine keeps giving me same random numbers
            // during the run, so I have to use this alternative way.
            int[] rands = new int[72];
            HashSet<int> used = new HashSet<int>();
            for (int i = 0; i < 72; i++)
            {
                int direction = UnityEngine.Random.Range(0, 72);
                while (true)
                {
                    if (!used.Contains(direction))
                    {
                        rands[i] = direction;
                        break;
                    }
                }
            }

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Cell current_cell = this.GetCell(i, j);
                    int direction = rands[i * 6 + j];

                    //Debug.Log("row" + i);
                    //Debug.Log("column" + j);
                    //Debug.Log("dir" + direction);
                    if (j == 5) {
                        // No need for right wall since the
                        // bridge has its own wall already
                        current_cell.right = false;
                    }
                    // destroy right wall
                    // Since we should go down 12 times and go right 6 times,
                    // going right should have a relatively lower probability.
                    if (direction > 47)
                    {
                        if (j == 5)
                        {
                            current_cell.down = false;

                        }
                        else
                        {
                            current_cell.right = false;
                        }
                    }
                    // destroy down wall
                    else
                    {
                        if (i == 11 && j != 5)
                        {
                            current_cell.right = false;
                        }
                        else
                        {
                            current_cell.down = false;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Get the cell according to its position.
        /// </summary>
        /// <param name="r"></param> the row number of the cell(0~5)
        /// <param name="c"></param> the column number of the cell(0~11)
        /// <returns></returns> the required cell
        public Cell GetCell(int r, int c)
        {
            return cells[r * 6 + c];
        }
        /// <summary>
        /// Get the generated maze.
        /// </summary>
        /// <returns></returns> The finished maze stored in the field.
        public static Maze GetMaze() {
            return maze;
        }
    }

}
