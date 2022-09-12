using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizGame : MonoBehaviour

{
    [Header("Questions")]
    [SerializeField] List<QuestionSO> questions= new List<QuestionSO>();
    public QuestionSO curentQuestion;
    [SerializeField] TextMeshProUGUI  questionText;
    [Header("Anwsers")]
    [SerializeField] GameObject[] anwserbotons;
    int correctIndex;
    [Header("Button Colors")]
    [SerializeField] Sprite corectColor;
    [SerializeField] Sprite normalColor;
    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer  timer;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    Scorekeeoer scorekeeper;
    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;
    public bool isComplete;

   

    // Start is called before the first frame update
    void Start()
    {
        curentQuestion = questions[0];
        timer = FindObjectOfType<Timer>();
        scorekeeper = FindObjectOfType<Scorekeeoer>();
        displayQuestions();
       
    }
    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextquestion)
        {
            getNextQuestion();
            timer.loadNextquestion = false;
        }
    }

    public void OnAnserSelect(int index)
    {
        if(index== curentQuestion.getCorectAnwserIndex())
        {
            questionText.text = "Correct";
            Image buttonImage = anwserbotons[index].GetComponent<Image>();
            buttonImage.sprite = corectColor;
            scorekeeper.incrementPoints();
        }
        else
        {
            questionText.text = "Sorry wrong";
            Image buttonImage = anwserbotons[curentQuestion.getCorectAnwserIndex()].GetComponent<Image>();
            buttonImage.sprite = corectColor;
        }
        setButton(false);
        timer.cancelTimer();
        scoreText.text = "Score:" + scorekeeper.calculeScore() + "%";
        
    }
    
    public void displayQuestions()
    {
        questionText.text = curentQuestion.getQuestion();
        for (int i = 0; i < anwserbotons.Length; i++)
        {
            TextMeshProUGUI buttonText = anwserbotons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = curentQuestion.getCorectAwnser(i);
        }

    }
    void getRandonQueston()
    {
        int index = Random.Range(0, questions.Count);
       
        
            curentQuestion = questions[index];
            if (questions.Contains(curentQuestion))
            {
                questions.Remove(curentQuestion);
            }
        
        
    }
        

    void getNextQuestion()
    {
        if(questions.Count> 0)
        {
            setButton(true);
            setButtonSprite();
            getRandonQueston();
            displayQuestions();
            scorekeeper.incrementQuestions();
           
        }
        
    }

    
     void setButton(bool butoonSate)
    {
        for (int i = 0; i < anwserbotons.Length; i++)
        {
            Button button = anwserbotons[i].GetComponentInChildren<Button>();
            button.interactable = butoonSate;
        }
    }

    void setButtonSprite()
    {
        for(int i= 0; i< anwserbotons.Length; i++)
        {
            Image buttonImage = anwserbotons[i].GetComponent<Image>();
            buttonImage.sprite = normalColor;
        }
    }
    // Update is called once per frame
  
}
