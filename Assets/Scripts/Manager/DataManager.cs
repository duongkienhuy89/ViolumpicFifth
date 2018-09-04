using UnityEngine;
using System.Collections;

public class DataManager  {

    private static string TAG_HIGHTLEVEL = "lvf";
    private static string TAG_HIGHTCOIN = "scf";
    private static string TAG_HIGHTSECOND = "ssf";
    private static string TAG_HIGHTNAME = "mynamef";
    private static string TAG_HIGHTSCHOOL = "schoolf";
    private static string TAG_MAC = "mymacf";
    private static string TAG_TOP = "mytopf";


    private static string TAG_VIP = "vipprof";


    public static int GetVip()
    {
        if (PlayerPrefs.HasKey(TAG_VIP))
        {
            return PlayerPrefs.GetInt(TAG_VIP);
        }
        else
        {
            return 0;
        }
    }

    public static void SaveVip(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_VIP, newHightScore);
    }



    public static string GetMac()
    {
        if (PlayerPrefs.HasKey(TAG_MAC))
        {
            return PlayerPrefs.GetString(TAG_MAC);
        }
        else
        {
            return "";
        }
    }

    public static void SaveMac(string newHightScore)
    {
        PlayerPrefs.SetString(TAG_MAC, newHightScore);
    }


    public static int GetTop()
    {
        if (PlayerPrefs.HasKey(TAG_TOP))
        {
            return PlayerPrefs.GetInt(TAG_TOP);
        }
        else
        {
            return 0;
        }
    }

    public static void SaveTop(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_TOP, newHightScore);
    }


    //Lay ra truong tieu hoc cua nguoi choi

    public static string GetSchool()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTSCHOOL))
        {
            return PlayerPrefs.GetString(TAG_HIGHTSCHOOL);
        }
        else
        {
            return "";
        }
    }

    //luu lai truong tieu hoc cua nguoi choi
    public static void SaveSchool(string newHightScore)
    {
        PlayerPrefs.SetString(TAG_HIGHTSCHOOL, newHightScore);
    }




    //Lay ra ten cua nguoi choi

    public static string GetName()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTNAME))
        {
            return PlayerPrefs.GetString(TAG_HIGHTNAME);
        }
        else
        {
            return "";
        }
    }

    //luu lai ten cua nguoi choi
    public static void SaveName(string newHightScore)
    {
        PlayerPrefs.SetString(TAG_HIGHTNAME, newHightScore);
    }











    //lay lai gia tri level da vuot qua.
    public static int GetHightLevel()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTLEVEL))
        {
            return PlayerPrefs.GetInt(TAG_HIGHTLEVEL);
        }
        else
        {
            return 0;
        }
    }

    //luu lai gia tri level da vuot qua.
    public static void SaveHightLevel(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_HIGHTLEVEL, newHightScore);
    }


    //lay lai gia tri chuoi diem tung level da vuot qua.

    public static string GetHightStringCoin()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTCOIN))
        {
            return PlayerPrefs.GetString(TAG_HIGHTCOIN);
        }
        else
        {
            return "1+2+3+4+5+6+7+8+9+10+11+12+13+14+15+16+17+18+19+20";
        }
    }

    //luu lai gia tri chuoi diem tung level da vuot qua.
    public static void SaveHightStringCoin(string newHightScore)
    {
        PlayerPrefs.SetString(TAG_HIGHTCOIN, newHightScore);
    }

    //get lai gia tri second cua bai 3 khi con thong thai.

    public static int GetHightSecond()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTSECOND))
        {
            return PlayerPrefs.GetInt(TAG_HIGHTSECOND);
        }
        else
        {
            return 0;
        }
    }

    //Luu lai gia tri second cua bai 3 khi con thong thai.
    public static void SaveHightSecond(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_HIGHTSECOND, newHightScore);
    }
}
