using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public float  Movementforce;
    public float Horizontal;
    public float Vertical;
    public float Maxspeed = 3;

    public int Playerhealth = 100;

    public UnityEvent onShoot;
    public UnityEvent onHit;
    public UnityEvent onDeath;

    public GameObject bullet;
    public Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(Vector3.left * 0.1f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(Vector3.right * 0.1f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.Translate(Vector3.up * 0.1f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.Translate(Vector3.down * 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject spawnedBullet = (GameObject)(Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity));
            spawnedBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 1000);
            spawnedBullet.transform.rotation = Quaternion.Euler(0, 0, -90);
            spawnedBullet.gameObject.name = "player bullet";
            Destroy(spawnedBullet, 5);
            onShoot.Invoke();
        }
    }
    void TakeDamage(int hitamount)
    {
        Playerhealth = Playerhealth - hitamount;
        onHit.Invoke();
        if(Playerhealth <= 0)
        {
            playerDeath();
        }
    }

    void playerDeath()
    {
        onDeath.Invoke();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //return;
        if (collision.gameObject.tag == "EnemyBullet")
        {
            TakeDamage(5);
            Destroy(collision.gameObject);
            Debug.Log("collide with enemy bullet");
           


        }
    }
}
