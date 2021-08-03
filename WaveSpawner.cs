using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemyAlive;

    public Wave[] waves;
    
    public float timeBetweenWaves = 5.5f;
    private float countdown = 5f;
    public int waveIndex = 0;
    public Transform spawnPoint;
    public Text wavecountDownTimer;

    public  GameManager gameManager;

    private void Update()
    {
        if(enemyAlive > 0)
        {
            return;
        }
        if (waveIndex == waves.Length )
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)//如果減到0
        {
            StartCoroutine(SpawnWave());//調用IEnumertor的函數要用StartCoroutine
            countdown = timeBetweenWaves;//countdown會等於timeBetweenWave(5S)，
                                         //跳出IF，接著在執行countdown -= Time.deltaTime;//countdown每秒減一
            return;
        }
        countdown -= Time.deltaTime;//countdown每秒減一

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        wavecountDownTimer.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        
        PlayerStats.rounds++;

        Wave wave = waves[waveIndex];

        enemyAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(wave.waittingTime);// 等待0.5秒，然后继续从此处开始，常用于做定时器。
        }
        waveIndex++;

     

    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }





}
