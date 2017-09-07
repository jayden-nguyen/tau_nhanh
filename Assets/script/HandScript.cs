using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HandScript : MonoBehaviour {
    public BoxCollider2D hand1;
    public BoxCollider2D hand2;
    public Text displayText;
    public Text Score1;
    public Text Score2;
    public Text Role1;
    public Text Role2;
    public int scr1Int;
    public int scr2Int;
    public int ver = 0;
	void Start () {
        Score1.text = "0";
        Score2.text = "0";
    }
    IEnumerator Waitseconds()
    {
        yield return new WaitForSeconds(1f);
    }
	
	// Update is called once per frame
	void Update () {
        if(ver == 0)
        {
            Role1.text = "ATK";
            Role2.text = "DEF";
            if (hand1.transform.position.x > hand2.transform.position.x)
            {
                scr1Int = int.Parse(Score1.text) + 5;
                Score1.text = scr1Int.ToString();
                displayText.text = "Good";
                StartCoroutine(Waitseconds());
            }
            else if (hand1.transform.position.x > 6 && hand2.transform.position.x >hand1.transform.position.x)
            {
                ver = 1;
            }
            else
                displayText.text = "";
        }
        if(ver == 1)
        {
            Role1.text = "DEF";
            Role2.text = "ATK";
            if (hand2.transform.position.x < hand1.transform.position.x)
            {
                scr2Int = int.Parse(Score2.text) + 5;
                Score2.text = scr2Int.ToString();
                displayText.text = "Good";
            }
            else if (hand2.transform.position.x < -6 && hand1.transform.position.x < hand2.transform.position.x)
            {
                ver = 0;
            }
            else displayText.text = "";
            Debug.Log(ver);
        }

    }
}
