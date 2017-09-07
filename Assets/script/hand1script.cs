using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class hand1script : MonoBehaviour {
    public float speed;
    public float distance = 10;
    public int ver = 0;
    public HandScript hand;
	// Use this for initialization
	void Start () {       
	}
	IEnumerator Attack()
    {
        
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
        transform.position = new Vector3(-6, 0, 0);
    }
    IEnumerator defender()
    {
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
    }
    // Update is called once per frame
    void Update () {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(hand.ver == 0)
            StartCoroutine(Attack());
            if (hand.ver == 1)
                StartCoroutine(defender());
           
        }
        Debug.Log(ver);

    }
}
