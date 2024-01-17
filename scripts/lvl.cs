using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lvl : MonoBehaviour
{
    [SerializeField] int lvlNum;
    [SerializeField] int cost;
    [SerializeField] bool locked;
    [SerializeField] GameObject lockImg;
    [SerializeField] Text text;
    [SerializeField] money m;
    [SerializeField] Text moneyTxt;

    //public int getCost() { return cost; }
    //public int getLvlNum() { return lvlNum; }
    //public bool isLocked() { return locked; }
    //public GameObject getLockImg() { return lockImg; }


    public void OnCkick()
    {
        if(locked && m.get() >= cost)
        {
            locked = false;
            lockImg.SetActive(false);
            text.text = "Level " + lvlNum;
            m.set(m.get() - cost);
            moneyTxt.text = m.get().ToString();
        }
        else if (!locked)
        {
            SceneManager.LoadScene(lvlNum);
        }
        else
        {
            print("no money");
        }
    }
}
