using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleScript : MonoBehaviour
{
    public float missleSpeed = 20;
    public LogicScript logicScript;
    public GameObject explosion;
    public explosionScript explosionScript;
    
    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
            transform.position += transform.right * Time.deltaTime * missleSpeed;
        
        if(transform.position.x > 40)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //logicScript.MissleExploding();
        //Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        MissleExploding();
    }

    public void MissleExploding()
    {
        var clone = Instantiate(explosionScript, transform.position, transform.rotation);
        Destroy(clone, 1);
    }


}
