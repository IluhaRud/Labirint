using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button aboutUsButton;
    public Button rulesButton;
    public Button exitButton;

    public Text message;

    public void ClickPlay()
    {
        SceneManager.LoadScene("Game");
    }
    public void ClickAboutUs()
    {
        if (rulesButton.transform.GetChild(0).gameObject.GetComponent<Text>().text != "Back")
        {
            ShowMessage("This game was created by IluhaRud :)");
            return;
        }

        message.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
        aboutUsButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        rulesButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Rules";
    }
    public void ClickRules()
    {
        if(rulesButton.transform.GetChild(0).gameObject.GetComponent<Text>().text != "Back")
        {
            ShowMessage("You need to find a treasure chest to win. \n\nGood luck! ;)");
            return;
        }

        message.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
        aboutUsButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        rulesButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Rules";
    }
    public void ClickExit()
    {
        Application.Quit();
    }
    public void ShowMessage(string message)
    {
            this.message.gameObject.SetActive(true);
            this.message.text = message;
            playButton.gameObject.SetActive(false);
            aboutUsButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
            rulesButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Back";
    }
}
