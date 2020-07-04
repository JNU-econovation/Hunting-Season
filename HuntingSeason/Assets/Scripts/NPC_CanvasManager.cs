using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Button btn_dialogue;
    [SerializeField] Dialogue dialogue;
    private bool isMenu;
    private void Start()
    {
        btn_dialogue.onClick.AddListener( () =>
        {
            UI_Dialogue.Instance.OnClick_ShowDialogue(dialogue);
        });
    }
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 100f, layerMask);
        if(hit.collider == null)
        {
            HideMenu();
        }
    }
    public void ShowMenu()
    {
        menu.SetActive(true);
        isMenu = true;
        btn_dialogue.Select();
    }

    public void HideMenu()
    {
        menu.SetActive(false);
        isMenu = false;
    }
}
