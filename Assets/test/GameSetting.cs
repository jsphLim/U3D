using UnityEngine;
using System.Collections;
public enum GameGrade
{
    EASY,
    NORMAL,
    DIFFICULT
}
public enum ControllType
{
    KEY,
    MOUSE,
    TOUCH
}

public class GameSetting : MonoBehaviour {

    public float volume = 1;
    public static GameGrade gamegrade = GameGrade.NORMAL;
    public static ControllType controlltype = ControllType.KEY;

    public void OnvolumeChange()
    {
        volume = UIProgressBar.current.value;
        print(volume);
    }
    public void OnGameGradeChange()
    {
        print(UIPopupList.current.value);
    }
    public void OnScreenChange()
    {
      print(UIToggle.current.value);
    }
}
