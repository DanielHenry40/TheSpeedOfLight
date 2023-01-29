using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public int playerscore;
    //public GameObject enemySpawnPoints[0];

    public List<GameObject> enemySpawnPoints = new List<GameObject>();

    public static GameManager1 instance;
    public List<GameObject> enemyPrefab = new List<GameObject>();
    public List<EnemyController> activeEnemies = new List<EnemyController>();
    public GameObject player;
    public int enemiesDestroyed;
    public int waveCount = 0;
    public Text scoreCounter;
    public Text waveCounter;
    public Text playerHealth;



    public UnityEvent enemyShipDestroyed;


    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        // Instantiate(enemyPrefab[0],enemySpawnPoints[0].transform.position,Quaternion.identity);

        scoreCounter.text = "Score:0000";
        waveCounter.text = "Wave:0";
        
    }

    public Vector3 getRespawnPosition(int min, int max)
    {
        return enemySpawnPoints[Random.Range(min, max)].transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            return;
        }

        if (player.GetComponent<PlayerMovement>().Playerhealth <= 0)
        {
            return;
        }

        scoreCounter.text = "Score: " + playerscore;
        waveCounter.text = "Wave: " + waveCount;
        playerHealth.text = "Health :" + player.GetComponent<PlayerMovement>().Playerhealth;

        if (activeEnemies.Count == 0)
        {

            if (enemiesDestroyed == 0)
            {
                Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0,2)], enemySpawnPoints[Random.Range(0, 10)].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 1)].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 7)].transform.position, Quaternion.identity);
                waveCount++;

                //Instantiate(enemyPrefab[0], enemySpawnPoints[2].transform.position, Quaternion.identity);
                //Instantiate(enemyPrefab[0], enemySpawnPoints[3].transform.position, Quaternion.identity);

            }

            else if (enemiesDestroyed == 4)
            {
                // Instantiate(enemyPrefab[0], enemySpawnPoints[3].transform.position, Quaternion.identity);
                // Instantiate(enemyPrefab[0], enemySpawnPoints[2].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 8)].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 5)].transform.position, Quaternion.identity);
                waveCount++;

            }


            if (enemiesDestroyed >5 && enemiesDestroyed < 9)
            {
                //Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
                // Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
                // Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 2)].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 9)].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 6)].transform.position, Quaternion.identity);
                waveCount++;

            }

            if (enemiesDestroyed > 8 && enemiesDestroyed < 12)
            {
                // Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
                // Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 10)].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 10)].transform.position, Quaternion.identity);
                waveCount++;
            }

            if(playerscore > 11)
            {
                // Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
                //  Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
                // Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
                // Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
                // Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
                // Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
                // Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
                // Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
                // Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
                //  Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 10)].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 8)].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 6)].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 4)].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 1)].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 3)].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 5)].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 7)].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 9)].transform.position, Quaternion.identity);
                Instantiate(enemyPrefab[Random.Range(0, 2)], enemySpawnPoints[Random.Range(0, 1)].transform.position, Quaternion.identity);
                waveCount++;
            }
        }

    }






    public void EnemyShipDestroyedEvent()
    {
        //Instantiate(enemyPrefab[0], enemySpawnPoints[0].transform.position, Quaternion.identity);
    }
}
