using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{   
    [SerializeField] private MonsterManager m_monsterManager;

    [SerializeField] private TMP_Text m_messageBoxTextField;
    [SerializeField] private TMP_InputField m_answerInputField;
    [SerializeField] private int answer;

    [SerializeField] private WeeklyAssignments m_weeklyAssignments;
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateQuestion();
        ValidateAnswer();

        //Weekly Assignments :
        m_weeklyAssignments.KnowHigher();
        m_weeklyAssignments.DisplaySortedNumbers();
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateQuestion()
    {
        var qa = GenerateAddandSubtract(1, 100);

        //Show question on the screen
        m_messageBoxTextField.text = qa.question;

        //Clear Input Field and Focus on the Inputbox:
        ClearInputField();
    }

    private (string question, int answer) GenerateAddandSubtract(int min, int max)
    {
        string question = "";
        //Generate Random Numbers for each operands.
        int operand1 = Random.Range(min, max);
        int operand2 = Random.Range(min, max);

        //Logic for generating the probability of occurrence of + and -
        if (Random.value < 0.5f)
        {
            //Addition
            question = $"{operand1} + {operand2}";
            answer = operand1 + operand2;
        }
        else
        {
            //Subtraction
            question = $"{operand1} - {operand2}";
            answer = operand1 - operand2;
        }

        return (question, answer);
    }

    public void ValidateAnswer()
    {
        if(m_answerInputField.text == answer.ToString())
        {
            m_monsterManager.KillMonster(0);
            m_monsterManager.MonsterAttacks(0);
            m_monsterManager.MoveNextMonsterToQueue();
            GenerateQuestion();
        }
        else
        {
            ClearInputField();
        }
    }

    private void ClearInputField()
      {
        //Clear Input field:
        m_answerInputField.text = "";

        //Focus the input field
        m_answerInputField.ActivateInputField();
    }

   
}
