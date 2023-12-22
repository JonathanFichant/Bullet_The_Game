using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.U2D.Animation;
#endif
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public Player player;
    public float speedMob;
    public bool dead;
    public float amplitude; 
    public float frequency;
    public bool moveSin;
    public float phaseShift;
    public ScreenShake screenShake;

    void Start()
    {
        dead = false;
        player = FindObjectOfType<Player>();
        screenShake = FindObjectOfType<ScreenShake>();
        amplitude = 8.0f;
        frequency = 5.0f;
        phaseShift = Random.Range(0.0f, 1.0f);
    }
    // Update is called once per frame
    void Update()
    {
        if (moveSin) // mouvement sinusoïdal
        {

            float newX = Mathf.Sin((Time.time + phaseShift) * frequency) * amplitude;
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
            // SCREENSHAKE
            screenShake.StartShake();

        }
    }
}
