using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float horizontalInput;
    [SerializeField] float speed = 10f;
    private float zBoundRange = 10f;
    public bool isGameOver = false;

    public ParticleSystem explosionParticle;

    public GameObject projectilePrefab;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI quitText;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R)) 
            {
                RestartGame();            
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                QuitGame();
            }
        }

        if (transform.position.z > zBoundRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundRange);
        }
        if (transform.position.z < -zBoundRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBoundRange);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed);


        if (Input.GetKeyDown(KeyCode.Space) && isGameOver == false)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {      
        if (gameObject.CompareTag("Player"))
        {
            isGameOver = true;
            explosionParticle.Play();
            Destroy(collision.gameObject);
            ShowGameOverText(scoreManager.GetScore());
        }
    }
    private void ShowGameOverText(int score)
    {
       if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Game Over\nScore: " + score;
            restartText.gameObject.SetActive(true);
            quitText.gameObject.SetActive(true);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

}
