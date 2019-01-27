using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventManager : MonoBehaviour
{
    private RandomEvent[] minorEvents = {
        new RandomEvent(), new RandomEvent(), new RandomEvent() };
    private RandomEvent[] majorEvents = { new RandomEvent(), new RandomEvent(), new RandomEvent() };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public bool RunMinorEvent()
    {
        return runEvent(minorEvents);
    }

    public bool RunMajorEvent()
    {
        return runEvent(majorEvents);
    }
    //----------------------------------------------------------------------------------------------------

    private bool runEvent(RandomEvent[] eventsList)
    {
        //choose event from list
        RandomEvent currentEvent = eventsList[Random.Range(0, eventsList.Length)];
        //if room requirement, see if it has valid NPC
        if (currentEvent.mRoomReq != null)
        {
            HouseRoom room;// = ?
            int roomNPCCount = 0;
            //make list of valid NPCs in room
            List<FamilyCharacter> validNPCs = new List<FamilyCharacter>();
            /*foreach (FamilyMember member in room.GetNPCs())
            {
                if CharacterIsInGroup(eventsList[chosenEventIndex].mCharacter1, member.name){
                    validNPCs.Add(member);
                }
            }*/
            //if list.length==0, return false; else choose random as char1 and char2
            if (validNPCs.Count == 0) { return false; }
            else
            {
                //FamilyCharacter char1 = validNPCs[Random.Range(0, validNPCs.Count)];
                //FamilyCharacter char2 = GetValidFamCharFromList(room.GetNPCs(), currentEvent.mCharacter2, char1);
                
            }

        } else //if no room req, choose from valid NPCs
        {
            //FamilyCharacter char1 = GetValidFamCharFromList(GetAllNPCs(), currentEvent.mCharacter2);
            //FamilyCharacter char2 = GetValidFamCharFromList(GetAllNPCs(), currentEvent.mCharacter2, char1);
        }

        return true;
    }


    private FamilyCharacter GetValidFamCharFromList(FamilyCharacter[] list, CharacterGroup group, string exclude = "")
    {
        List<FamilyCharacter> qualifiedList = new List<FamilyCharacter>();
        for (int i = 0; i < list.Length; ++i)
        {
            if (CharacterIsInGroup(group, list[i].name) && (list[i].name != exclude))
            {
                qualifiedList.Add(list[i]);
            }
        }
        if (qualifiedList.Count == 0)
        {
            return null;
        }
        else
        {
            return qualifiedList[Random.Range(0, qualifiedList.Count)];
        }
        
    }

    private bool CharacterIsInGroup(CharacterGroup group, string character)
    {
        bool rtn = false;
        switch (group)
        {
            case CharacterGroup.None:
                rtn = true;
                break;
            case CharacterGroup.Mother:
                rtn = (character == "mother");
                break;
            case CharacterGroup.Father:
                rtn = (character == "father");
                break;
            case CharacterGroup.Brother:
                rtn = (character == "brother");
                break;
            case CharacterGroup.Sister:
                rtn = (character == "sister");
                break;
            case CharacterGroup.Pet:
                rtn = (character == "pet");
                break;
            case CharacterGroup.Humans:
                rtn = ((character == "mother")|| (character == "father")||(character == "brother")||(character == "sister"));
                break;
            case CharacterGroup.Adults:
                rtn = ((character == "mother") || (character == "father"));
                break;
            case CharacterGroup.Kids:
                rtn = ((character == "brother") || (character == "sister"));
                break;
            case CharacterGroup.Female:
                rtn = ((character == "mother") || (character == "sister"));
                break;
            case CharacterGroup.Male:
                rtn = ((character == "father") || (character == "brother"));
                break;
            case CharacterGroup.Any:
                rtn = true;
                break;
            case CharacterGroup.All:
                rtn = true;
                break;
            default:
                break;
        }
        return rtn;
    }
    
}




public class RandomEvent
{
    //strings
    public string mName;
    public string succeedString;
    public string failString;
    //Requirements-----
    public CharacterGroup mCharacter1;
    public CharacterGroup mCharacter2;
    public Room? mRoomReq;
    public TimeOfDay mTimeReq;
    //comparisons
    public Comparison statCheck1;
    public Comparison statCheck2;
    //repeatibility - implement later
    //public bool repeatable;
    //public bool hasHappened;
    //Effects
    StatEffect[] succeedEffects;
    StatEffect[] failEffects;
    //---------------------------------------------------




}
//----------------------------------------------------------------------------------------------------
public class Comparison
{
    //Char1.stat + offset (op) threshold
    //eg char1.mood + (-5) > k
    public int who;
    public string stat;
    public char op;
    public int offset;
    public int threshold;
    public Comparison (int w, string st, char o, int off, int thresh)
    {
        who = w; stat = st; op = o; offset = off; threshold = thresh;
    }

}

public class StatEffect
{
    public WhoEffect who;
    public string stat;
    public int delta;
    public StatEffect(WhoEffect w, string s, int d)
    {
        who = w; stat = s; delta = d;
    }

    public enum WhoEffect { Char1, Char2, Witnesses, All};
}


public enum CharacterGroup
{
    None,
    Mother,
    Father,
    Brother,
    Sister,
    Pet,
    Humans,
    Adults,
    Kids,
    Female,
    Male,
    Any,
    All,
};

public enum Room
{
    Kitchen,
    LivingRoom,
    SunRoom,
    KidsBedroom,
    AdultsBedroom,
    GameRoom,
    Bathroom,
};

public enum DeltaSize
{
    Small,
    Medium,
    Large
};

