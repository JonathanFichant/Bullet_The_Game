using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.XR;


public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform parent;
    public Transform limitL;
    public Transform limitR;
    public TextMeshProUGUI scoreText;
    public int score;
    public TextMeshProUGUI lifeText;
    public int life;
    public float fireRate;
    public float nextFireTime;
    public float speed;
    public TextMeshProUGUI autofireText;
    public bool autofire;
    public ScreenShake screenShake;

    // Start is called before the first frame update
    void Start()
    {
        speed = 13f;
        score = 0;
        scoreText.text = score.ToString();
        life = 9;
        lifeText.text = " x " + life.ToString();
        nextFireTime = 0.0f;
        fireRate = 0.2f;
        autofire = false;

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        lifeText.text = " x " + life.ToString();

        // DEPLACEMENTS
        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A)))
        {
            transform.position += Vector3.left*speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D)))
        {
            transform.position += Vector3.right*speed * Time.deltaTime;
        }

        // TIR
       
        nextFireTime += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            if (autofire == false)
            {
                autofire = true;
                autofireText.color = Color.green;
            } else
            {
                autofire = false;
                autofireText.color = Color.white;
            }
        }

        if (Input.GetKey(KeyCode.Space) && (nextFireTime >= fireRate) && autofire == false)
        {
           
            // Instancie une nouvelle balle
            Instantiate(bullet, parent.position, parent.rotation);
            nextFireTime = 0f;
   
        }

        if (autofire && (nextFireTime >= fireRate))
        {
            Instantiate(bullet, parent.position, parent.rotation);
            nextFireTime = 0f;
        }

        if (transform.position.x < limitL.position.x)
        {
            transform.position = new Vector3(limitR.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitR.position.x)
        {
            transform.position = new Vector3(limitL.position.x, transform.position.y, transform.position.z);
        }

        // LOOSE

        if (life <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ennemy"))
        {
            Destroy(other.gameObject); 
            life--;

            // SCREENSHAKE
            screenShake.StartShake();

        }
        if (other.CompareTag("Bonus"))
        {
            Destroy(other.gameObject);
            life++;
        }
    }
  
}
