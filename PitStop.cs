using TMPro;
using UnityEngine;

public class PitStop : MonoBehaviour
{
    [SerializeField]
    TMP_Text Countdown;
    [SerializeField]
    GameObject _rootCar;
    float time = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerStay()
    {
        time = time > 4 ? 4 : time += Time.deltaTime;
        if(time > 4) 
        {
            if(time >= 4)
            {
                Countdown.text = "Ready";
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _rootCar.GetComponent<SCC_Drivetrain>().car.grassShield = true;
                time = 0;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Countdown.text = ((int)time).ToString();
        if (time >= 4)
        {
            Countdown.text = "Ready";
        }
    }
}
