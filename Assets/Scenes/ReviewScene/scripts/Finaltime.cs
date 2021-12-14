using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finaltime : MonoBehaviour
{
    [SerializeField] Text finaltime;

    // Start is called before the first frame update
    void Start()
    {
        if (Stopwatch.timer == null)
        {
            finaltime.text = "00:00:00";
        }
        else
        {
            finaltime.text = Stopwatch.timer;
        }
        //print(Stopwatch.timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
