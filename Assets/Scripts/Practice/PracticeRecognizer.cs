using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine;
using System;

public class PracticeRecognizer : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, Action> keywords;// = new Dictionary<string, System.Action>();
    private PracticeVolumeManager manager;
    public GameObject ManagerGO;

    // Start is called before the first frame update
    void Start()
    {
        manager = ManagerGO.GetComponent<PracticeVolumeManager>();
        keywords = new Dictionary<string, System.Action>();
    }

    public void DisableRecognizer()
    {
        keywordRecognizer.Stop();
    }

    public void EnableRecognizer()
    {
        //Create keywords for keyword recognizer
        keywords.Clear();

        foreach (string kw in PracticeVolumePreparation.kwordNeeded)
        {
            keywords.Add(kw, () =>
            {
                //action to be performed when this keyword is spoken
                //if player did a silence before de keyword
                if (PracticeSoundLoudness.silence4kw == 1)
                {
                    manager.SetPoints(5);
                    Debug.Log("5 points");
                }
                //if player did more than 1 silence before de keyword
                else if (PracticeSoundLoudness.silence4kw > 1)
                {
                    manager.SetPoints(1);
                    Debug.Log("1 points");
                }
                //if playes did not do any silence before the keyword
                else
                {
                    manager.SetPoints(-2);
                    Debug.Log("-2 points");
                }
                PracticeSoundLoudness.silence4kw = 0;
            });
        }
        if (keywordRecognizer != null)
        {
            keywordRecognizer.Dispose();
        }
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        // if the keyword recognized is in our dictionary, call that Action.
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
            Debug.Log(args.text);
        }
    }

    private void Function()
    {
        manager.SetPoints(5);
    }
}
