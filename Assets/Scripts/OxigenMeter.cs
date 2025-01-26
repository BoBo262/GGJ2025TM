using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OxigenMeter : MonoBehaviour
{
    public TextMeshProUGUI o2Text;
    [SerializeField] public float oxigenFull;
    public float oxigenCurr;
    void Start()
    {
        oxigenCurr = oxigenFull;
    }

    // Update is called once per frame
    void Update()
    {
        if (oxigenCurr >= 0)
        {
            oxigenCurr -= Time.deltaTime*2;
        }
        if (oxigenCurr==20)
        {
            AudioManager.Instance.PlaySound("HelpMe");
        }
        if (oxigenCurr <=0.01)
        {
            oxigenCurr = 0;
            Debug.Log("No more oxigen");
            AudioManager.Instance.PlaySound("NoAir");
            
        }
        if (oxigenCurr > oxigenFull)
            oxigenCurr = oxigenFull;
        o2Text.text = oxigenCurr.ToString();
    }
}
