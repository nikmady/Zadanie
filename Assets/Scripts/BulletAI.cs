using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class BulletAI : MonoBehaviour
{
    // Variables
    private GameObject m_GPmenu; // analog of this.gameobject
    private void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        m_GPmenu = GameObject.Find("GameMenu").gameObject;
    } // set variablles on Awake function


    //Methods
    //____________________________________________Bullets and colliders__________________
    private void OnTriggerEnter(Collider other)
    {
        // For the Player's Bullets (Means what Bullet will do, if it will be Player's bullet)
        if (this.gameObject.tag == "Untagged")
        {
            if (other.gameObject.tag == "Enemy") // Collision with Enemy
            {
                other.gameObject.GetComponent<EnemyAI>().HealthDamageSystem();
                Destroy(this.gameObject);
            }

            if (other.gameObject.tag == "Meteors") // Collision with meteors
            {
                m_GPmenu.GetComponent<GamePlayMenu>().PointsCountMethod();
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }
            if (other.gameObject.tag == "EnemyBullets") // Collision with Enemy's bullets
            {
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }

        }


        // For the Enemy's Bullets (Means what Bullet will do, if it will be Enemys's bullet)
        if (this.gameObject.tag == "EnemyBullets")
        {
            if (other.gameObject.tag == "Meteors") // Enemy's bullets are collisions with the meteors
            {
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }

            if (other.gameObject.tag == "Player") // Enemy's bullets are collisions with the Player
            {
                Destroy(this.gameObject);
                GameObject.Find("PlayerController").GetComponent<PlayerController>().HealthMethod(); // Subtract -0.2f from player health
            }
        }
   
    }
    private void OnTriggerStay(Collider other)
    {
        if (this.gameObject.tag == "Untagged")
        {
            if (other.gameObject.tag == "Meteors")
            {
                m_GPmenu.GetComponent<GamePlayMenu>().PointsCountMethod();
                Destroy(this.gameObject, 0.01f);
                Destroy(other.gameObject);
            }
        }
        if (this.gameObject.tag == "EnemyBullets")
        {
            if (other.gameObject.tag == "Meteors")
            {
                Destroy(this.gameObject, 0.01f);
                Destroy(other.gameObject);
            }
        }
    }




    //____________________________________________Update function________________________
    void Update()
    {
        if (this.gameObject.tag == "Untagged") 
        {
            this.gameObject.transform.Translate(0f, (10f * Time.deltaTime), 0f);
            if (this.gameObject.transform.position.y >= 7)
            {
                Destroy(this.gameObject, 0.1f);
            }
        } // Bullets MOVE from the Player
        if (this.gameObject.tag == "EnemyBullets") 
        {
            this.gameObject.transform.Translate(0f, 0f, (4f * Time.deltaTime));
            
            if (this.gameObject.transform.position.y <= -13)
            {
                Destroy(this.gameObject, 0.1f);
            }
        } // Bullets MOVE from the Enemy
    }
}
