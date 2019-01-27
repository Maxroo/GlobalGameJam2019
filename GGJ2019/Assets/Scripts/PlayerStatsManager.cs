using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
   public static PlayerStatsManager instance;
   public int mood;
   public int charisma;
   public int knowledge;
   public int energy;

   private void Awake() {
      if(instance != null){
         Destroy(this);
      }  
      instance = this;
   }

}
