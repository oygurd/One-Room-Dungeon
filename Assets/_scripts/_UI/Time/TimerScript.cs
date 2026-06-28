using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{
    [SerializeField] private float time;
    public TMP_Text timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timerText.text = time.ToString("F1");
        
    }
}
