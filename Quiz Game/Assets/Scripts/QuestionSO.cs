using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Quiz Question", fileName ="New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField]string question = "Enter a question";
    [SerializeField] string[] awmsers = new string[4];

    public QuestionSO(string[] awmsers)
    {
        this.awmsers = awmsers;
    }

    [SerializeField] int corectAwnserIndex;

    public int getCorectAnwserIndex()
    {
        return corectAwnserIndex;
    }
    public string getCorectAwnser(int index)
    {
        return awmsers[index];
    }
    public string getQuestion()
    {
        return question;
    }

}
