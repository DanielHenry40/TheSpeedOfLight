using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leech : EnemyController
{
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
    }
}
