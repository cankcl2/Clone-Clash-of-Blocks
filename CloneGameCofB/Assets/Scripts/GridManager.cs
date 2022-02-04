using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        StartCoroutine(PlusDirections());
    }
    IEnumerator PlusDirections()
    {

        while (true)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (grid[i, j] == 1)
                    {
                        yield return new WaitForSeconds(0.25f);
                        Instantiate(_enemyPrefab, new Vector3(i * 10, 0, j * 10), Quaternion.identity);
                        if (i > 0 && i < 8 )
                        {
                            grid[i + 1, j] = 1;
                        }
                        if(j > 0 && j < 6) 
                        { 
                            grid[i, j + 1] = 1;
                        }
                        

                    }
                }
            }
            break;

        }
    }

}
