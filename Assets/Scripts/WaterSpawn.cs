using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaterSpawn : MonoBehaviour
{
     Transform[] points;
    public GameObject obj;
    public GameObject player;
    PlayerStat playerStat;

    private void Start()
    {
        points = obj.GetComponentsInChildren<Transform>();
        playerStat = player.GetComponent<PlayerStat>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 playerposition = other.transform.position;
           
            int i = 0;
            int minindex = 0;
            float mindis = float.MaxValue;
            foreach(Transform p in points)
            { 

                float distance =  Vector3.Distance(playerposition, p.position);
                if(mindis > distance)
                {
                    mindis = distance;
                    minindex = i;
                }
                i++;
            }


            player.transform.position = points[minindex].position;
            playerStat.TakeDamage(20);
        }
    }
}
