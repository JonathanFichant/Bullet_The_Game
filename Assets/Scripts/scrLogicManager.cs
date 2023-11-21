using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public float timer;
    public float timerDifficulty;
    public float spawnDelay;
    public GameObject Hexa;
    public GameObject Mob;
    public GameObject Mob2;
    public GameObject Speeder;
    public int Switch;
    public float ecart;
    public int wave;
    public Player player;
    public scrFlashBeat mainCameraScript;
    private bool canSpawn;
  
    void Start()
    {
        wave = 0;
        timer = 0;
        spawnDelay = 0.6f;
        Switch = 1;
        ecart = 0f;
        canSpawn = false;
        //speederCountdown = 2f;
        timerDifficulty = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timerDifficulty += Time.deltaTime;
        float averageValue = mainCameraScript.average;


        // difficulté incrémentale selon le temps

        if  (timerDifficulty >= 10f)
        {
            spawnDelay -= 0.01f;
            timerDifficulty -= 10;

        }


        if (canSpawn)
        {
            if (averageValue > 0.003)
            {
                if (averageValue > 0.009)
                {
                    Instantiate(Speeder, new Vector3(Random.Range(-4f, 4f), transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 90));
                }
                else
                {
                    Instantiate(Hexa, new Vector3(Random.Range(-7f, 7f), transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
                }
            }
            canSpawn = false;
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
            
            if (timer >= spawnDelay)
            {
                canSpawn = true;
            }
        }


    }
}
