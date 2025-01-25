using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSink : MonoBehaviour
{
    public bool destroyed;
    public float hp;

    // Start is called before the first frame update
    void Start()
    {
        destroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            destroyed = true;
        }
    }
}
