using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;
using UnityEngine.Events;
using System;

public class reconocedor : MonoBehaviour
{
  private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
  private KeywordRecognizer keywordRecognizer;  
    void OnKeywordsRecognized(PhraseRecognizedEventArgs args) {
      Debug.Log("Keyword: " + args.text);
      keywordActions[args.text].Invoke();
    }
    void Start()
    {
        keywordActions.Add("左", controladorjuego.left);
        keywordActions.Add("動く", controladorjuego.right);
        keywordActions.Add("変えて", controladorjuego.change);
        keywordActions.Add("up", controladorjuego.up);
        keywordActions.Add("down", controladorjuego.down);
        keywordActions.Add("写真", controladorjuego.photo);
        keywordActions.Add("遠い", controladorjuego.away);
        keywordActions.Add("近く", controladorjuego.close);
        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
