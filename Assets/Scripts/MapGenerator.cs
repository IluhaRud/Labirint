using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    public List<GameObject> pathButtons = new List<GameObject>();
    public List<GameObject> otherButtons = new List<GameObject>();

    public GameObject mainButton;
    public GameObject button;
    public GameObject finishButton;

    public Text message;

    public int sizeX;
    public int sizeY;

    public int steps;

    bool isCheckSize;
    bool isPathGenerate;
    bool isOtherButtonsGenerate;

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.tag == "MainButton")
            {
                buttons.Add(transform.GetChild(i).gameObject);
                button = buttons[i];
            }
            if (transform.GetChild(i).gameObject.tag == "WayButton")
                buttons.Add(transform.GetChild(i).gameObject);
            if (transform.GetChild(i).gameObject.tag == "WallButton")
                buttons.Add(transform.GetChild(i).gameObject);
        }
    }
    void Update()
    {
        CheckSize(isCheckSize);
        if (!isPathGenerate && button != null)
        {
            isPathGenerate = GenerateMainPath(isPathGenerate, mainButton);
            return;
        }
        if (isPathGenerate)
            isOtherButtonsGenerate = OtherButtonsGenerate(isOtherButtonsGenerate);
    }
    void CheckSize(bool check)
    {
        if(!isCheckSize)
        {
            GameObject _button;
            sizeX = 1;
            sizeY = 1;

            for (int i = 0; i < buttons.Count; i++)
                if (buttons[i].tag == "MainButton")
                    mainButton = buttons[i];

            _button = mainButton;

            while (_button.GetComponent<GameButton>().buttonRight != null)
            {
                _button = _button.GetComponent<GameButton>().buttonRight;
                sizeX++;
            }

            _button = mainButton;

            while (_button.GetComponent<GameButton>().buttonLeft != null)
            {
                _button = _button.GetComponent<GameButton>().buttonLeft;
                sizeX++;
            }

            _button = mainButton;

            while (_button.GetComponent<GameButton>().buttonUp != null)
            {
                _button = _button.GetComponent<GameButton>().buttonUp;
                sizeY++;
            }

            _button = mainButton;

            while (_button.GetComponent<GameButton>().buttonDown != null)
            {
                _button = _button.GetComponent<GameButton>().buttonDown;
                sizeY++;
            }

            button = mainButton;
            isCheckSize = true;
        }
    }
    bool GenerateMainPath(bool isGenerate, GameObject button)
    {
        button.GetComponent<GameButton>().isMainPath = true;
        int step = 0;
        bool isMain = false;

        for (step = 0; step < steps; step++)
        {

            if (Random.Range(0, 2) == 0)
            {
                if (button.GetComponent<GameButton>().buttonUp != null)
                    isMain = button.GetComponent<GameButton>().buttonUp.GetComponent<GameButton>().isMainButton;

                if (button.GetComponent<GameButton>().buttonUp != null && !isMain)
                {
                    button = button.GetComponent<GameButton>().buttonUp;
                    button.GetComponent<GameButton>().isMainPath = true;
                    pathButtons.Add(button);
                }
               
                isMain = false;
            }

            if (Random.Range(0, 2) == 0)
            {
                if (button.GetComponent<GameButton>().buttonDown != null)
                    isMain = button.GetComponent<GameButton>().buttonDown.GetComponent<GameButton>().isMainButton;

                if (button.GetComponent<GameButton>().buttonDown != null && !isMain)
                {
                    button = button.GetComponent<GameButton>().buttonDown;
                    button.GetComponent<GameButton>().isMainPath = true;
                    pathButtons.Add(button);
                }
               
                isMain = false;
            }

            if (Random.Range(0, 2) == 0)
            {
                if (button.GetComponent<GameButton>().buttonRight != null)
                    isMain = button.GetComponent<GameButton>().buttonRight.GetComponent<GameButton>().isMainButton;

                if (button.GetComponent<GameButton>().buttonRight != null && !isMain)
                {
                    button = button.GetComponent<GameButton>().buttonRight;
                    button.GetComponent<GameButton>().isMainPath = true;
                    pathButtons.Add(button);
                }
               
                isMain = false;
            }

            if (Random.Range(0, 2) == 0)
            {
                if (button.GetComponent<GameButton>().buttonLeft != null)
                    isMain = button.GetComponent<GameButton>().buttonLeft.GetComponent<GameButton>().isMainButton;

                if (button.GetComponent<GameButton>().buttonLeft != null && !isMain)
                {
                    button = button.GetComponent<GameButton>().buttonLeft;
                    button.GetComponent<GameButton>().isMainPath = true;
                    pathButtons.Add(button);
                }
               
                isMain = false;
            }

            Debug.Log($"{pathButtons.Count}, {step}");

            if (step == steps - 1)
            {
                finishButton = pathButtons[pathButtons.Count - 1];
                finishButton.tag = "FinishButton";
                finishButton.GetComponent<GameButton>().isFinish = true;
            }

        }
        return true;
    }
    bool OtherButtonsGenerate(bool isGenerate)
    {
       if (!isGenerate)
        {

            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].GetComponent<GameButton>().isMainPath == true)
                    continue;
                otherButtons.Add(buttons[i]);
            }

            for (int i = 0; i < otherButtons.Count; i++)
            {
                if(Random.Range(0, 3) == 0)
                {
                    otherButtons[i].GetComponent<GameButton>().isWall = true;
                    otherButtons[i].tag = "WallButton";
                }
            }
        }

       return true;
    }

}
