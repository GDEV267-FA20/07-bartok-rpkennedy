using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastCardhuman : MonoBehaviour
{
    public Button button;
    public Player whomst;
    bool hasFired;

    void Start()
    {
        hasFired = false;
        button = this.gameObject.GetComponent<Button>();
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
        //if (Bartok.S.firstOne) Adios();
        if (button.onClick != null)
        {
            if (hasFired) return;
            hasFired = true;
            Bartok.S.FirstCome(whomst.playerNum);
        }
    }

    public void Adios()
    {
        Destroy(this.gameObject);
    }
}
