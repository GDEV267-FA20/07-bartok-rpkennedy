using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartokAnimation : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject currTarget;
    int turn;
    public bool end;

    private void Awake()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");
        currTarget = targets[turn];
        end = false;
    }
    void Start()
    {
        Invoke("Prefire", 1f);
        Debug.Log("BA: Start");
    }

    void Prefire()
    {
        Debug.Log("BA: Prefire");
        GameObject temp = RandomSelect();
        currTarget.GetComponent<Target>().Fire(temp);
        currTarget = RandomSelect();

        if(!EndCheck()) Invoke("Prefire", 2.2f);
    }

    GameObject RandomSelect()
    {
        GameObject tar;
        tar = currTarget;

        while(tar == currTarget)                                    //keep changing until it deviates from current
        {
            tar = targets[(int)Random.Range(0, targets.Length)];     //set random target
        }

        return tar;        
    }

    public bool EndCheck()
    {
        if (targets[0].GetComponent<SpriteRenderer>().color == targets[1].GetComponent<SpriteRenderer>().color &&
            targets[0].GetComponent<SpriteRenderer>().color == targets[2].GetComponent<SpriteRenderer>().color &&
            targets[0].GetComponent<SpriteRenderer>().color == targets[3].GetComponent<SpriteRenderer>().color) return true;
        return false;
    }
}
