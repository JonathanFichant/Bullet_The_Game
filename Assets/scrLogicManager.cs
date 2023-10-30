using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public float timer;
    public float finalCountdown;
    public float speederCountdown;
    public GameObject Mob;
    public GameObject Mob2;
    public GameObject Speeder;
    public int Switch;
    public float ecart;
    public int wave;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        wave = 0;
        timer = 0;
        finalCountdown = 5f;
        Switch = 1;
        ecart = 0f;
        speederCountdown = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.score >= 10)
        {
            wave = 1;
        }
        else if  (player.score >= 135)
        {
            wave = 2;
        }


        if (wave == 0)
        {
            // WAVE 0, mob classique hexagones blancs
            timer += Time.deltaTime;
            if (timer >= finalCountdown)
            {
                timer = 0f;
                if (Switch == 1)
                {
                    Instantiate(Mob, transform.position + (Vector3.up) * ecart, transform.rotation);
                    Switch = 2;
                }
                else if (Switch == 2)
                {
                    Instantiate(Mob2, transform.position, transform.rotation);
                    Switch = 1;
                }
            }
        }

        if (wave == 1)
        {
            // WAVE 0, mob classique hexagones blancs
            timer += Time.deltaTime;
            if (timer >= speederCountdown)
            {
                timer = 0f;
                {
                    //Instantiate(Speeder, transform.position + (Vector3.up), transform.rotation * Quaternion.Euler(0,0,90));
                    Instantiate(Speeder, new Vector3(Random.Range(-8f, 8f), transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 90));
                }
            }

        }

    }
}
