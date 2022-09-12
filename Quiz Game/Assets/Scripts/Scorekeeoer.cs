using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorekeeoer : MonoBehaviour
{
    int points = 0;
    int question = 0;
    
    // Start is called before the first frame update

    public int getPoits()
    {
        return points;
    }
    public int getQuestion()
    {
        return question;
    }

    public void incrementPoints()
    {
        points++;
    }
    public void incrementQuestions()
    {
        question++;
    }
    public int calculeScore()
    {
        return Mathf.RoundToInt(points / (float)question * 100);
    }
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
