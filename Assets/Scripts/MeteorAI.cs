using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorAI : MonoBehaviour
{

    public float MeteorSpeed = 1.2f;


    //__________________________________________Asteroids are collision the Player/Bullet_________
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("PlayerController").GetComponent<PlayerController>().HealthMethod();
            Destroy(this.gameObject, 0.05f);
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("PlayerController").GetComponent<PlayerController>().HealthMethod();
            Destroy(this.gameObject, 0.05f);
            
        }
    }
    
    //__________________________________________Update Function___________________________________
    void Update()
    {
        this.gameObject.transform.Translate(0f, (MeteorSpeed * Time.deltaTime * -1), 0f);
        if (this.gameObject.transform.position.y <= -12f)
        {
            Destroy(this.gameObject);
        }
    }
}
