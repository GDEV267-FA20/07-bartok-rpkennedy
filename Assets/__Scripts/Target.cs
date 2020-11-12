using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    SpriteRenderer rendTarget;
    SpriteRenderer rendFire;
    public Color currentColor;
    GameObject fire;
    Vector3 tarPos;
    int hit;
    int changed;

    [Header("put this in:")]
    public int speed;
    public GameObject firePrefab;

    [Header("R, G, B, or Y")]
    public string stringColor;

    void Awake()
    {
        hit = 0;
        changed = 0;

        rendTarget = GetComponent<SpriteRenderer>();

        if (stringColor == "R") rendTarget.color = Color.red;
        if (stringColor == "G") rendTarget.color = Color.green;
        if (stringColor == "B") rendTarget.color = Color.blue;
        if (stringColor == "Y") rendTarget.color = Color.yellow;

        if (firePrefab.GetComponent<SpriteRenderer>() != null)
        {
            rendFire = firePrefab.GetComponent<SpriteRenderer>();
        }
    }    

    void FixedUpdate()
    {
        if (fire != null) fire.transform.position = Vector3.MoveTowards(fire.transform.position, tarPos, 0.35f);
    }    

    public void Fire(GameObject fireTarget)
    {
        tarPos = fireTarget.transform.position;
        Debug.Log(fireTarget);
        firePrefab.transform.localScale = new Vector3(2, 2, 1);
        firePrefab.transform.position = this.transform.position;
        Debug.Log("TG: Fire");
        if (Camera.main.GetComponent<BartokAnimation>().EndCheck())
        {
            EndPrep();
            return;
        }
        fire = Instantiate(firePrefab);
        fire.GetComponent<SpriteRenderer>().color = rendTarget.color;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("enter coll");
        GameObject coll = collision.gameObject;
        if (coll == fire) return;

        hit++;

        if(rendTarget.color != coll.GetComponent<SpriteRenderer>().color)
        {
            changed++;
            rendTarget.color = coll.GetComponent<SpriteRenderer>().color;
        }        
        Destroy(coll);
    }

    void EndPrep()
    {

    }
}
