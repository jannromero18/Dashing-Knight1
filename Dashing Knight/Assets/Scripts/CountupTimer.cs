using UnityEngine;
using TMPro;

//This is the script for the countup timer
public class CountupTimer : MonoBehaviour
{
    public float timeElapsed = 0;
    public TextMeshProUGUI timeText;

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        timeText.text = "Time: " + Mathf.Round(timeElapsed).ToString();
    }
}
