using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public Transform gunFront;
    private Rigidbody2D rb;
    public float force;
    [SerializeField] float aliveTime;
    [SerializeField] public float damage;
    private IEnumerator countdown;
    // Start is called before the first frame update
    void Start()
    {
        gunFront=GameObject.FindGameObjectWithTag("PirateHand").transform;
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = gunFront.position - transform.position;
        Vector3 rotation = transform.position - gunFront.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        countdown = WaitToDestroy(aliveTime);
        StartCoroutine(countdown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitToDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
