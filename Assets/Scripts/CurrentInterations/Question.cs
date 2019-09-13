using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Question : MonoBehaviour
{
    #region Singleton

    public static Question instance;
    static Queue<string> q = new Queue<string>();

    void Awake()
    {
        instance = this;
        using (var reader = new StreamReader(@"Assets/Data/hexaco.csv"))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                foreach (string value in values)
                {
                    q.Enqueue("How much do you agree or disagree with this statement?\n" + value);
                }
            }
        }
    }

    #endregion

    public static Queue<string> getQ()
    {
        return Question.q;
    }

    public string GetQuestion()
    {
        if (q.Count > 0)
        {
            return q.Dequeue();
        }
        else
        {
            return "I have no more questions! Thank you for everything!";
        }
    }

}
