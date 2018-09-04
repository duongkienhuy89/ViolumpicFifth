using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using LitJson;


public class ListRank : MonoBehaviour {


    public GameObject itemGo;
    public GameObject lstGo;
    public ScrollRect scroll;

    public GameObject wyf;
    public tk2dUIItem btnContinute;
    public InputField myName;
    public InputField myTruong;
    private string stName;
    private string stSchool;
    public tk2dUIItem btnBack;

    private string mymac = "";
    private int sumdiem = 0;
    private int level;
    private int mySecond;
    private int diemlevel = 0;
    private int mytop;
    int mYear = 0;


    public tk2dTextMesh BtxtName;
    public tk2dTextMesh BtxtLevel;
    public tk2dTextMesh BtxtDiem;
    public tk2dTextMesh BtxtTop;
    public tk2dTextMesh txtYear;
    public tk2dTextMesh txtLoading;

    string url = "http://ailatrieuphu.somee.com/Service.asmx/gettopViolympic?sha=violympic.toan&pLoai=5";
    List<UserVi> lst = new List<UserVi>();

    void btnBack_OnClick()
    {
        
        SceneManager.LoadScene("Violympic");
    }

    void btnContinute_OnClick()
    {

        try
        {
            //lay ten 
            stName = "" + myName.text;
            if (stName.Length > 40)
            {
                stName = stName.Substring(0, 39);
            }


            //lay truong
            stSchool = "" + myTruong.text;
            if (stSchool.Length > 70)
            {
                stSchool = stSchool.Substring(0, 69);
            }


            BtxtName.text = stName;
            BtxtLevel.text = "Level: " + level;          
            BtxtDiem.text = "Scores: " + diemlevel;

            stName = doHoanSau(stName, " ", "_");
            stSchool = doHoanSau(stSchool, " ", "_");

            if (!stName.Trim().Equals(""))
            {

                wyf.SetActive(false);
                myName.gameObject.SetActive(false);
                myTruong.gameObject.SetActive(false);
                scroll.gameObject.SetActive(true);
                
                

                string check = "" + getPosive(mymac, "" + level, "" + mySecond, "" + diemlevel, "" + sumdiem, stName + ")" + stSchool, "violympic.toan");
                StartCoroutine(WaitForRequestPosive(check));
                DataManager.SaveName(stName);
                DataManager.SaveSchool(stSchool);

               


            }
            else
            {
                myName.Select();
                myName.ActivateInputField();
            }
        }
        catch
        {

        }
          

     
    }

    IEnumerator WaitForRequestPosive(string checkhang)
    {
        WWW www = new WWW(checkhang);

        yield return www;
        // check for errors

        if (www.error == null)
        {



            string tmg = "" + www.text;

            mytop = int.Parse(tmg.Trim());
            if (mytop > 0)
            {
                DataManager.SaveTop(mytop);
                BtxtTop.text = "Top " + mytop;
            }
            StartCoroutine(WaitForRequest());

        }
        else
        {

            BtxtTop.text = "Not Connected";
            StartCoroutine(WaitForRequest());

        }


    }

    IEnumerator WaitForRequest()
    {
        WWW www = new WWW(url);

        yield return www;
        // check for errors

        if (www.error == null)
        {


            ParseAccessData(www.text);



        }
        else
        {
            txtLoading.GetComponent<tk2dTextMesh>().text = "Not Connected";
           
        }

    }

    void ParseAccessData(string wtxt)
    {

        try
        {


            JsonData data = JsonMapper.ToObject(wtxt);
            lst.Clear();

            for (int i = 0; i < data.Count; i++)
            {
                if (int.Parse("" + data[i]["Coin"]) > 20)
                {
                    continue;
                }
                UserVi cb = new UserVi();
                cb.Stt = "" + (i + 1);
                string nameschool = "" + data[i]["Name"];
                if (nameschool.Contains(")"))
                {
                    string[] m = nameschool.Split(')');
                    cb.Name = doHoanSau("" + m[0], "_", " ");
                    cb.School = doHoanSau("" + m[1], "_", " ");

                }
                else
                {
                    cb.Name = doHoanSau("" + data[i]["Name"], "_", " ");

                }



                cb.Level = "" + data[i]["Coin"];


                lst.Add(cb);

                if (mYear == 0)
                {
                    mYear = int.Parse("" + data[i]["Namxephang"]);
                }
            }




            doLoading();

        }
        catch
        {

        }


    }

