using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GridManager1 : MonoBehaviour
{
    public GameObject _enemyPrefab;
    public GameObject _playerPrefab;
    public GameObject _winMenu;
    public Text winOrLose_Text;
    public Text playerPercent_Text;
    public Text enemy1Percent_Text;

    [SerializeField] bool isPlaceable;

    bool gameEnded = false;
    int enemyScore1 = 0;
    int playerScore = 0;
    int totalGrids = 144;

    int gridRows = 12;
    int gridCols = 12;

    int[,] grid = {
    {0,0,0,0,0,0,0,0,0,0,0,0},
    {0,0,0,0,0,1,0,0,0,0,0,0},
    {0,0,0,3,3,3,3,3,3,0,0,0},
    {0,0,0,3,3,3,3,3,3,0,0,0},
    {0,0,0,3,3,3,3,3,3,0,0,0},
    {0,0,0,3,3,3,3,3,3,0,0,0},
    {0,0,0,0,0,0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0,0,0,0,0,0}
    };

    public bool gameStarted = false;
    bool gameStartedilk = true;
    public int iUpdated;
    public int jUpdated;

    void Start()
    {
        _winMenu.SetActive(false);
    }

    void Update()
    {

        if (gameStarted && gameStartedilk)
        {

            grid[iUpdated, jUpdated] = 2;
            StartCoroutine(PlusDirections());
            gameStartedilk = false;
        }
        if (gameEnded)
        {
            WinCondition();
        }


    }

    private void WinCondition()
    {
        for (int i = 0; i < gridRows; i++)
        {
            for (int j = 0; j < gridCols; j++)
            {
                if (grid[i, j] == 1)
                {
                    enemyScore1++;
                }
                if (grid[i, j] == 2)
                {
                    playerScore++;
                }
            }
        }
        playerScore = playerScore * 100 / totalGrids;
        enemyScore1 = 100 - playerScore;
        _winMenu.SetActive(true);
        if (playerScore>enemyScore1)
        {
            winOrLose_Text.text = "You WON!";
            winOrLose_Text.color = Color.green;
        }
        else if (enemyScore1>playerScore)
        {
            winOrLose_Text.text = "You LOST!";
            winOrLose_Text.color = Color.red;
        }
        else
        {
            winOrLose_Text.text = "-> DRAW <-";
            winOrLose_Text.color = Color.yellow;
        }
        playerPercent_Text.text = "%" + playerScore;
        enemy1Percent_Text.text = "%" + enemyScore1;
        gameEnded = false;
    }

    IEnumerator PlusDirections()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            InstantiateAll(grid);
            var finished = checkIfGridIsFull();
            if (finished)
                break;
            var newGrid = grid.Clone() as int[,];

            for (int i = 0; i < gridRows; i++)
            {
                for (int j = 0; j < gridCols ; j++)
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

        }

        gameEnded = true;

    }

    private bool checkIfGridIsFull()
    {
        for (int i = 0; i < gridRows; i++)
        {
            for (int j = 0; j < gridCols; j++)
            {
                if (grid[i, j] == 0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    private void InstantiateAll(int[,] grid)
    {
        for (int i = 0; i < gridRows; i++)
        {
            for (int j = 0; j < gridCols; j++)
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

    


}
