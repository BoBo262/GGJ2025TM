using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float oLoss;
    public OxigenMeter o2;
    public Camera mainCamera;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenShots;
    // Start is called before the first frame update
    void Start()
    {
        o2 = gameObject.GetComponentInParent<OxigenMeter>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(!canFire)
        {
            timer += Time.deltaTime;
            if(timer> timeBetweenShots)
            {
                canFire = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            o2.oxigenCurr -= oLoss;
            AudioManager.Instance.PlaySound("Bubble_Burst3");
        }
    }
}
