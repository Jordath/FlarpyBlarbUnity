using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    public AudioClip explosionSFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1);   
    }

    public void Explode()
    {

        //Destroy(gameObject, 1);
        Instantiate(gameObject, transform.position, transform.rotation);
    }
}
