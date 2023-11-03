using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimyScript : MonoBehaviour
{
    public float movementSpeed = 7;
    public float deadZone = -45;
    public float frequency = 5;
    public float offset = 0;
    public float magnitude = 5;
    public float missileForce = 5;
    public LogicScript logicScript;
    Boolean animyEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (animyEnabled && Time.timeScale != 0)
        {
            transform.position = transform.position + (Vector3.left * movementSpeed * Time.deltaTime) + (Vector3.up * Mathf.Sin(Time.time * frequency + offset) * magnitude);
        }

        if (transform.position.x < deadZone || transform.position.y < deadZone)
        {
            Debug.Log("Animy Deleted");
            Destroy(gameObject);
        }
        if (!animyEnabled) {
            transform.position = transform.position + Vector3.right * missileForce * Time.deltaTime;
        }
        if (logicScript.pauseScreen.activeInHierarchy)
        {
            animyEnabled = true;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animyEnabled = false;
        logicScript.AnimyDeath();
        //Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }


}
