using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChestOpening : MonoBehaviour
{
    // Start is called before the first frame update
    public ChestRewards rewards;
    void Start()
    {
        rewards = gameObject.GetComponent<ChestRewards>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            rewards.player = collision.gameObject;

            rewards.rewardTable(Random.Range(1,4));
            rewards.controller = rewards.player.GetComponent<PlayerController>();
            rewards.o2 = rewards.player.GetComponent<OxigenMeter>();
        }
    }
}
