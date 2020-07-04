using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
    public Sprite cg;
}

public class UI_Dialogue : MonoBehaviour
{
    public static UI_Dialogue Instance;

    [SerializeField] private SpriteRenderer sprite_Standing;
    [SerializeField] private SpriteRenderer sprite_Dialogue;
    [SerializeField] private Text dialogueText;

    private bool isDialogue = false;

    private int count = 0;

    [SerializeField] private Dialogue[] dialogue;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    public void OnClick_ShowDialogue(Dialogue _dialogue)
    {
        OnOff(true);
        count = 0;
        dialogueText.text = _dialogue.dialogue;
        sprite_Standing.sprite = _dialogue.cg;
    }

    private void NextDialogue()
    {
        dialogueText.text = dialogue[count].dialogue;
        sprite_Standing.sprite = dialogue[count].cg;
        count++;
    }

    private void OnOff(bool _flag)
    {
        sprite_Dialogue.gameObject.SetActive(_flag);
        sprite_Standing.gameObject.SetActive(_flag);
        dialogueText.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    private void Update()
    {
        if (isDialogue)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if(count < dialogue.Length)
                {
                    NextDialogue();
                }
                else
                {
                    OnOff(false);
                }
            }
        }
    }
}
