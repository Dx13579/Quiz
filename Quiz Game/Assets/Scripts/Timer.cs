using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float timerValue;
    [SerializeField ] float timeToCompleteQuestion= 30f;
    [SerializeField] float timeToShowCorretAwnser = 10f;
    public  bool loadNextquestion;
    public bool isAnwserQuestion = false;
    public float fillFraction;

    private void Update()
    {
        UpdateTimer();
    }
     public  void cancelTimer()
    {
        timerValue = 0;
    }
    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if (isAnwserQuestion)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else 
            {
               
                isAnwserQuestion = false;
                timerValue = timeToShowCorretAwnser;

            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorretAwnser;
            }
            else 
            {
                timerValue = timeToCompleteQuestion;
                isAnwserQuestion = true;
                loadNextquestion = true;
                

            }
        }
      
        
    }

}
