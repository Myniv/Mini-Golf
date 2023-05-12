using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour 
{
    public static List<bool> levelList = new List<bool>(5){
        false,
        false,
        false,
        false,
        false
    };


    public void LevelComplete(int level, bool complete=false){
        levelList[level-=1]=complete;
    }
    
    
}
