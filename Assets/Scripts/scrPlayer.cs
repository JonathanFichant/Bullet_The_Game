using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
//using UnityEngine.XR;


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
    public float speedBullet = 12f;
    public float speedBulletBonus = 18f;
    public float nextFireTimeBonus = 0.0f;
    public float fireRateBonus = 5f;

    private VariableManager variableManager;

    // Start is called before the first frame update
    void Start()
    {
        variableManager = FindObjectOfType<VariableManager>();
        speed = 15f;
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
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D)))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        // TIR

        nextFireTime += Time.deltaTime;
        nextFireTimeBonus += Time.deltaTime;

        if ( (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) ) && (nextFireTimeBonus >= fireRateBonus)) // TIR SPECIAL LATERAL
        {
            nextFireTimeBonus = 0f;

            // Tir droit
            Shoot(Vector2.right, speedBulletBonus, new Vector3(0.3f, -0.4f, 0f),3f);
            // Tir gauche
            Shoot(Vector2.left, speedBulletBonus, new Vector3(-0.3f,-0.4f,0f),3f);
        }

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
            nextFireTime = 0f;
            Shoot(Vector2.up, speedBullet,Vector3.zero,1f);
        }

        if (autofire && (nextFireTime >= fireRate))
        {
            Shoot(Vector2.up, speedBullet, Vector3.zero,1f);
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
            variableManager.score = score;
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


    void Shoot(Vector2 directionTir, float bulletSpeed, Vector3 positionBonus, float scaleMultiplier) {
        GameObject newBullet = Instantiate(bullet, parent.position + positionBonus, parent.rotation);
        Bullet bulletScript = newBullet.GetComponent<Bullet>();
        newBullet.transform.localScale *= scaleMultiplier;

        bulletScript.SetDirectionAndSpeed(directionTir, bulletSpeed, scaleMultiplier);
    }

}
