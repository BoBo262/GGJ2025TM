using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateHealth : MonoBehaviour
{
    DamageSink damagePirate;
    public WinCondition winning;
    [SerializeField] public float health;
    // Start is called before the first frame update
    void Start()
    {
        damagePirate = gameObject.GetComponent<DamageSink>();
        damagePirate.hp = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BulletBehavior>())
        {
            BulletBehavior bubble = collision.gameObject.GetComponent<BulletBehavior>();
            damagePirate.TakeDamage(bubble.damage);
            Destroy(bubble.gameObject);
            if (damagePirate.destroyed)
            {
                OnDestroy();
            }
        }
    }

    public void OnDestroy()
    {
        Debug.Log("Pirate Killed");
        winning.pirateDeaths++;
        Destroy(gameObject);

    }
}
