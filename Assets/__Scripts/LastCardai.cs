using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastCardai : MonoBehaviour
{
    public Slider slider;
    public Player whomst;
    public bool hasFired;

    void Start()
    {
        hasFired = false;
        slider = this.gameObject.GetComponent<Slider>();
        slider.maxValue = Random.Range(3.5f, 5f);
        slider.value = 0;
        whomst = Whomstdve();
        Debug.Log(whomst.playerNum);
    }

    Player Whomstdve()
    {
        if (this.transform.localPosition.y < 0) return Bartok.S.players[0];
        if (this.transform.localPosition.x < 0) return Bartok.S.players[1];
        if (this.transform.localPosition.y > 0) return Bartok.S.players[2];
        if (this.transform.localPosition.x > 0) return Bartok.S.players[3];
        return null;
    }

    void FixedUpdate()
    {
        slider.value += Time.deltaTime;
        //if (Bartok.S.firstOne) Adios();
        if (slider.value == slider.maxValue)
        {
            if (hasFired) return;
            hasFired = true;
            Bartok.S.FirstCome(whomst.playerNum);
        }
    }
}
