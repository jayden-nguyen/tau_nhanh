using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HandScript : MonoBehaviour {
    public BoxCollider2D hand1;
    public BoxCollider2D hand2;
    public GameObject objecthand2;
    public hand1script h1script;
    public hand2script h2script;
    public Text displayText;
    public Text Score1;
    public Text Score2;
    public Text Role1;
    public Text Role2;
    public int scr1Int;
    public int scr2Int;
    public int ver = 0;
    public bool test = false;
    public int No_freehit_1 = 0;
    public bool freehit_1;
    public bool nochange_1;
    public int No_freehit_2 = 0;
    public bool freehit_2;
    public bool nochange_2;
   
    
	void Start () {
        Score1.text = "0";
        Score2.text = "0";       
    }

    // Update is called once per frame
    void Update() {
        if (No_freehit_1 == 3)
        {
            No_freehit_1 = 0;
            freehit_1 = true;
        }
        if (h1script.checkAttack == 1)
        {
            freehit_2 = false;
        }
        if (No_freehit_2 == 3)
        {
            No_freehit_2 = 0;
            freehit_2 = true;
        }
        if (h2script.checkAttack == 1)
        {
            freehit_1 = false;
        }

        // Debug.Log(freehit_1);
        
        if (ver == 0)
        {
            hand1.transform.position = new Vector3(hand1.transform.position.x,hand1.transform.position.y,91);
            hand2.transform.position = new Vector3(hand2.transform.position.x, hand2.transform.position.y,92);
            Role1.text = "ATK";
            Role2.text = "DEF";
            if (hand1.transform.position.x > hand2.transform.position.x)
            {              
                if(test == true)
                {
                    scr1Int = int.Parse(Score1.text) + 10;
                    test = false;
                }                              
                Score1.text = scr1Int.ToString();
                displayText.text = "Good";
            }
            else if (hand1.transform.position.x > 6 && hand2.transform.position.x >hand1.transform.position.x)
            {
                displayText.text = "MISS";
                ver = 1;
            }
            else
                displayText.text = "";
            if (h1script.checkAttack == 0 && h2script.checkDefend == 1)
            {

                if (nochange_2)
                {
                    No_freehit_2++;
                    nochange_2 = false;
                }
            }

        }
        if(ver == 1)
        {
            hand1.transform.position = new Vector3(hand1.transform.position.x, hand1.transform.position.y, 92);
            hand2.transform.position = new Vector3(hand2.transform.position.x, hand2.transform.position.y, 91);
            Role1.text = "DEF";
            Role2.text = "ATK";
            if (hand2.transform.position.x < hand1.transform.position.x)
            {
                if (test == true)
                {
                    scr2Int = int.Parse(Score2.text) + 10;
                    test = false;
                }
                Score2.text = scr2Int.ToString();
                displayText.text = "Good";
            }
            else if (hand2.transform.position.x < -6 && hand1.transform.position.x < hand2.transform.position.x)
            {
                displayText.text = "You Missed";
                ver = 0;
            }
            else displayText.text = "";
            if (h2script.checkAttack == 0 && h1script.checkDefend == 1)
            {

                if (nochange_1)
                {
                    No_freehit_1++;
                    nochange_1 = false;
                }
            }
        }
        Debug.Log("h1 attack la " + h1script.checkAttack + " h2 defend la " + h2script.checkDefend);

    }
}
