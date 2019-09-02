using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawnScript : MonoBehaviour
{
    [Header("Meteors stuff")]
    public GameObject MeteorPrefab = null;
    public List<GameObject> SpawnPoints = new List<GameObject>(); // Massive of Meteors
    private GameObject Generalmesh = null; // Meteors
    private int ChildsCount = 0; // Counts of Meteors
    private int RandomValue = 0; // Random value of Birth Points
    private int LastRandomValue = 0; // Last random value (for fix "repeat problem")
    private bool NewBirth = false;

    [Header("Timer and Birth-Speed")]
    public float m_Timer = 0f; // Timer
    public float BirthSpeed = 0.6f; // BirthSpeed of Meteors - Hardnes
    
    private void Start()
    {
        Generalmesh = GameObject.Find("SpawnMeteors").gameObject; // setup the Mother of All meteors
        ChildsCount = Generalmesh.transform.childCount; // child count of all spawn points
        for (int i = 0; i < ChildsCount; i++)
        {
            SpawnPoints.Add(Generalmesh.transform.GetChild(i).transform.gameObject);
        }
    }
    //_________________________Timer______________________________
    void TimerMethod()
    {
        m_Timer += BirthSpeed * Time.deltaTime;
        NewBirth = false;
        if (m_Timer >= 1f)
        {
            NewBirth = true;
            RandomValue = Random.Range(1, 5);
            m_Timer = 0f;
        }
    }

    //_________________________Birth a new Asteroids______________
    void BirthAsteroids()
    {
        if (NewBirth)
        {
            if ((RandomValue == LastRandomValue) && (RandomValue < 5))
            {
                RandomValue += 1;
            }
            switch (RandomValue)
            {
                case 1:
                    foreach (GameObject m_mesh in SpawnPoints)
                    {
                        if (m_mesh.name == "SpawnPoint1")
                        {
                            Vector3 BirthPoint = m_mesh.transform.position;
                            Instantiate(MeteorPrefab, BirthPoint, new Quaternion(0f, 0f, 0.2f, 0f));
                        }
                    }
                    break;
                case 2:
                    foreach (GameObject m_mesh in SpawnPoints)
                    {
                        if (m_mesh.name == "SpawnPoint2")
                        {
                            Vector3 BirthPoint = m_mesh.transform.position;
                            Instantiate(MeteorPrefab, BirthPoint, new Quaternion(0f, 0f, 0.1f, 0f));
                        }
                    }
                    break;
                case 3:
                    foreach (GameObject m_mesh in SpawnPoints)
                    {
                        if (m_mesh.name == "SpawnPoint3")
                        {
                            Vector3 BirthPoint = m_mesh.transform.position;
                            Instantiate(MeteorPrefab, BirthPoint, new Quaternion(0f, 0f, 0.17f, 0f));
                        }
                    }
                    break;
                case 4:
                    foreach (GameObject m_mesh in SpawnPoints)
                    {
                        if (m_mesh.name == "SpawnPoint4")
                        {
                            Vector3 BirthPoint = m_mesh.transform.position;
                            Instantiate(MeteorPrefab, BirthPoint, new Quaternion(0f, 0f, 0.34f, 0f));
                        }
                    }
                    break;
                case 5:
                    foreach (GameObject m_mesh in SpawnPoints)
                    {
                        if (m_mesh.name == "SpawnPoint5")
                        {
                            Vector3 BirthPoint = m_mesh.transform.position;
                            Instantiate(MeteorPrefab, BirthPoint, new Quaternion(0f, 0f, 0.03f, 0f));
                        }
                    }
                    break;
            }
        }
        
    }


    //_________________________Update Method______________________
    void Update()
    {
        TimerMethod();
        BirthAsteroids();
    }
}
