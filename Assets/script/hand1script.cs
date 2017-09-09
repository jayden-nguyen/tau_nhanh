using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class hand1script : MonoBehaviour {
    public float speed;
    public float distance = 10;
    public int ver = 0;
    public HandScript hand;
    public BoxCollider2D hand2;
    public int checkDefend;
    public int checkAttack;
    public Image handcuff1;
    // Use this for initialization
    void Start () {       
	}
    // Attack Move
	IEnumerator Attack()
    {
        checkAttack = 1;
        checkDefend = 0;
        hand.test = true;
        float distanceMoved = 0.0f;        
        while (distanceMoved < distance)
        {
            transform.position = new Vector3(
                transform.position.x + speed * 0.02f,
                transform.position.y,
                transform.position.z
                );                      
            distanceMoved += speed * 0.02f;           
            yield return null;
        }
        yield return new WaitForSeconds(Time.deltaTime/3);
        if (transform.position.x >= hand2.transform.position.x)
        {
            yield return new WaitForSeconds(1f);
        }         
        transform.position = new Vector3(-6, 0, 0);
        checkAttack = 0;
    }
    // Defend move 
    IEnumerator Defend()
    {
        hand.nochange_1 = true;
        checkAttack = 0;
        checkDefend = 1;
        float distanceMoved = 0.0f;
        while (distanceMoved < distance)
        {
            transform.position = new Vector3(
                transform.position.x - speed * 0.02f,
                transform.position.y,
                transform.position.z
                );
            distanceMoved += speed * 0.02f;
            yield return null;
        }
        yield return new WaitForSeconds(Time.deltaTime / 3);
        transform.position = new Vector3(-6, 0, 0);
        checkDefend = 0;
    }
    IEnumerator handCuff()
    {
        yield return new WaitForSeconds(0.25f);
        handcuff1.gameObject.SetActive(true);

    }
    // Update is called once per frame
    void Update () {
        if (hand.freehit_1)
            StartCoroutine(handCuff());
        else
            handcuff1.gameObject.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(hand.ver == 0)
                StartCoroutine(Attack());
            if(hand.ver == 1)
            {
                if(hand.freehit_1 == false)
                    StartCoroutine(Defend());
            }
                          
        }
    }
}
