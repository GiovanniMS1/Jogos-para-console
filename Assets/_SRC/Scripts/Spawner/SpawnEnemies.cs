using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject inimigos;
    public GameObject player;
    public float count;
    public float tempo;

    void Update()
    {
        if(!player.IsDestroyed())
            SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if(GameObject.Find("Enemy") || !GameObject.Find("Enemy"))
        {

            count += Time.deltaTime;
            if(count > tempo)
            {
                Instantiate(inimigos);
                count = 0;
            }
        }
    }
}
