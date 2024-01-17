using System.Collections;
using System.Collections.Generic;
using System.Xml.Xsl;
using UnityEngine;
using UnityEngine.UI;

public class pick_up_plants : MonoBehaviour
{
    [SerializeField] Text scoreTxt;
    int score = 0;
    bool stopTime;
    [SerializeField] money m;
    [SerializeField] vagatables_value vv;
    [SerializeField]bool started = false;
    GameObject hitObj;
    [SerializeField] Button corn;
    [SerializeField] Button wheat;
    Image cornImg;
    Image wheatImg;
    [SerializeField] Text endGameDescription;

    Color selected = new Color(0.529f, 0.866f, 0.443f);
    Color deselected = new Color(0.866f, 0.776f, 0.443f);

    void changeScore(int arg)
    {
        score += arg;
        scoreTxt.text = score.ToString();
    }

    private void Start()
    {
        score = 0;
        changeScore(0);
        stopTime = false;
        cornImg = corn.GetComponent<Image>();
        wheatImg = wheat.GetComponent<Image>();

    }
    private void Awake()
    {
        vv.reset();
    }

    private enum vagatables
    {
        corn,
        wheat
    }

    vagatables mode = vagatables.wheat;

    public void cornBttnCkick()
    {
        cornImg.color = selected;
        wheatImg.color = deselected;
        mode = vagatables.corn;
    }

    public void idkBttnClick()
    {
        wheatImg.color = selected;
        cornImg.color = deselected;
        mode = vagatables.wheat;
    }

    void DestroyVagatable()
    {
        Destroy(hitObj);
    }

    private void Update()
    {
        if (stopTime && Time.timeScale > 0)
        {
            Time.timeScale -= Time.deltaTime;
        }
    }

    private void loseWindowShow()
    {
        GetComponent<lose_window>().showLoseWindow();
    }

    public void endGame(string desc)
    {
        endGameDescription.text = desc;
        stopTime = true;
        Invoke("loseWindowShow", 0.3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == mode.ToString())
        {
            hitObj = other.gameObject;
            Animator[] anims = other.GetComponentsInChildren<Animator>();
            changeScore(1);
            vv.take();
            foreach(Animator a in anims)
            {
                a.Play("picked_up");
            }
            Invoke("DestroyVagatable", 0.5f);
        }
        else if (other.gameObject.tag == "Finish")
        {
            if (started)
            {
                if (vv.getValue() == 0)
                {
                    endGame("Victory!");
                    stopTime = true;
                    m.set(m.get() + score);
                }
                else
                {
                    endGame("Not all harvest has been harvested!");
                }
            }
        }
        else if(other.gameObject.tag != "tile")
        {
            endGame("Wrong harvest basket!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            started = true;
        }
    }
}
