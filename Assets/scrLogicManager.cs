using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public float timer;
    public float finalCountdown;
    public GameObject Mob;
    public GameObject Mob2;
    public int Switch;
    public float ecart;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        finalCountdown = 5f;
        Switch = 1;
        ecart = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= finalCountdown)
        {
            timer = 0f;
            if (Switch == 1)
            {
                Instantiate(Mob, transform.position + (Vector3.up) * ecart, transform.rotation);
                //timer = 0;
                Switch = 2;
            }
            else if (Switch == 2)
                   {
                Instantiate(Mob2, transform.position, transform.rotation);
                //timer = 0;
                Switch = 1;
            }
        }
    }
}
