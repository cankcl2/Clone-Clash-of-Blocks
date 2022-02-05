using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public GameObject _enemyPrefab;
    public GameObject _playerPrefab;
    bool isStarted = false;
    public Text m_Text;

    int[,] grid = {
    {0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0},
    {0,0,0,0,0,1,0},
    {3,3,3,3,0,2,0},
    {3,3,3,3,0,0,0},
    {3,3,3,3,0,0,0},
    {0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0}
    };
    

    void Start()
    {
        StartCoroutine(PlusDirections());
    }

    void Update()
    {
        if (!isStarted)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                // Update the Text on the screen depending on current position of the touch each frame
                m_Text.text = "Touch Position : " + touch.position;
            }
        }
    }
    IEnumerator PlusDirections()
    {
        if (isStarted)
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
                        if (grid[i, j] == 2)
                        {

                            if (i > 0)
                            {
                                if (newGrid[i - 1, j] == 0)
                                    newGrid[i - 1, j] = 2;

                            }
                            if (i < 8)
                            {
                                if (newGrid[i + 1, j] == 0)
                                    newGrid[i + 1, j] = 2;

                            }
                            if (j > 0)
                            {
                                if (newGrid[i, j - 1] == 0)
                                    newGrid[i, j - 1] = 2;
                            }
                            if (j < 6)
                            {
                                if (newGrid[i, j + 1] == 0)
                                    newGrid[i, j + 1] = 2;
                            }
                        }
                        if (grid[i, j] == 1)
                        {

                            if (i > 0)
                            {
                                if (newGrid[i - 1, j] == 0)
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
                                if (newGrid[i, j + 1] == 0)
                                    newGrid[i, j + 1] = 1;
                            }
                        }
                    }
                }
                grid = newGrid;
                if (o > 20)
                    break;

            }
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
                    Instantiate(_playerPrefab, new Vector3(i * 10, 0, j * 10), Quaternion.identity);
                }
            }
        }

    }
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Level6");
    }
}
