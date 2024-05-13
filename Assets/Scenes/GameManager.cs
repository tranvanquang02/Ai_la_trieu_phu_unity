using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace section2
{
    [Serializable]
    public enum GameState
    {
        Home,
        GamePlay,
        GameOver
    }
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI question;
        [SerializeField] private TextMeshProUGUI answerA;
        [SerializeField] private TextMeshProUGUI answerB;
        [SerializeField] private TextMeshProUGUI answerC;
        [SerializeField] private TextMeshProUGUI answerD;

        //[SerializeField] private questionData[] questionData;
        [SerializeField] private QuestionData[] questionData;

        [SerializeField] private Image imageA;
        [SerializeField] private Image imageB;
        [SerializeField] private Image imageC;
        [SerializeField] private Image imageD;

        [SerializeField] private GameObject m_Homepanel;
        [SerializeField] private GameObject m_Gameplay;
        [SerializeField] private GameObject m_Gameover;

        [SerializeField] private Sprite m_btngreen;
        [SerializeField] private Sprite m_btnyellow;
        [SerializeField] private Sprite m_btnblack;

        [SerializeField] private AudioClip m_correct;
        [SerializeField] private AudioClip m_mainaudio;
        [SerializeField] private AudioClip m_wrong;

        [SerializeField] private AudioSource m_audiosource;

        private int Cquestion;
        private GameState m_gameState;

        // Start is called before the first frame update
        void Start()
        {
            setGameState(GameState.Home);
            Cquestion = 0;
            countinueQuestion(0);
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void answerCorrec(string selectAnswer)
        {
            bool answer = false;
            if (questionData[Cquestion].correctAnswer == selectAnswer)
            {
                Debug.Log("ban tra loi chinh xac");
                answer = true;
                m_audiosource.PlayOneShot(m_correct);
            }
            else
            {
                Debug.Log("ban tra loi sai");
                answer = false;
                m_audiosource.PlayOneShot(m_wrong);
                //setGameState(GameState.GameOver);
                
            }
            switch (selectAnswer)
            {
                case "a":
                    imageA.sprite = answer == false? m_btnyellow : m_btngreen;
                    break;
                case "b":
                    imageB.sprite = answer == false? m_btnyellow : m_btngreen;
                    break;
                case "c":
                    imageC.sprite = answer == false? m_btnyellow : m_btngreen;
                    break;
                case "d":
                    imageD.sprite = answer == false? m_btnyellow : m_btngreen;
                    break;

            }
            
            if (answer == true)
            {
                if (Cquestion >= questionData.Length) {return;}
                Invoke("next", 3);
            }
            else
            {
                Invoke("GameOver", 3);
            }
        }
        private void next()
        {
            Cquestion = Cquestion + 1;
            countinueQuestion(Cquestion);
        }
        private void GameOver()
        {
            setGameState(GameState.GameOver);
            countinueQuestion(Cquestion);
            m_audiosource.Stop();
        }
        void countinueQuestion(int p)
        {
            if(p< 0 || p >= questionData.Length) { return;}
            imageA.sprite = m_btnblack;
            imageB.sprite = m_btnblack;
            imageC.sprite = m_btnblack;
            imageD.sprite= m_btnblack;

            question.text = questionData[p].title;
            answerA.text = questionData[p].answrerA;
            answerB.text= questionData[p].answrerB;
            answerC.text= questionData[p].answrerC;
            answerD.text= questionData[p].answrerD;

        }
        public void setGameState(GameState state)
        { 
            m_gameState = state;
            m_Homepanel.SetActive(m_gameState == GameState.Home);
            m_Gameplay.SetActive(m_gameState == GameState.GamePlay);
            m_Gameover.SetActive(m_gameState == GameState.GameOver);
        }
        public void btnPLayPresss()
        {
            setGameState(GameState.GamePlay);
            m_audiosource.clip = m_mainaudio;
            m_audiosource.Play();
        }
        public void btnHomePress()
        {
            setGameState(GameState.Home);
        }

    }
}
