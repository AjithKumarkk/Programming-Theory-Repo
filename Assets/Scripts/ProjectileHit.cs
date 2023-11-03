using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ProjectileHit : MonoBehaviour
{
    private ScoreManager scoreManager;
    
   

    private void Start()
    {
        scoreManager = GameObject.FindAnyObjectByType<ScoreManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {   
            Destroy(gameObject);
            Destroy(collision.gameObject);

            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(10);
            }
            
        }
    }
}
