using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomEventManager : MonoBehaviour
{
    public Text minorEventText;
    public GameObject minorEventPanel;
    private Animator minorEventAnimator;



    public static RandomEventManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private static RandomEventManager _instance;
    private RandomEvent[] minorEvents = {
        new RandomEvent("Argue I", "{0} and {1} had a minor argument.", "{0} and {1} nearly had an argument.", CharacterGroup.Humans, CharacterGroup.Humans, null, null, 
            new Comparison(1, "mood", '<', 0, ConstantsManager.kArgueThreshold),new Comparison(2, "mood", '<', 0, ConstantsManager.kArgueThreshold), 
            new StatEffect[]{new StatEffect(StatEffect.WhoEffect.Char1, "mood",-ConstantsManager.kSmallInterval), new StatEffect(StatEffect.WhoEffect.Char2, "mood", -ConstantsManager.kSmallInterval)},
            new StatEffect[]{new StatEffect(StatEffect.WhoEffect.Char1, "mood",0), new StatEffect(StatEffect.WhoEffect.Char2, "mood", 0)}),
        new RandomEvent("Argue II", "{0} and {1} had a disagreement.", "{0} and {1} agreed to disagree.", CharacterGroup.Humans, CharacterGroup.Humans, null, null,
            new Comparison(1, "mood", '<', 0, ConstantsManager.kArgueThreshold),new Comparison(2, "mood", '<', 0, ConstantsManager.kArgueThreshold),
            new StatEffect[]{new StatEffect(StatEffect.WhoEffect.Char1, "mood",-ConstantsManager.kSmallInterval), new StatEffect(StatEffect.WhoEffect.Char2, "mood", -ConstantsManager.kSmallInterval)},
            new StatEffect[]{new StatEffect(StatEffect.WhoEffect.Char1, "mood",0), new StatEffect(StatEffect.WhoEffect.Char2, "mood", 0)}),
        new RandomEvent("Argue III", "{0} and {1} argued over something silly.", "{0} and {1} nearly argued over something silly.", CharacterGroup.Humans, CharacterGroup.Humans, null, null,
            new Comparison(1, "mood", '<', 0, ConstantsManager.kArgueThreshold),new Comparison(2, "mood", '<', 0, ConstantsManager.kArgueThreshold),
            new StatEffect[]{new StatEffect(StatEffect.WhoEffect.Char1, "mood",-ConstantsManager.kSmallInterval), new StatEffect(StatEffect.WhoEffect.Char2, "mood", -ConstantsManager.kSmallInterval)},
            new StatEffect[]{new StatEffect(StatEffect.WhoEffect.Char1, "mood",0), new StatEffect(StatEffect.WhoEffect.Char2, "mood", 0)}),
        new RandomEvent("Slap", "During a fight,{0} slapped {1}.", "{0} had to leave the room to avoid fighting {1}.", CharacterGroup.Female, CharacterGroup.Humans, null, null,
            new Comparison(1, "mood", '<', 0, ConstantsManager.kFightThreshold),new Comparison(2, "mood", '<', 0, ConstantsManager.kArgueThreshold),
            new StatEffect[]{new StatEffect(StatEffect.WhoEffect.Char1, "mood",-ConstantsManager.kMediumInterval), new StatEffect(StatEffect.WhoEffect.Char2, "mood", -ConstantsManager.kMediumInterval), new StatEffect(StatEffect.WhoEffect.Char2, "relationship", -ConstantsManager.kMediumInterval)},
            new StatEffect[]{new StatEffect(StatEffect.WhoEffect.Char1, "mood",-ConstantsManager.kSmallInterval), new StatEffect(StatEffect.WhoEffect.Char1, "relationship",ConstantsManager.kMediumInterval)}),
        new RandomEvent("Puppy", "{0} successfully got scritches from {1}.", "{0} unsuccessfully begged {1} for scritches.", CharacterGroup.Pet, CharacterGroup.Humans, null, null,
            new Comparison(1, "mood", '>', 0,0),new Comparison(2, "mood", '<', 0, ConstantsManager.kFightThreshold),
            new StatEffect[]{new StatEffect(StatEffect.WhoEffect.Char1, "mood",ConstantsManager.kMediumInterval), new StatEffect(StatEffect.WhoEffect.Char2, "mood", ConstantsManager.kMediumInterval)},
            new StatEffect[]{new StatEffect(StatEffect.WhoEffect.Char1, "mood",ConstantsManager.kSmallInterval), new StatEffect(StatEffect.WhoEffect.Char2, "mood",ConstantsManager.kSmallInterval)}),
        //new RandomEvent("Accident", "{0} slipped and fell.","{0} nearly tripped on the stairs.", CharacterGroup.Humans, CharacterGroup.None, null, null,
        //    new Comparison(1, "mood", '>', 0,0),new Comparison(2, "mood", '<', 0, ConstantsManager.kFightThreshold),
        //    new StatEffect[]{ },
        //    new StatEffect[]{ })
         new RandomEvent("Snoop", "{0} caught {1} going through their things.", "{0}'s things seem to have been disturbed. {1} saw nothing. ", CharacterGroup.Humans, CharacterGroup.All, null, null,
            new Comparison(1, "mood", '>', 0,0),new Comparison(2, "mood", '<', 0, ConstantsManager.kFightThreshold),
            new StatEffect[]{new StatEffect(StatEffect.WhoEffect.Char1, "mood",-ConstantsManager.kSmallInterval), new StatEffect(StatEffect.WhoEffect.Char2, "relationship", -ConstantsManager.kSmallInterval)},
            new StatEffect[]{ }),
         new RandomEvent("Snoop II", "{0} caught {1} snooping on their phone.", "{1} found {0}'s phone on the table", CharacterGroup.Humans, CharacterGroup.Humans, null, null,
            new Comparison(1, "mood", '>', 0,0),new Comparison(2, "mood", '<', 0, ConstantsManager.kFightThreshold),
            new StatEffect[]{new StatEffect(StatEffect.WhoEffect.Char1, "mood",-ConstantsManager.kSmallInterval), new StatEffect(StatEffect.WhoEffect.Char2, "relationship", -ConstantsManager.kSmallInterval)},
            new StatEffect[]{ }),
         new RandomEvent("Chores", "{0} refused to help {1} with cleaning.", "{0} helped {1} clean up.", CharacterGroup.Humans, CharacterGroup.Humans, null, null,
            new Comparison(1, "mood", '>', 0,0),new Comparison(2, "mood", '<', 0, ConstantsManager.kFightThreshold),
            new StatEffect[]{new StatEffect(StatEffect.WhoEffect.Char1, "mood",-ConstantsManager.kSmallInterval), new StatEffect(StatEffect.WhoEffect.Char2, "relationship", -ConstantsManager.kSmallInterval)},
            new StatEffect[]{ }),
            new RandomEvent("Joke","{0} and {1} shared a joke. ", "{1} thoughth {0} was laughing at them.", CharacterGroup.Humans, CharacterGroup.Humans, null, null,
            new Comparison(1, "mood", '>', 0,0),new Comparison(2, "mood", '<', 0, ConstantsManager.kFightThreshold),
            new StatEffect[]{new StatEffect(StatEffect.WhoEffect.Char1, "mood",ConstantsManager.kSmallInterval), new StatEffect(StatEffect.WhoEffect.Char2, "relationship", ConstantsManager.kSmallInterval)},
            new StatEffect[]{new StatEffect(StatEffect.WhoEffect.Char1, "mood",-ConstantsManager.kSmallInterval), new StatEffect(StatEffect.WhoEffect.Char2, "relationship", -ConstantsManager.kSmallInterval)}),
         new RandomEvent("Steal Food I", "{0} at {1}'s breakfast.", "{0} nearly ate {1}'s breakfast", CharacterGroup.Humans, CharacterGroup.Humans, null, TimeOfDay.Morning,
            new Comparison(1, "mood", '>', 0,0),new Comparison(2, "mood", '<', 0, ConstantsManager.kFightThreshold),
            new StatEffect[]{new StatEffect(StatEffect.WhoEffect.Char1, "mood",-ConstantsManager.kSmallInterval), new StatEffect(StatEffect.WhoEffect.Char2, "relationship", -ConstantsManager.kSmallInterval)},
            new StatEffect[]{ })

    };
    private string[] majorEvents = {
        "ArgumentAtTheTable","Date","GameGem","NightRob","PipeBurst","ElectricBill","SisterRobot","PoorSleep"
    };
    // Start is called before the first frame update
    void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            minorEventAnimator = minorEventPanel.GetComponent<Animator>();
        }
    }

    public void RunMinorEvent()
    {
        bool notYetSucceeded = true;
        //while (notYetSucceeded)
        //{
            notYetSucceeded = !TryRunMinorEvent();
        //}
    }

    public bool RunMajorEvent()
    {
        Debug.Log("RunMajorEvent");
        //return runEvent(majorEvents);
        //choose random major event scene to load additively
        int rand = Random.Range(0, majorEvents.Length);
        SceneManager.LoadScene(majorEvents[rand], LoadSceneMode.Additive);


        return true;
    }
    //----------------------------------------------------------------------------------------------------


    private bool TryRunMinorEvent()
    {
        Debug.Log("RunMinorEvent");
        //return runEvent(minorEvents);

        //choose event from list
        RandomEvent currentEvent = minorEvents[Random.Range(0, minorEvents.Length)];
        Debug.Log(currentEvent.mName);
        //if room requirement, see if room has valid NPC

        FamilyCharacter[] allCharacters = CharacterManager.instance.GetCharacters();
        int charsInRoom = allCharacters.Length;
        FamilyCharacter[] validCharacters;

        if (currentEvent.mRoomReq != null)
        {
            List<FamilyCharacter> validCharacterList = new List<FamilyCharacter>();
            for (int i = 0; i < allCharacters.Length; ++i)
            {
                if ((allCharacters[i].currentRoom == currentEvent.mRoomReq) && (CharacterIsInGroup(currentEvent.mCharacter1, allCharacters[i].charName)))
                {
                    validCharacterList.Add(allCharacters[i]);
                }

            }
            validCharacters = validCharacterList.ToArray();
        }
        else
        {

            List<FamilyCharacter> validCharacterList = new List<FamilyCharacter>();
            for (int i = 0; i < allCharacters.Length; ++i)
            { 
                if (CharacterIsInGroup(currentEvent.mCharacter1, allCharacters[i].charName))
                {
                    validCharacterList.Add(allCharacters[i]);
                }
            }
            validCharacters = validCharacterList.ToArray();
        }

        //choose random character from valid characters
        if (validCharacters.Length <= 0)
        {
            return false;
        }
        //Debug.Log(validCharacters.Length);
        FamilyCharacter char1 = validCharacters[Random.Range(0, validCharacters.Length)];
        FamilyCharacter char2 = null;
        if (currentEvent.mCharacter2 != CharacterGroup.None)
        {
            char2 = GetValidFamCharFromList(allCharacters, currentEvent.mCharacter2, char1.charName);
        }
        Debug.Log(char1.charName);
        if (char2) { Debug.Log(char2.charName); }
        //check comparisons
        bool passStatChecks = true;

        //apply effect
        StatEffect[] statEffectList = (passStatChecks? currentEvent.succeedEffects: currentEvent.failEffects);
        
        foreach (StatEffect stat in statEffectList)
        {
            switch (stat.who)
            {
                    case StatEffect.WhoEffect.Char1:
                        processStatEffect(char1, stat.stat, stat.delta);
                        break;
                    case StatEffect.WhoEffect.Char2:
                        processStatEffect(char2, stat.stat, stat.delta);
                        break;
                    case StatEffect.WhoEffect.Witnesses:
                        foreach (FamilyCharacter famchar in allCharacters)
                        {
                            if (famchar.currentRoom == char1.currentRoom && (famchar != char1) && (famchar!=char2))
                            {
                                processStatEffect(famchar, stat.stat, stat.delta);
                            }
                        }
                        break;
                    case StatEffect.WhoEffect.All:
                        foreach (FamilyCharacter famchar in allCharacters)
                        {
                            processStatEffect(famchar, stat.stat, stat.delta);
                        }
                        break;
                    default:
                        break;
             } 
        }

        //update UI
        printMinorEvent((passStatChecks ? currentEvent.succeedString : currentEvent.failString), (char1?char1.charName:""), (char2?char2.charName:""), statEffectList);
        //minorEventText.text = (passStatChecks ? currentEvent.succeedString : currentEvent.failString);

        return true;
    }

    private void processStatEffect(FamilyCharacter character, string stat, int delta)
    {
        if (stat == "mood")
        {
            character.mood += delta;
        }else if (stat == "relationship")
        {
            character.relationship += delta;
        }else if (stat == "loyalty")
        {
            character.loyalty += delta;
        }
    }

    private void printMinorEvent(string mainText, string char1Name, string char2Name, StatEffect[] statEffects)
    {
        string str = mainText.Replace("{0}", char1Name).Replace("{1}", char2Name);
        str += "\n";
        for (int i= 0; i < statEffects.Length; ++i)
        {
            str += "     ";
            switch (statEffects[i].who)
            {
                case StatEffect.WhoEffect.Char1:
                    str += char1Name + " ";
                    break;
                case StatEffect.WhoEffect.Char2:
                    str += char2Name + " ";
                    break;
                case StatEffect.WhoEffect.Witnesses:
                    str += "Witnesses ";
                    break;
                case StatEffect.WhoEffect.All:
                    str += "Everyone ";
                    break;
                default:
                    break;
            }
            str += statEffects[i].stat + " " + statEffects[i].delta + "\n";
    

        }
        minorEventText.text = str;
        minorEventAnimator.SetTrigger("mTrigger");

    }

    private string getEffectDescription(StatEffect stat)
    {
        string rtn = "";
        return rtn;
    }

    private bool CheckComparison(Comparison comp, FamilyCharacter char1, FamilyCharacter char2)
    {
        bool rtn = false;
        switch (comp.op)
        {
            case '>':
                break;
            case '<':
                break;
            case '=':
                break;
            default:
                break;
        }
        return rtn;
    }

    //private bool runEvent(RandomEvent[] eventsList)
    //{
    //    //choose event from list
    //    RandomEvent currentEvent = eventsList[Random.Range(0, eventsList.Length)];
    //    //if room requirement, see if it has valid NPC
    //    if (currentEvent.mRoomReq != null)
    //    {
    //        HouseRoom room;// = ?
    //        int roomNPCCount = 0;
    //        //make list of valid NPCs in room
    //        List<FamilyCharacter> validNPCs = new List<FamilyCharacter>();
    //        /*foreach (FamilyMember member in room.GetNPCs())
    //        {
    //            if CharacterIsInGroup(eventsList[chosenEventIndex].mCharacter1, member.name){
    //                validNPCs.Add(member);
    //            }
    //        }*/
    //        //if list.length==0, return false; else choose random as char1 and char2
    //        if (validNPCs.Count == 0) { return false; }
    //        else
    //        {
    //            //FamilyCharacter char1 = validNPCs[Random.Range(0, validNPCs.Count)];
    //            //FamilyCharacter char2 = GetValidFamCharFromList(room.GetNPCs(), currentEvent.mCharacter2, char1);
                
    //        }

    //    } else //if no room req, choose from valid NPCs
    //    {
    //        //FamilyCharacter char1 = GetValidFamCharFromList(GetAllNPCs(), currentEvent.mCharacter2);
    //        //FamilyCharacter char2 = GetValidFamCharFromList(GetAllNPCs(), currentEvent.mCharacter2, char1);
    //    }

    //    return true;
    //}


    private FamilyCharacter GetValidFamCharFromList(FamilyCharacter[] list, CharacterGroup group, string exclude = "")
    {
        List<FamilyCharacter> qualifiedList = new List<FamilyCharacter>();
        for (int i = 0; i < list.Length; ++i)
        {
            if (CharacterIsInGroup(group, list[i].charName) && (list[i].charName != exclude))
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
                rtn = (character == "Mother");
                break;
            case CharacterGroup.Father:
                rtn = (character == "Father");
                break;
            case CharacterGroup.Brother:
                rtn = (character == "Brother");
                break;
            case CharacterGroup.Sister:
                rtn = (character == "Sister");
                break;
            case CharacterGroup.Pet:
                rtn = (character == "Dog");
                break;
            case CharacterGroup.Humans:
                rtn = ((character == "Mother")|| (character == "Father")||(character == "Brother")||(character == "Sister"));
                break;
            case CharacterGroup.Adults:
                rtn = ((character == "Mother") || (character == "Father"));
                break;
            case CharacterGroup.Kids:
                rtn = ((character == "Brother") || (character == "Sister"));
                break;
            case CharacterGroup.Female:
                rtn = ((character == "Mother") || (character == "Sister"));
                break;
            case CharacterGroup.Male:
                rtn = ((character == "Father") || (character == "Brother"));
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


//----------------------------------------------------------------------------------------------------

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
    public TimeOfDay? mTimeReq;
    //comparisons
    public Comparison statCheck1;
    public Comparison statCheck2;
    //repeatibility - implement later
    //public bool repeatable;
    //public bool hasHappened;
    //Effects
    public StatEffect[] succeedEffects;
    public StatEffect[] failEffects;
    //---------------------------------------------------
    public RandomEvent(string n, string succeed, string fail, CharacterGroup char1, CharacterGroup char2, Room? rReq, TimeOfDay? tod, Comparison comp1, Comparison comp2, StatEffect[] succEff, StatEffect[] failEff)
    {
        mName = n; succeedString = succeed; failString = fail; mCharacter1 = char1; mCharacter2 = char2; mRoomReq = rReq; mTimeReq = tod; statCheck1 = comp1; statCheck2 = comp2; succeedEffects = succEff; failEffects = failEff;
    }



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

