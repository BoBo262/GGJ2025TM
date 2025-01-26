using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private float horizontal;
    private float vertical;
    [SerializeField] public float speed = 3f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (rb.velocity != new Vector2(0, 0))
        {
            AudioManager.Instance.PlaySound("Swim", false);
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rb.velocity = new Vector2(0,0);
    }


}
