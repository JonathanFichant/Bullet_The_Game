using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public Player player;
    public float speedMob;
    public bool dead;
    public float amplitude; 
    public float frequency;
    public bool moveSin;
    // Start is called before the first frame update
    void Start()
    {
        //speedMob = 0.2f;
        dead = false;
        player = FindObjectOfType<Player>();
        amplitude = 25.0f;
        frequency = 5.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (moveSin)
        {
            float newX = Mathf.Sin(Time.time * frequency) * amplitude;// *Time.deltaTime;
            transform.position += new Vector3(newX, -speedMob, 0) * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.down * speedMob * Time.deltaTime;
        }
        


        if (transform.position.y < -5.5 && !dead)
        {
            dead = true;
            player.life--;
        }
    }
}
