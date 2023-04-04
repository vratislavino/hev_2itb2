using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public static Counter instance;

    private int mush;
    private int moss;

    public TMPro.TMP_Text mushText;
    public TMPro.TMP_Text mossText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void AddMushrooms(int count) {
        mush += count;
        mushText.text = "Houba: " + mush;
    }

    public void AddMoss() {
        moss++;
        mossText.text = "Mech: " + moss;
    }
}
