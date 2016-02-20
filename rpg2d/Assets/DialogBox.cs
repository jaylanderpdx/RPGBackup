using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DialogBox : MonoBehaviour {

    private Text dialogText;
    private Image dialogImage;
    private static DialogBox instance;

    void Awake()
    {
        instance = this;   
        dialogText = GetComponentInChildren<Text>();
        dialogImage = GetComponentInChildren<Image>();
        SetState(false);
    }

    public static void Hide()
    {
        instance.DoHide();
    }

    void SetState(bool State)
    {
        dialogText.enabled = State;
        dialogImage.enabled = State;
    }

    void DoHide()
    {
        SetState(false);
    }

    public static void Show(string NewDialogText)
    {
        instance.DoShow(NewDialogText);
    }

    void DoShow(string NewDialogText)
    {
        SetState(true);
        dialogText.text = NewDialogText;
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
