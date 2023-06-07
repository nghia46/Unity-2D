using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class updateScore : MonoBehaviour
{
    [SerializeField] int Score;
    [SerializeField] TextMeshProUGUI scoreTXT;
    void Start()
    {

    }
    public void updatedScore()
    {
        Score += 1;
    }
    // Update is called once per frame
    void Update()
    {
        this.scoreTXT.text = "<color=red>Score:"+"<color=white>"+Score.ToString();
    }
}
