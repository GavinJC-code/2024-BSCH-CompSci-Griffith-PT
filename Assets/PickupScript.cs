using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public float scoreValue;
    public GameManagerScript gameManager;

    public GameObject collectedEffect;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        gameManager.AddScore(scoreValue);
        Instantiate(collectedEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
