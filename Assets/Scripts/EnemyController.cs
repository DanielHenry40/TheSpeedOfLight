using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public float chaseDistanceMax;
    public float chaseDistanceMin;
    public float chaseDistance;
    public float EnemyFire;
    public GameObject Projectile;
    Rigidbody2D rb;
    public float speed = .5f;
    public float followSpeed = 2;
    public int enemyscorevalue = 1;
    public float distanceToPlayer;


    public UnityEvent onShoot;
    public UnityEvent onHit;
    public UnityEvent onDeath;

    public GameObject onDeathFX;

    //public float EnemySpeed = 5;
    // Start is called before the first frame update
    protected void Start()
    {
        //Instantiate(Projectile);
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        GameManager1.instance.activeEnemies.Add(this);

        chaseDistance = Random.Range(chaseDistanceMin, chaseDistanceMax);

    }

    // Update is called once per frame
    protected void Update()
    {
   
        if(GameManager1.instance == null || GameManager1.instance.player == null)
        {
            return;
        }

        distanceToPlayer = Vector2.Distance(transform.position, GameManager1.instance.player.transform.position);

        //transform.Translate(0, 0, EnemySpeed); 
        rb.velocity = (new Vector2(-speed, 0));
        if (transform.position.x < -85)
        {

            transform.position =  GameManager1.instance.getRespawnPosition(0, 11);
            Debug.Log("reset position");
        }

       // Debug.Log(Vector3.Distance(transform.position, GameManager1.instance.player.transform.position));



    }

    public void ResetPosition()
    {
        transform.position = GameManager1.instance.getRespawnPosition(0, 11);
    }

    public void ResetPosition(int min, int max)
    {
        transform.position = GameManager1.instance.getRespawnPosition(min, max);
    }


    private void OnDisable()
    {
        GameManager1.instance.activeEnemies.Remove(this);
        GameManager1.instance.playerscore += enemyscorevalue;
        GameManager1.instance.enemiesDestroyed += 1;
        GameManager1.instance.enemyShipDestroyed.Invoke();

    }

    public void onDeathSpawnFX()
    {
        Destroy(Instantiate(onDeathFX, this.transform.position,Quaternion.identity),2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //return;
        if(collision.gameObject.tag == "Bullet")
        {
            onDeath.Invoke();
            Destroy(collision.gameObject);
            Debug.Log("collide with bullet");
            Destroy(this.gameObject);
           
          
           
        }
    }




}


