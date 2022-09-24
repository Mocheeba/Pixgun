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

        [Header ("Sound")]
        [SerializeField] private AudioClip sound;

        [Header ("Character Image")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image imageHolder;

        private void Awake()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";

            StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound));
            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
        }
    }
}