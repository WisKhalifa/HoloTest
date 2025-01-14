﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour {

    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	// Use this for initialization
	void Start () {
        keywords.Add("Reset world", () =>
        {
            this.BroadcastMessage("OnReset");
        });
        keywords.Add("Main menu", () =>
        {
            this.BroadcastMessage("OnMainMenu");
        });
        keywords.Add("Test Models", () =>
        {
            this.BroadcastMessage("OnTestModels");
        });
        keywords.Add("Help", () =>
        {
            this.BroadcastMessage("OnHelp");
        });
        keywords.Add("Create graph", () =>
        {
            this.BroadcastMessage("OnCreateGraph");
        });


        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
	}

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
