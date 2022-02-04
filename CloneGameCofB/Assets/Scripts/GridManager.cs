using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
    public GameObject _enemyPrefab;

    int[,] grid = {
    {0,0,0,0,0,0,0},
    {0,0,0,0,1,0,0},
    {0,0,0,0,0,0,0},
    {3,3,3,3,0,0,0},
    {3,3,3,3,0,0,0},
    {3,3,3,3,0,0,0},
    {0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0}
    };
    public enum OyuncuTuru
    {
        Dusman,
        Ben,
        Doldurulamayan,
        Bos
    }

    void Start()
    {
        StartCoroutine(PlusDirections());
    }
    IEnumerator PlusDirections()
    {
        int o = 0;
        while (true)
        {
            o++;
            yield return new WaitForSeconds(0.5f);
            InstantiateAll(grid);
            var newGrid = grid.Clone() as int[,];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (grid[i, j] == 1)
                    {

                        if (i > 0)
                        {
                            if(newGrid[i - 1, j]==0)
                                newGrid[i - 1, j] = 1;

                        }
                        if (i < 8)
                        {
                            if (newGrid[i + 1, j] == 0)
                                newGrid[i + 1, j] = 1;

                        }
                        if (j > 0)
                        {
                            if (newGrid[i, j - 1] == 0)
                                newGrid[i, j - 1] = 1;
                        }
                        if (j < 6)
                        {
                            if (newGrid[i, j + 1] ==0)
                                newGrid[i, j + 1] = 1;
                        }
                    }
                }
            }
            grid = newGrid;
            if (o>20)
                break;

        }
    }

    private void InstantiateAll(int[,] grid)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (grid[i, j] == 1)
                {
                    Instantiate(_enemyPrefab, new Vector3(i * 10, 0, j * 10), Quaternion.identity);
                }
                if (grid[i, j] == 2)
                {
                    //Instantiate(_enemyPrefab, new Vector3(i * 10, 0, j * 10), Quaternion.identity);
                }
            }
        }

    }
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Level6");
    }
}
