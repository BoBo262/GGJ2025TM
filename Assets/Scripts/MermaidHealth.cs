using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermaidHealth : MonoBehaviour
{

    [SerializeField] public float health;
    public DamageSink damageSink;
    // Start is called before the first frame update
    void Start()
    {
        damageSink = gameObject.GetComponent<DamageSink>();
        damageSink.hp = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BallBehaviour>())
        {
            BallBehaviour bullet = collision.gameObject.GetComponent<BallBehaviour>();
            damageSink.TakeDamage(bullet.damage);
            Destroy(bullet.gameObject);
            if (damageSink.destroyed)
            {
                OnDestroy();
            }
        }
    }

    public void OnDestroy()
    {
        Debug.Log("Siren Is Killed");
        Destroy(gameObject);
        

    }
}
