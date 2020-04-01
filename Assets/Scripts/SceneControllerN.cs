using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControllerN : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemiesCount = 100;
    private GameObject[] enemies;

    void Start()
    {
        enemies = new GameObject[enemiesCount];
    }

    void Update()
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null)
            {
                enemies[i] = Instantiate(enemyPrefab) as GameObject;
                enemies[i].transform.position = new Vector3(Random.Range(1f, 5f), 2f, Random.Range(1f, 5f)); ;
                float angle = Random.Range(0, 360f);
                enemies[i].transform.Rotate(0, angle, 0);
            }
        }
      
    }
}
