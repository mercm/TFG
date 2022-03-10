using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine;
using System;

public class Recognizer : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, Action> keywords;// = new Dictionary<string, System.Action>();
    //Dictionary<string, Action> keywords = new Dictionary<string, Action>();
    private Manager manager;
    public GameObject ManagerGO;

    // Start is called before the first frame update
    void Start()
    {
        manager = ManagerGO.GetComponent<Manager>();
        keywords = new Dictionary<string, System.Action>();
    }

    public void disableRecognizer()
    {
        keywordRecognizer.Stop();
    }

    public void enableRecognizer()
    {
        //Create keywords for keyword recognizer
        keywords.Clear();

        foreach (string kw in Preparation.kwordNeeded)
        {
            //keywords.Add(kw, Function);
            keywords.Add(kw, () =>
            {
                //action to be performed when this keyword is spoken
                //if player did a silence before de keyword
                /*if (soundloudness.silence4kw == 1)
                {
                     manager.setpoints(manager.categorypts.perfect);
                    manager.setpoints(5);
                }
                //if player did more than 1 silence before de keyword
                else if (soundloudness.silence4kw > 1)
                {
                    manager.setpoints(1);
                }
                //if playes did not do any silence before the keyword
                else
                {
                    manager.setpoints(-2);
                }
                soundloudness.silence4kw = 0;*/
                manager.setPoints(5);
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
        //Debug.Log("He detectado " + args.text);
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
            Debug.Log(args.text);
        }
    }

    private void Function()
    {
        manager.setPoints(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
