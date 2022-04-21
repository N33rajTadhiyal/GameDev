using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreSetter : MonoBehaviour
{
    public Text points;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        score=0;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }
    void UpdateText()
    {
        points.text=score.ToString();
    }
}
