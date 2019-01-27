using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GameClock : MonoBehaviour
{
    public static GameClock Instance
    {
        get { return _instance; }
    }
    private static GameClock _instance;

	public Text timeText;
	public Text dayText;
    public int startTime = 8;
    public int numberOfDays = 4;

   private TimeBlock[] dayCycle = {
        new TimeBlock(8,TimeOfDay.Morning, 2),
        new TimeBlock(10, TimeOfDay.Morning, 2),
        new TimeBlock(12, TimeOfDay.Afternoon, 2),
        new TimeBlock(14, TimeOfDay.Afternoon, 2),
        new TimeBlock(16, TimeOfDay.Afternoon, 2),
        new TimeBlock(18, TimeOfDay.Evening, 2),
        new TimeBlock(20, TimeOfDay.Evening, 2),
        new TimeBlock(22, TimeOfDay.Evening, 2),
        new TimeBlock(24, TimeOfDay.Night, 8)
    };

    private TimeOfDay lastTOD = TimeOfDay.Morning;
	private int currentTimeBlock = 0;
	private int currentTime = 8;

    //--------------------------------------------------Unity Methods--------------------------------------------------
    void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            //On game 
            restartClock();
        }
        
        
    }

 
    void Update()
    {

		//if (Input.GetKeyDown (KeyCode.Space)) {
		//	GoToNextSegment ();
		//}
    }

    //--------------------------------------------------Public Methods--------------------------------------------------

    public bool GoToNextSegment() {
        //go to next segment
        currentTime += dayCycle[currentTimeBlock].Hours;
        lastTOD = dayCycle[currentTimeBlock].TOD;
        currentTimeBlock = GetNextIndexInSequence(currentTimeBlock);
        //call event if chance rolls
        if (lastTOD!= dayCycle[currentTimeBlock].TOD)
        {
            //roll for major event
            if (Random.Range(0, 100) > ConstantsManager.kChanceMajorEvent)
            {
                //major event
            }
        }
        else
        {
            if (Random.Range(0, 100) > ConstantsManager.kChanceMinorEvent)
            {
                //minor event
            }

        }

        //Update UI
        updateDisplay();
        //return if is out of time
        return (currentTime >= (numberOfDays*24));   
    }

	public string GetCurrentDayString(){
		string rtn = "Day " + (Mathf.FloorToInt(currentTime/24)+1) + " of " + numberOfDays;
//		Debug.Log (rtn);
		return rtn;
	}

    public string GetCurrentTimeString()
    {
        string rtn = "";
        bool isAM = (currentTime % 24) < 12;
        int hourOfDay = currentTime % 12;
        if (hourOfDay == 0) { hourOfDay = 12; }
        rtn += hourOfDay + ":00" + (isAM ? "am" : "pm");
        if (hourOfDay < 10) { rtn = " " + rtn; }
        return rtn;
    }
    //--------------------------------------------------Private--------------------------------------------------
    private int GetNextIndexInSequence(int i)
    {
        int rtn = i+1;
        if (rtn >= dayCycle.Length)
        {
            rtn = 0;
        }
        return rtn;
    }

    private void restartClock()
    {
        currentTime = startTime;
        SetCurrentTimeBlock();
        updateDisplay();
        
        Debug.Log("Clock restarted: " + GetCurrentTimeString());
    }

    private void updateDisplay()
    {
        timeText.text = GetCurrentTimeString();
        dayText.text = GetCurrentDayString();
    }

    private void SetCurrentTimeBlock()
    {
        int timeFound = -1;
        int tempTime = currentTime % 24;
        for (int i = 0; i < dayCycle.Length; ++i)
        {
            if (dayCycle[i].time == tempTime)
            {
                timeFound = i;
                break;
            }
        }
        if (timeFound == -1)
        {
            Debug.Log("Time does not exist");
            timeFound = 0;
        }
        currentTimeBlock = timeFound;

    }

}
public class TimeBlock
{
    public int time = 0;
    public int Hours = 2;
    public TimeOfDay TOD = TimeOfDay.Morning;
    public TimeBlock(int t, TimeOfDay tod, int hrs) { TOD = tod; time = t; Hours = hrs; }
}

public enum TimeOfDay { Morning, Afternoon, Evening, Night};

