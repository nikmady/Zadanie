using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject m_PlayerTouch = null; // our Player
    public GameObject m_Bullets = null; // Bullets-Rockes
    private float bulletCrationTimer = 0; // Bullet speed
    public Transform m_BulletBirthPosition; // Bullet birth position
    public GameObject HealthParameter = null; // Health parameter

    private float xValue = 0f; // Value x from mouse
    private float yValue = 0f; // Value y from mouse
    private Vector3 m_getPlayerPosition = Vector3.zero;
    
    private void Awake()
    {
        m_PlayerTouch = GameObject.FindGameObjectWithTag("Player").gameObject;
    }


    //_____________________________________Health Method______________________

    IEnumerator HealthWait (float waits)
    {
        yield return new WaitForSeconds(waits);
        m_counter = 1; 
    }

    private int m_counter = 1;
    public void HealthMethod()
    {
        if (m_counter == 1)
        {
            if (HealthParameter.GetComponent<Slider>().value > 0)
            {
                HealthParameter.GetComponent<Slider>().value -= 0.2f;
            }
            m_counter = 2;
            StartCoroutine(HealthWait(0.5f));
        }
        
    } // Health subtraction
    public void RestartHealt()
    {
        HealthParameter.GetComponent<Slider>().value = 1f;
    } // restart Health

    //_____________________________________Bullet Creation Method ____________
    void BulletCreationMethod()
    {
        GameObject InstantBullet = Instantiate(m_Bullets, m_BulletBirthPosition.position, Quaternion.identity);
        InstantBullet.transform.SetParent(null);
        bulletCrationTimer = 0f;
    }

    //_____________________________________Update function____________________
    void Update()
    {
        //_________________________________Controller for Android ____________
        if (Input.GetMouseButton(0)) 
        {
            RaycastHit hits;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hits, 100f))
            {
               //______________________Horizontal Move__________________________
                #region Horizontal axis Moving
                if (hits.collider.gameObject.tag == "Player")
                {
                    xValue = hits.point.x;
                    m_getPlayerPosition = new Vector3(xValue, m_PlayerTouch.transform.position.y,
                                                    m_PlayerTouch.transform.position.z);
                    if ((xValue >= -1.70f) && (xValue <= 1.7f))
                    {
                        m_PlayerTouch.transform.position = m_getPlayerPosition;
                    }
                }
                #endregion
               
                //______________________Shooting System(Android)__________________________
                #region Shooting System
                if (hits.collider.gameObject != null)
                {
                    yValue = hits.point.y;
                    if (yValue >= -3.1f)
                    {
                        bulletCrationTimer += 8f * Time.deltaTime; // Bullet's speed
                        if (bulletCrationTimer >= 2)
                        {
                            BulletCreationMethod();
                        }
                            
                    }
                    
                }

                #endregion
            }

        } 
        
        //_________________________________Controllers For Windows_____________
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            if (m_PlayerTouch.transform.position.x >= -1.70f)
            {
                m_PlayerTouch.transform.Translate(-3f * Time.deltaTime, 0f, 0f); // move Left
            }
            
        }
        if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            if (m_PlayerTouch.transform.position.x <= 1.70f)
            {
                m_PlayerTouch.transform.Translate(3f * Time.deltaTime, 0f, 0f); // move Right
            }
            
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("GameMenu").GetComponent<GamePlayMenu>().PauseGame();
        } // UI pause

        if (Input.GetKey(KeyCode.Space))
        {
            bulletCrationTimer += 8f * Time.deltaTime; // Bullet's speed
            if (bulletCrationTimer >= 2)
            {
                BulletCreationMethod();
            }
        } // Shooting



        if (HealthParameter.GetComponent<Slider>().value <= 0.1f)
        {
            GameObject.Find("GameMenu").GetComponent<GamePlayMenu>().GameOver();
        }
    }
}
