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
        Bartok.S.phase = TurnPhase.lastCard;
    }

    Player Whomstdve()
    {
        if (this.transform.localPosition.y < 0) return Bartok.S.players[0];
        if (this.transform.localPosition.x < 0) return Bartok.S.players[1];
        if (this.transform.localPosition.y > 0) return Bartok.S.players[2];
        if (this.transform.localPosition.x > 0) return Bartok.S.players[3];
        return null;
    }

    void Update()
    {
        if (Input.GetKeyDown("space")) Bartok.S.FirstCome(whomst.playerNum);
    }

        //if (Bartok.S.firstOne) Adios();
        

    public void Adios()
    {
        Destroy(this.gameObject);
    }
}
