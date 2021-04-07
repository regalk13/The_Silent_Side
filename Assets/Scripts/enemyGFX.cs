using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
     float distance = Mathf.Abs(player.transform.position.x - transform.position.x);
     if(aiPath.desiredVelocity.x >= 0.01f)
     {
         transform.localScale = new Vector3(-1, 1f, 1f);
     }else if (aiPath.desiredVelocity.x <= -0.01f)
     {
         transform.localScale = new Vector3(1f, 1f, 1f);
     }
    }
}
