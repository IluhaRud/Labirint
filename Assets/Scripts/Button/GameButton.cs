using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButton : MonoBehaviour
{

    public GameObject buttonUp;
    public GameObject buttonDown;
    public GameObject buttonRight;
    public GameObject buttonLeft;

    public Sprite indi;
    public Sprite wall;
    public Sprite way;
    public Sprite treasures;

    public GameObject mainButton;

    public bool isMainButton;
    public bool isWall;
    public bool isFinish;
    public bool isMainPath;

    bool checkTriggers;
    bool checkDisable;

    bool checkInteractable;

    void Awake()
    {
        if (isMainButton)
        {
            gameObject.tag = "MainButton";
            GetComponent<Image>().sprite = indi;
            GetComponent<Button>().interactable = true;
        }
        if(!isMainButton)
        {
            gameObject.tag = "WayButton";
        }
        if(isWall)
        {
            gameObject.tag = "WallButton";
            GetComponent<Image>().sprite = wall;
        }
    }
    void Start()
    {
        if (isMainButton)
            mainButton = gameObject;
    }
    void Update()
    {
        CheckTriggers(gameObject);
        //DisableTriggersOnButton(gameObject, checkDisable);
        InteractableCheck(checkInteractable);

        if (gameObject.tag == "WallButton" && gameObject.GetComponent<Button>().interactable == true)
            gameObject.GetComponent<Image>().sprite = wall;

            AssignMainButton();

    }

    void DisableTriggersOnButton(GameObject button, bool check)
    {
        if (check)
            return;

            for (int i = 0; i < gameObject.transform.childCount; i++)
                if (button.transform.GetChild(i).gameObject.tag == "Trigger")
                    button.transform.GetChild(i).gameObject.SetActive(false);

        AssignMainButton();
        checkDisable = true;
    }
    void CheckTriggers(GameObject button)
    {
        if (button.transform.GetChild(0).gameObject.GetComponent<Trigger>().buttonInTrigger != null)
            buttonUp = button.transform.GetChild(0).gameObject.GetComponent<Trigger>().buttonInTrigger;
        if (button.transform.GetChild(1).gameObject.GetComponent<Trigger>().buttonInTrigger != null)
            buttonDown = button.transform.GetChild(1).gameObject.GetComponent<Trigger>().buttonInTrigger;
        if (button.transform.GetChild(2).gameObject.GetComponent<Trigger>().buttonInTrigger != null)
            buttonRight = button.transform.GetChild(2).gameObject.GetComponent<Trigger>().buttonInTrigger;
        if (button.transform.GetChild(3).gameObject.GetComponent<Trigger>().buttonInTrigger != null)
            buttonLeft = button.transform.GetChild(3).gameObject.GetComponent<Trigger>().buttonInTrigger;

    }
    public void AssignMainButton()
    {
        if (isMainButton)
        {
            if (buttonUp != null)
            {
                if (GetComponent<GameButton>().buttonUp.GetComponent<GameButton>().isWall == true)
                    GetComponent<GameButton>().buttonUp.GetComponent<Image>().sprite = wall;
                if (GetComponent<GameButton>().buttonUp.GetComponent<GameButton>().isFinish == true)
                    GetComponent<GameButton>().buttonUp.GetComponent<Image>().sprite = treasures;
                buttonUp.GetComponent<GameButton>().mainButton = gameObject;
                buttonUp.GetComponent<Button>().interactable = true;
            }
            if (buttonDown != null)
            {
                if (GetComponent<GameButton>().buttonDown.GetComponent<GameButton>().isWall == true)
                    GetComponent<GameButton>().buttonDown.GetComponent<Image>().sprite = wall;
                if (GetComponent<GameButton>().buttonDown.GetComponent<GameButton>().isFinish == true)
                    GetComponent<GameButton>().buttonDown.GetComponent<Image>().sprite = treasures;
                buttonDown.GetComponent<GameButton>().mainButton = gameObject;
                buttonDown.GetComponent<Button>().interactable = true;
            }
            if (buttonRight != null)
            {
                if (GetComponent<GameButton>().buttonRight.GetComponent<GameButton>().isWall == true)
                    GetComponent<GameButton>().buttonRight.GetComponent<Image>().sprite = wall;
                if (GetComponent<GameButton>().buttonRight.GetComponent<GameButton>().isFinish == true)
                    GetComponent<GameButton>().buttonRight.GetComponent<Image>().sprite = treasures;
                buttonRight.GetComponent<GameButton>().mainButton = gameObject;
                buttonRight.GetComponent<Button>().interactable = true;
            }
            if (buttonLeft != null)
            {
                if (GetComponent<GameButton>().buttonLeft.GetComponent<GameButton>().isWall == true)
                    GetComponent<GameButton>().buttonLeft.GetComponent<Image>().sprite = wall;
                if (GetComponent<GameButton>().buttonLeft.GetComponent<GameButton>().isFinish == true)
                    GetComponent<GameButton>().buttonLeft.GetComponent<Image>().sprite = treasures;
                buttonLeft.GetComponent<GameButton>().mainButton = gameObject;
                buttonLeft.GetComponent<Button>().interactable = true;
            }
        }
    }
    void InteractableCheck(bool isCheck)
    {
        if(!isCheck)
        {
            if (GetComponent<GameButton>().buttonUp != null)
                if (GetComponent<GameButton>().buttonUp.GetComponent<GameButton>().isMainButton == true)
                {
                    if (GetComponent<GameButton>().buttonUp.GetComponent<GameButton>().isWall == true)
                        GetComponent<GameButton>().buttonUp.GetComponent<Image>().sprite = wall;
                    if (GetComponent<GameButton>().buttonUp.GetComponent<GameButton>().isFinish == true)
                        GetComponent<GameButton>().buttonUp.GetComponent<Image>().sprite = treasures;
                    GetComponent<Button>().interactable = true;
                    return;
                }
            if (GetComponent<GameButton>().buttonDown != null)
                if (GetComponent<GameButton>().buttonDown.GetComponent<GameButton>().isMainButton == true)
                {
                    if (GetComponent<GameButton>().buttonDown.GetComponent<GameButton>().isWall == true)
                        GetComponent<GameButton>().buttonDown.GetComponent<Image>().sprite = wall;
                    if (GetComponent<GameButton>().buttonDown.GetComponent<GameButton>().isFinish == true)
                        GetComponent<GameButton>().buttonDown.GetComponent<Image>().sprite = treasures;
                    GetComponent<Button>().interactable = true;
                    return;
                }
            if (GetComponent<GameButton>().buttonRight != null)
                if (GetComponent<GameButton>().buttonRight.GetComponent<GameButton>().isMainButton == true)
                {
                    if (GetComponent<GameButton>().buttonRight.GetComponent<GameButton>().isWall == true)
                        GetComponent<GameButton>().buttonRight.GetComponent<Image>().sprite = wall;
                    if (GetComponent<GameButton>().buttonRight.GetComponent<GameButton>().isFinish == true)
                        GetComponent<GameButton>().buttonRight.GetComponent<Image>().sprite = treasures;
                    GetComponent<Button>().interactable = true;
                    return;
                }
            if (GetComponent<GameButton>().buttonLeft != null)
                if (GetComponent<GameButton>().buttonLeft.GetComponent<GameButton>().isMainButton == true)
                {
                    if (GetComponent<GameButton>().buttonLeft.GetComponent<GameButton>().isWall == true)
                        GetComponent<GameButton>().buttonLeft.GetComponent<Image>().sprite = wall;
                    if (GetComponent<GameButton>().buttonLeft.GetComponent<GameButton>().isFinish == true)
                        GetComponent<GameButton>().buttonLeft.GetComponent<Image>().sprite = treasures;
                    GetComponent<Button>().interactable = true;
                    return;
                }

            GetComponent<Button>().interactable = false;
            GetComponent<Image>().sprite = way;

            if(tag == "MainButton")
                GetComponent<Image>().sprite = indi;
            isCheck = true;
        }
    }


    public void Move()
    {
        if (tag == "WayButton")
            MoveNewGameButton();

        if (tag == "FinishButton")
        {
            List<GameObject> buttons = transform.parent.gameObject.GetComponent<MapGenerator>().buttons;

            for (int i = 0; i < buttons.Count; i++)
                buttons[i].GetComponent<Image>().enabled = false;

            transform.parent.gameObject.GetComponent<MapGenerator>().message.gameObject.SetActive(true);

                SceneManager.LoadScene("SampleScene");
        }
    }
    void MoveNewGameButton()
    {
        mainButton.tag = "WayButton";
        mainButton.GetComponent<Image>().sprite = way;
        mainButton.GetComponent<GameButton>().isMainButton = false;

        GetComponent<GameButton>().isMainButton = true;
        GetComponent<Image>().sprite = indi;
        AssignMainButton();
        tag = "MainButton";
    }
}
