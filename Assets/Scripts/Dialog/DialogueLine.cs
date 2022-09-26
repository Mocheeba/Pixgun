using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine: DialogueBaseClass
    {   
        [Header ("Settings")]
        private Text textHolder;
        [SerializeField] private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;

        [Header ("Time")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;

        [Header ("Audio")]
         [SerializeField] private AudioClip sound;

        
        [Header ("Character Image")]
         [SerializeField] private Sprite characterSprite;
         [SerializeField] private Image imageHolder;

         private IEnumerator lineAppear;


        private void Awake()
        {
            

            imageHolder.sprite = characterSprite;
            //imageHolder.preserveAspect = true;
        }


        private void OnEnable()
        {
            ResetLine();
            lineAppear = WriteText(input, textHolder, textColor, textFont, delay, sound, delayBetweenLines);
            StartCoroutine(lineAppear);

        }
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if(textHolder.text != input )
                {
                    StopCoroutine(lineAppear);
                    textHolder.text = input;
                }
                else
                    finished = true;
            }
        }

        private void ResetLine()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            finished = false;
        }
    }
}



