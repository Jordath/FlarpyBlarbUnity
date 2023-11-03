using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public Sprite deadFlarp;
    public float flapStrength = 10;
    public LogicScript logicScript;
    public bool birdIsAlive = true;

    // missle variables
    public MissleScript misslePrefab;
    public Transform LaunchOffset;

    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 15 || transform.position.y < -15)
        {
            BirdIsDead();
        }
        if(Input.GetKeyDown(KeyCode.Space)&& birdIsAlive) 
        { 
            myRigidbody2D.velocity = Vector2.up * flapStrength;       
        }
        if (Input.GetKeyDown(KeyCode.L) && birdIsAlive)
        {
            Instantiate(misslePrefab, LaunchOffset.position, transform.rotation);
            logicScript.MissleFiredAudioCue();
        }
        if (Input.GetKeyDown(KeyCode.P) && birdIsAlive)
        {
            logicScript.PauseGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BirdIsDead();
    }

    private void BirdIsDead()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = deadFlarp;
        logicScript.gameOver();
        birdIsAlive = false;
    }
}
