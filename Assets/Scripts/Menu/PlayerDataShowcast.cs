using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDataShowcast : MonoBehaviour
{
    [SerializeField]private Text Score=null;
    [SerializeField]private Text Time=null;
    [SerializeField]private Text Name=null;

    public void SetTexts(int score, int time, string name)
    {
        Score.text = score.ToString();
        Time.text = time.ToString();

        if(name==null || name==string.Empty){
            name = "----";
        }
        Name.text = name;
    }
}