    public void doLoading()
    {
        for (int i = 0; i < lst.Count; i++)
        {
            itemGo.transform.GetChild(0).GetComponent<Text>().text = lst[i].Name;
            itemGo.transform.GetChild(1).GetComponent<Text>().text = "Top " + (i+1);
            itemGo.transform.GetChild(2).GetComponent<Text>().text = "Level "+lst[i].Level;
            itemGo.transform.GetChild(3).GetComponent<Text>().text = lst[i].School;
            GameObject item = (GameObject)Instantiate(itemGo, lstGo.transform);
            item.transform.localScale = new Vector3(1, 1, 1);
            scroll.verticalNormalizedPosition = 1;
        }

        itemGo.transform.GetChild(0).GetComponent<Text>().text = "Top 1000";
        itemGo.transform.GetChild(1).GetComponent<Text>().text = "Balo studios";
        itemGo.transform.GetChild(2).GetComponent<Text>().text = "" + mYear;
        itemGo.transform.GetChild(3).GetComponent<Text>().text = "Violympic Second 2";
        GameObject itemk = (GameObject)Instantiate(itemGo, lstGo.transform);
        itemk.transform.localScale = new Vector3(1, 1, 1);
        scroll.verticalNormalizedPosition = 1;

        txtYear.text = "" + mYear;
    }

    public static string GetUniqueIdentifier()
    {
        System.Guid uid = System.Guid.NewGuid();
        return uid.ToString();
    }

    private string getPosive(string pMac, string pCoin, string pSecond, string pDiem, string pSum, string pName, string sha)
    {
        string urls = "http://ailatrieuphu.somee.com/Service.asmx/updateMacViolympic?pMac=" + pMac + "&pCoin=" + pCoin + "&pSecond=" + pSecond + "&pDiem=" + pDiem + "&pSum=" + pSum + "&pName=" + pName + "&pLoai=5" + "&sha=" + sha;
        return urls;
    }

	// Use this for initialization
	void Start () {

        btnBack.OnClick += btnBack_OnClick;
        btnContinute.OnClick += btnContinute_OnClick;
       
        doGetInfoData();

	}

    string doHoanSau(string pDau, string pOld, string pNew)
    {

        int i = pDau.IndexOf(pOld, 0);
        while (i >= 0 && i < pDau.Length)
        {
            pDau = pDau.Replace(pOld, pNew);
            i = pDau.IndexOf(pOld, i);
        }

        return pDau;

    }

    void doGetInfoData()
    {
        stName = DataManager.GetName();
        stSchool = DataManager.GetSchool();
        stName = doHoanSau(stName, "_", " ");
        stSchool = doHoanSau(stSchool, "_", " ");
        myName.text = stName;
        myTruong.text = stSchool;

        mySecond = DataManager.GetHightSecond();
        mymac = "" + DataManager.GetMac();
        if (mymac.Trim().Equals(""))
        {
            mymac = Config.hedieuhanh+ GetUniqueIdentifier();
            DataManager.SaveMac("" + mymac);
        }

        mytop = DataManager.GetTop();
        string stTmg = DataManager.GetHightStringCoin();
        string[] mang = stTmg.Split('+');
        level = DataManager.GetHightLevel();
        if (level >= 1)
        {
            diemlevel = int.Parse(mang[level - 1]);
        }
        for (int i = 0; i < mang.Length; i++)
        {
            sumdiem += int.Parse(mang[i]);
        }


    }

 

    // Update is called once per frame
    void Update()
    {
	
	}
}
