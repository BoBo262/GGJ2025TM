using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public float pirateDeaths;
    public GameObject winSprite;
    public GameObject mermaid;
    // Start is called before the first frame update
    void Start()
    {
        pirateDeaths = 0;
        mermaid = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (pirateDeaths == 2)
        {
            mermaid.SetActive(false);
            winSprite.SetActive(true);
        }
    }
}
