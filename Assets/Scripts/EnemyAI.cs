using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    [Header("Enemy mesh and Enemy's Points")]
    public GameObject EnemyModel = null; // Here we are put an Enemy mesh
    public List<GameObject> EnemysPoints = new List<GameObject>(); // all enemy's Transform points

    [Header("Enemy Health")]
    public GameObject CanvasObject = null; // UI Enemy Canvas
    public GameObject HealthScroll = null; // UI Enemy's Health
    public float EnemyHealth = 1; // Enemy's health

    [Header("Enemy Shooting Options")]
    public GameObject EnemyGunPosition = null; // Start position for Enemy's Bullets
    public GameObject BulletPrefab = null; // Bullet Prefab

    [Header("Random positions settings")]
    public int RandomPositionChouse = 0; // RandomPosition of the enemy Navigation
    public float SpeedOfRandomPosition = 0.4f; // Speed of choice random position
    public float EnemySpeed = 10f; // Enemy Speed
    private bool EnemyMove = false; // Enemy move or Not?
    private int LastRandomPosition; // Last random position of the Enemy
    private Vector3 NextEnemyPosition = Vector3.zero; // Set Enemy Position


    //____________________________________Set enemys's AI points_________________________________
    private void Awake()
    {
        EnemyModel = this.gameObject;
        GameObject ENpoints = GameObject.Find("EnemysPoints").gameObject;  // enemys points variable
        int CountOfPoints = ENpoints.transform.childCount;
        for (int i = 0; i < CountOfPoints; i++)
        {
            EnemysPoints.Add(ENpoints.transform.GetChild(i).gameObject);
        }
    } // Here we are puting all GameObject's-points in a List(Massive)
    

    //___________________________________Health Damage System____________________________________
    public void HealthDamageSystem()
    {
        EnemyHealth -= 0.2f;
        if (EnemyHealth <= 0)
        {
            GameObject.Find("GameMenu").GetComponent<GamePlayMenu>().PointsCounts += 100; // Add 100 Points to the Player
            this.gameObject.SetActive(false);
        }
    }


    //____________________________________Canvas Health Stabilized(using localposition.Vector3)__
    void CanvasStabilized()
    {
        CanvasObject.GetComponent<RectTransform>().localPosition = new 
        Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1.03f);
    } 


    //____________________________________Path AI(Choice)________________________________________
    private float m_Timer = 0f; // a simple Timer
    public void PathAI()
    {
        m_Timer += SpeedOfRandomPosition * Time.deltaTime;
        if (m_Timer > 2f)
        {
            
            RandomPositionChouse = Random.Range(1, 9);
            m_Timer = 0;
            switch (RandomPositionChouse)
            {
                case 1:
                    foreach (GameObject p in EnemysPoints)
                    {
                        if (p.name == "EnemyPoint1")
                        {
                            NextEnemyPosition = p.transform.position;
                        }
                    }
                    EnemyMove = true;
                    StartCoroutine(Wait1sec(1f));
                    break;
                case 2:
                    foreach (GameObject p in EnemysPoints)
                    {
                        if (p.name == "EnemyPoint2")
                        {
                            NextEnemyPosition = p.transform.position;
                        }
                    }
                    EnemyMove = true;
                    StartCoroutine(Wait1sec(1f));
                    break;
                case 3:
                    foreach (GameObject p in EnemysPoints)
                    {
                        if (p.name == "EnemyPoint3")
                        {
                            NextEnemyPosition = p.transform.position;
                        }
                    }
                    EnemyMove = true;
                    StartCoroutine(Wait1sec(1f));
                    break;
                case 4:
                    foreach (GameObject p in EnemysPoints)
                    {
                        if (p.name == "EnemyPoint4")
                        {
                            NextEnemyPosition = p.transform.position;
                        }
                    }
                    EnemyMove = true;
                    StartCoroutine(Wait1sec(1f));
                    break;
                case 5:
                    foreach (GameObject p in EnemysPoints)
                    {
                        if (p.name == "EnemyPoint5")
                        {
                            NextEnemyPosition = p.transform.position;
                        }
                    }
                    EnemyMove = true;
                    StartCoroutine(Wait1sec(1f));
                    break;
                case 6:
                    foreach (GameObject p in EnemysPoints)
                    {
                        if (p.name == "EnemyPoint6")
                        {
                            NextEnemyPosition = p.transform.position;
                        }
                    }
                    EnemyMove = true;
                    StartCoroutine(Wait1sec(1f));
                    break;
                case 7:
                    foreach (GameObject p in EnemysPoints)
                    {
                        if (p.name == "EnemyPoint7")
                        {
                            NextEnemyPosition = p.transform.position;
                        }
                    }
                    EnemyMove = true;
                    StartCoroutine(Wait1sec(1f));
                    break;
                case 8:
                    foreach (GameObject p in EnemysPoints)
                    {
                        if (p.name == "EnemyPoint8")
                        {
                            NextEnemyPosition = p.transform.position;
                        }
                    }
                    EnemyMove = true;
                    StartCoroutine(Wait1sec(1f));
                    break;
                case 9:
                    foreach (GameObject p in EnemysPoints)
                    {
                        if (p.name == "EnemyPoint9")
                        {
                            NextEnemyPosition = p.transform.position;
                        }
                    }
                    EnemyMove = true;
                    StartCoroutine(Wait1sec(1f));
                    break;

            }  // Choice-position procedure

            
        }
        
    } // Slightly crazy method, but i dont know how to use list<GameObject>.Find() properly.

    IEnumerator Wait1sec(float wait)
    {
        EnemyMove = true;
        yield return new WaitForSeconds(wait);
        EnemyMove = false;
    }


    //___________________________________Enemy moving speed______________________________________
    void EnemyMoving() 
    {
        float m_speed = 0;
        if (EnemyMove)
        {
            m_speed = EnemySpeed * Time.deltaTime; // Enemy's speed
            this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position,
                                                                NextEnemyPosition, EnemySpeed);
            
        }
        if (!EnemyMove)
        {
            m_speed = 0;
        }
        

    }
    

    //____________________________________Enemy looks on the Player_______________________________
    void EnemyLookOnPlayer()
    {
        this.gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform,
                                         new Vector3(1f, 0f, 0f));
    }


    //____________________________________Shooting AI____________________________________________
    #region Shooting AI
    private float ShootingWait = 0.1f; // How much time enemy wait
    private float ShootingTime = 0f; // How much time enemy Attack me
    private bool ShootBool = false; // Shoot or not?

    [Header("Pause between shooting")]
    [Tooltip("Random value 1")]
    public float rand = 0.01f; // Random value 1
    [Tooltip("Random value 2")]
    [Range(0.01f, 0.125f)]public float rand2 = 0.1f; // Random value 2

    void EnemyShootingWait()
    {
        // Timer
        ShootingWait += 0.35f * Time.deltaTime;
        if (ShootingWait > 1.5f)
        {
            ShootingWait = Random.Range(0.1f, 0.3f);
            ShootingTime = Random.Range(2f, 3f);
            StartCoroutine(Shooting(ShootingTime));
        }
        

        // Create Bullets if ShootBool == true
        
        if (ShootBool)
        {
            rand += 0.02f * Time.deltaTime;
            if (rand > rand2)
            {
                GameObject EmptyBullet = Instantiate(BulletPrefab, EnemyGunPosition.transform.position, Quaternion.identity);
                EmptyBullet.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
                EmptyBullet.transform.SetParent(null);
                rand = 0;
                if (rand != 0)
                {
                    rand = 0;
                } // Additional little cheker for debug.
            }
            
        }

    }
    #endregion
    
    // It needs to setup a wait. Means how much time Enemy shooting and how much time not shooting;
    IEnumerator Shooting(float time)
    {
        ShootBool = true;
        yield return new WaitForSeconds(time);
        ShootBool = false;
        rand = 0;
    }



    //____________________________________Update Method__________________________________________
    void Update()
    {
        HealthScroll.GetComponent<Scrollbar>().size = EnemyHealth; // Show how much health have our Enemy
        CanvasStabilized();
        EnemyLookOnPlayer();
        PathAI();
        EnemyMoving();
        EnemyShootingWait();
        
    }
}
