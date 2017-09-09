using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class hand2script : MonoBehaviour
{
    public float speed;
    public float distance = 10;
    public HandScript hand;
    public BoxCollider2D hand1;
    public int checkDefend;
    public int checkAttack;
    public Image handcuff2;
    // Use this for initialization
    void Start()
    {

    }
    
    IEnumerator Attack()
    {
        checkAttack = 1;
        checkDefend = 0;
        hand.test = true;
        int count = 0;
        float distanceMoved = 0.0f;
        while (distanceMoved < distance)
        {
            transform.position = new Vector3(
                transform.position.x - speed * 0.02f,
                transform.position.y,
                transform.position.z
                );
            count++;
            distanceMoved += speed * 0.02f;
            yield return null;
        }
        yield return new WaitForSeconds(Time.deltaTime / 3);
        if (transform.position.x <= hand1.transform.position.x)
        {
            yield return new WaitForSeconds(1f);
        }
        transform.position = new Vector3(6, 0, 0);
        checkAttack = 0;
    }
    IEnumerator Defend()
    {
        hand.nochange_2 = true;
        checkAttack = 0;
        checkDefend = 1;
        int count = 0;
        float distanceMoved = 0.0f;
        while (distanceMoved < distance)
        {
            transform.position = new Vector3(
                transform.position.x + speed * 0.02f,
                transform.position.y,
                transform.position.z
                );
            count++;
            distanceMoved += speed * 0.02f;
            yield return null;
        }
        yield return new WaitForSeconds(Time.deltaTime / 3);
        transform.position = new Vector3(6, 0, 0);
        Debug.Log("no Freehit 1 la : " + hand.No_freehit_1 + "  trang thai freehit 1 la " + hand.freehit_1);
        Debug.Log("no freehit2 la : " + hand.No_freehit_2 + " trang thai freehit 2 la " + hand.freehit_2);
        checkDefend = 0;
    }
    IEnumerator handCuff()
    {
        yield return new WaitForSeconds(0.25f);
        handcuff2.gameObject.SetActive(true);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (hand.freehit_2)
        {
            StartCoroutine(handCuff());
        }
        else
            handcuff2.gameObject.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (hand.ver == 0)
            {
                if(hand.freehit_2 == false)
                    StartCoroutine(Defend());
            }
                
            if (hand.ver == 1)
                StartCoroutine(Attack());
        }
    }
}
