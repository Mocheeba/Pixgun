using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private Text textHolder;

        [Header ("Text Options")]
        [SerializeField] private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;

        [Header ("Time Parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;

        [Header ("Sound")]
        [SerializeField] private AudioClip sound;

        [Header ("Character Image")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image imageHolder;

        private IEnumerator lineApear;
        
        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Deactivate();
                gameObject.SetActive = false;
            }

            else if (Input.GetMouseButtonDown(0))
            {
                if (textHolder.text != input)
                {
                    StartCoroutine(lineApear);
                    textHolder.text = input;
                }
                else
                    finished = true;
            }
        }


        private void Awake()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";

            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
        }

        private void Start() {
            lineApear = WriteText(input, textHolder, textColor, textFont, delay, sound, delayBetweenLines);
            StartCoroutine(lineApear);
        }
    }
}