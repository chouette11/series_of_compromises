using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class towescript : MonoBehaviour
{
    public bool Hpmanage = true;
    public int towerHp = 50;
    public GameObject Hpslide;
    private Slider hpslidscript;

    // Start is called before the first frame update
    void Start()
    {
        towerHp = 50;
        hpslidscript = Hpslide.GetComponent<Slider>();
        hpslidscript.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hpmanage == false)
        {
            towerHp = towerHp - 1;
            Hpmanage = true;
            hpslidscript.value = (float)towerHp / 50;
        }
    }
}
