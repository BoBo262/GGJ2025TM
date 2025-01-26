using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestRewards : MonoBehaviour
{
    public GameObject player;
    public PlayerController controller;
    public OxigenMeter o2;
    public game_scene_button chestCount;
    // Start is called before the first frame update
    void Start()
    {
        
        controller = player.GetComponent<PlayerController>();
        o2 = player.GetComponent<OxigenMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rewardTable(int drop)
    {
        switch(drop)
        {
            case 1:
                controller.speed *=1.5f;
                Debug.Log("First Reward");
                break;
            case 2:
                o2.oxigenFull *= 1.5f;
                Debug.Log("Second Reward");
                break;
            case 3:
                Debug.Log("Third Reward");
                break;
            default:
                Debug.Log("Error");
                break;
        }
        chestCount.chestCheck++;
        Destroy(gameObject);
    }
}
