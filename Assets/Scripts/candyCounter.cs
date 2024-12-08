using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CandyCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI candies;
    [SerializeField] private int score = 0;

    // private void Start() {
    //     candies = GameObject.Find("candyCounter").GetComponent<Text>();
    // }

    public void AddCandy(int amount){
        score += amount;
        UpdateScoreUI();
    }
    private void UpdateScoreUI(){
        candies.text = "      X " + score;

    }
}
