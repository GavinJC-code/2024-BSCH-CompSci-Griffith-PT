using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public float health;
    float lastTimeHealthReduced = 0f;
    float cooldownTime = 2f;

    public float score;
    public Transform spawnPoint;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(float scoreToAdd)
    {
        score += scoreToAdd;
    }
    public void ReduceHealth()
    {
        // Check if health has been reduced in the past 'cooldownTime' seconds
        if (Time.time - lastTimeHealthReduced < cooldownTime)
        {
            // Health has been reduced within the cooldown period, so return
            return;
        }

        // If not, reduce the health and update the last reduced time
        health -= 1;
        lastTimeHealthReduced = Time.time;
    }
    public void TakeDamage(float damage)
    {
        // if health has been reduced in the past 10 seconds then no health should be reduced
        if (Time.time < 10) return;
        health -= 1;
      

    }

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float h)
    {
        health += h;
    }
}
