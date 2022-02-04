using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject _enemyPrefab;

    int[,] grid = {
    {0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0},
    {0,0,0,0,0,1,0},
    {3,3,3,3,0,0,0},
    {3,3,3,3,0,0,0},
    {3,3,3,3,0,0,0},
    {0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0}
    };

    void Start()
    {

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (grid[i, j] == 1 && grid[i, j] != 3)
                {
                    for (int z = 0; z<10; z++)
                    {
                        Instantiate(_enemyPrefab, new Vector3(i * 10, 0, j * 10), Quaternion.identity);
                        grid[i + 1, j] = 1;
                        grid[--i, j] = 1;
                        if (i > 8)
                        {
                            i = 8;
                        }
                        else if (j > 6)
                        {
                            j = 6;
                        }
                        break;
                    }
                }
            }
        }


    }
}
