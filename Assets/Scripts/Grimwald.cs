using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grimwald : EnemyController
{

    public GameObject bulletSpawn;
    public float disapperDistance = 15;
    public float timeToShoot = 1;
    float timer;
    public bool disappearTriggered;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();


    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        if (GameManager1.instance.player == null)
        {
            return;
        }

        timer += 1 * Time.deltaTime;

        if(timer >= timeToShoot)
        {
            GameObject spawnedBullet = (GameObject)(Instantiate(Projectile, bulletSpawn.transform.position, Quaternion.identity));
            spawnedBullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * 1000);
            spawnedBullet.transform.rotation = Quaternion.Euler(0, 0, -90);
            spawnedBullet.gameObject.name = "Grimwald bullet";
            onShoot.Invoke();
            Destroy(spawnedBullet, 5);
            timer = 0;
        }

        if ((transform.position.x > GameManager1.instance.player.transform.position.x) && Vector3.Distance(transform.position, GameManager1.instance.player.transform.position) < chaseDistance)

        {
            // this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y);
            // rb.MovePosition(new Vector3(this.transform.position.x, player.transform.position.y));
            if (GameManager1.instance.player.transform.position.y > transform.position.y)
            {
                //print("player is above");
                transform.Translate(0, followSpeed * Time.deltaTime, 0);
            }
            if (GameManager1.instance.player.transform.position.y < transform.position.y)
            {
                //print("player is below");
                transform.Translate(0, -followSpeed * Time.deltaTime, 0);
            }

        }

        if (disappearTriggered == false && distanceToPlayer < disapperDistance)
        {
            disappearTriggered = true;
            ResetPosition();
            disappearTriggered = false;
            Debug.Log("disappearTriggered");
        }



    }
}
