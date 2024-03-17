using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace section2 {
    [CreateAssetMenu(fileName = "questionData")]
    public class QuestionData : ScriptableObject
    {
        
            public string title;
            public string answrerA;
            public string answrerB;
            public string answrerC;
            public string answrerD;
            public string correctAnswer;
        
    }
}
