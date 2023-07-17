using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text textObj;
    [SerializeField]
    Text timeText;

    //int score = 0;


    public int countdownMinutes = 3;
    private float countdownSeconds;  
    

    // Start is called before the first frame update
    void Start()
    {
        //timeText = GetComponent<Text>();
        countdownSeconds = countdownMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");

        if (countdownSeconds <= 0)
        {
            //０秒になった時の処理
        }
            
        ExpressMoney();
    }

    public void ExpressMoney()
    {
       // score += point;
        textObj.text = "" + SaveManager.Money;
    }
}
