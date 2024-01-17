using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu_logic : MonoBehaviour
{
    [SerializeField] GameObject menuHandler;
    [SerializeField] GameObject levelsHandler;
    [SerializeField] Text moneyTxt;
    [SerializeField] money m;
    [SerializeField] sound s;
    [SerializeField] AudioSource music;

    private void Start()
    {
        moneyTxt.text = m.get().ToString();
    }

    public void OnSoundbutton()
    {
        s.soundSwitch();
        if (s.getSound())
        {
            music.volume = 1;
        }
        else
        {
            music.volume = 0;
        }

    }

    public void OnlevelChangeBttn()
    {
        menuHandler.SetActive(false);
        levelsHandler.SetActive(true);
    }

    public void OnbackBttn() {
        menuHandler.SetActive(true);
        levelsHandler.SetActive(false);
    }

    public void OnexitBttn()
    {
        Application.Quit();
    }

}
