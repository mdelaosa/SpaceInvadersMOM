using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosionPrefab;
    public GameObject GameOver;
    public GameObject Winner;

    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);
        Winner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        completeLevel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
            lives -= 1;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                {
                    livesUI[i].enabled = true;
                } else
                {
                    livesUI[i].enabled = false;
                }
            }
            if (lives <= 0)
            {

                Destroy(gameObject);
                Time.timeScale = 0;
                GameOver.SetActive(true);
                OnPause();
                SceneManager.LoadScene("Level1");
                Time.timeScale = 1;


            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(collision.gameObject);
            lives -= 1;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                {
                    livesUI[i].enabled = true;
                }
                else
                {
                    livesUI[i].enabled = false;
                }
            }
            if (lives <= 0)
            {

                Destroy(gameObject);
                Time.timeScale = 0;
                GameOver.SetActive(true);
                OnPause();
                SceneManager.LoadScene("Level1");
                Time.timeScale = 1;


            }
        }
    } 

    private void completeLevel()
    {
        // Level 1 --> Level 2 with all lives again
        if (lives != 0) {
            if (SceneManager.GetActiveScene().name.Equals("Level1") && (GameObject.FindGameObjectsWithTag("Enemy").Length == 0))
            {
                SceneManager.LoadScene("Level2");

            }
            else if (SceneManager.GetActiveScene().name.Equals("Level2") && (GameObject.FindGameObjectsWithTag("Enemy").Length == 0))
            {
                Time.timeScale = 0;
                Winner.SetActive(true);
            }
        }
    }



    // Delay 
    public void OnPause()
    {
        StartCoroutine(OnPauseCoroutine());
    }

    private IEnumerator OnPauseCoroutine()
    {
        yield return new WaitForSeconds(60f);
    }
}
