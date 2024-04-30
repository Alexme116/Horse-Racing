using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countDownText;
    float initTime= 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        initTime -= Time.deltaTime;
        countDownText.text = initTime.ToString("Starts in: 0");
        if(initTime <= 1)
        {
            countDownText.text = "GO!";
            Destroy(gameObject, 1);
        }
    }
}
