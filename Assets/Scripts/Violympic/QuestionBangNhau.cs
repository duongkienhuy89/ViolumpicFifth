using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class QuestionBangNhau : MonoBehaviour {


    public SpItem spPrefab;
    public float startX;
    public float distanceX;
    public float startY;
    public float distanceY;
    private tk2dUIItem sp;
    private SpItem sp1;


    private SpItem bt1;
    private SpItem bt2;
    private SpItem bt3;
    private SpItem bt4;
    private SpItem bt5;
    private SpItem bt6;
    private SpItem bt7;
    private SpItem bt8;
    private SpItem bt9;
    private SpItem bt10;
    private SpItem bt11;
    private SpItem bt12;
    private SpItem bt13;
    private SpItem bt14;
    private SpItem bt15;
    private SpItem bt16;
    private SpItem bt17;
    private SpItem bt18;
    private SpItem bt19;
    private SpItem bt20;

    double gt1 = 0;
    double gt2 = 0;

    private tk2dSprite sprite1;
    private tk2dSprite sprite2;

    public int mDiemB1=0;
    public tk2dSprite khocCuoi;
    int mDem = 0;
    int mTime = 1200;

    int demframe = 0;
    bool checkCreate=true;



    public tk2dTextMesh txtTime;
    public tk2dTextMesh txtLoading;


    public enum State
    {
        Start,
        InGame1,
        Click1,
        Click2

    }

    public State currentState;
    public void setPlay()
    {
       
        //currentState = State.InGame1;
        StartCoroutine(WaitTimeLoadData(1.2f));
    }



    IEnumerator WaitTimeLoadData(float time)
    {
        yield return new WaitForSeconds(time);
      Create();
       
    }

    void doXuLy(SpItem bt)
    {
      
        if (currentState == State.InGame1)
        {
            sp1 = bt;
            if (sp1.Trangthai == true)
            {
                sp1.Trangthai = false;
                currentState = State.Click1;
                khocCuoi.SetSprite("khixet");
                sprite1 = bt.GetComponent<tk2dSprite>();
                sprite1.color = new Color(1, 1, 0.5f, 1);

                gt1 = bt.Giatri;
                SoundManager.Instance.PlayAudioClick();
            }

        }
        else if (currentState == State.Click1)
        {
            if (bt.Trangthai == true)
            {
                bt.Trangthai = false;
                currentState = State.Click2;

                sprite2 = bt.GetComponent<tk2dSprite>();
                sprite2.color = new Color(1, 1, 0.5f, 1);

                gt2 = bt.Giatri;
                SoundManager.Instance.PlayAudioClick();
                StartCoroutine(WaitTimeXuLyBN(1f, bt));
            }
        }
           
    }

    IEnumerator WaitTimeXuLyBN(float time, SpItem bt)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        sprite1.color = new Color(1, 1, 1, 1);
        sprite2.color = new Color(1, 1, 1, 1);


        sp1.Trangthai = true;
        bt.Trangthai = true;


        if (gt1 == gt2)
        {
            SoundManager.Instance.Stop();
            SoundManager.Instance.PlayAudioChucTrue();
  
            bt.gameObject.SetActive(false);

         
            sp1.gameObject.SetActive(false);
            mDiemB1 += 10;
            khocCuoi.SetSprite("khicuoi");
            StartCoroutine(WaitTimeDungRoiBN(0.5f));
        }
        else
        {
            mDiemB1 -= 2;
            khocCuoi.SetSprite("khikhoc");
            StartCoroutine(WaitTimeSaiRoiBN(0.5f));
        }
    }

    IEnumerator WaitTimeSaiRoiBN(float time)
    {
        yield return new WaitForSeconds(time);


        SoundManager.Instance.Stop();
        mDem++;


        int chon = UnityEngine.Random.Range(0, 6);
        switch (chon)
        {
            case 0:
                SoundManager.Instance.PlayAudioChucSai1();
                break;
            case 1:
                SoundManager.Instance.PlayAudioChucSai2();
                break;
            case 3:
                SoundManager.Instance.PlayAudioChucSai3();
                break;
            case 4:
                SoundManager.Instance.PlayAudioChucSai4();
                break;
            case 5:
                SoundManager.Instance.PlayAudioChucSai5();
                break;
            default:
                SoundManager.Instance.PlayAudioChucSai2();
                break;

        }

        currentState = State.InGame1;

        if (mDem >= 3)
        {
            GameOver();
        }

    }

    IEnumerator WaitTimeDungRoiBN(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        SoundManager.Instance.Stop();

        int chon = UnityEngine.Random.Range(0, 12);
        switch (chon)
        {
            case 0:
                SoundManager.Instance.PlayAudioChucDung1(chon);
                break;
            case 1:
                SoundManager.Instance.PlayAudioChucDung2(chon);
                break;
            case 3:
                SoundManager.Instance.PlayAudioChucDung3(chon);
                break;
            case 4:
                SoundManager.Instance.PlayAudioChucDung4(chon);
                break;
            case 5:
                SoundManager.Instance.PlayAudioChucDung5(chon);
                break;
            default:
                SoundManager.Instance.PlayAudioChucDung2(chon);
                break;

        }

        if (mDiemB1 < 91)
        {
            currentState = State.InGame1;

        }
        else
        {
            GameOver();
        }



    }

    public void GameOver()
    {
        currentState = State.Start;
        PopUpController.instance.HideQuestionBangNhau();
        if (mDiemB1 < 0)
        {
            mDiemB1 = 0;
        }
        GameController.instance.sumCoin += mDiemB1;
        GameController.instance.sumTime += mTime;
        PopUpController.instance.ShowStopBangNhau(mDiemB1, ClsThaoTac.CoverTimeToString(1200 - mTime));
        resetTL();
    }
    public void resetTL()
    {
        mTime = 1200;
       
        demframe = 0;
        mDem = 0;

        mDiemB1 = 0;
        setEmptyChild();
        khocCuoi.SetSprite("khihoi");
        txtLoading.gameObject.SetActive(true);
    }

    public void setEmptyChild()
    {
      
        foreach (Transform child in this.transform)
        {
         
            if (child.gameObject.CompareTag("nguoi"))
            {
                continue;
            }
            child.gameObject.SetActive(false);
        }


     



    }

  

    #region Singleton
    void onClick_sp1()
    {

        doXuLy(bt1);
    }

    void onClick_sp2()
    {

        doXuLy(bt2);
    }

    void onClick_sp3()
    {

        doXuLy(bt3);
    }

    void onClick_sp4()
    {

        doXuLy(bt4);
    }



    void onClick_sp5()
    {

        doXuLy(bt5);
    }

    void onClick_sp6()
    {

        doXuLy(bt6);
    }

    void onClick_sp7()
    {

        doXuLy(bt7);
    }

    void onClick_sp8()
    {

        doXuLy(bt8);
    }
    void onClick_sp9()
    {

        doXuLy(bt9);
    }
    void onClick_sp10()
    {

        doXuLy(bt10);
    }
    void onClick_sp11()
    {

        doXuLy(bt11);
    }
    void onClick_sp12()
    {

        doXuLy(bt12);
    }

    void onClick_sp13()
    {

        doXuLy(bt13);
    }

    void onClick_sp14()
    {

        doXuLy(bt14);
    }

    void onClick_sp15()
    {

        doXuLy(bt15);
    }

    void onClick_sp16()
    {

        doXuLy(bt16);
    }

    void onClick_sp17()
    {

        doXuLy(bt17);
    }

    void onClick_sp18()
    {

        doXuLy(bt18);
    }

    void onClick_sp19()
    {

        doXuLy(bt19);
    }

    void onClick_sp20()
    {

        doXuLy(bt20);
    }
    #endregion

 

    void CreateLevel(float positionX, float positionY, PhepToan vio, int thutu)
    {

        SpItem levelCreate = spPrefab.Spawn<SpItem>
            (
               new Vector3(positionX, positionY, 71),
             spPrefab.transform.rotation
            );
       
        levelCreate.Giatri = ClsThaoTac.doKetQua(vio.Ketqua);
        levelCreate.Pheptoan = "" + vio.Congthuc;
        levelCreate.setData(vio.Loai);
        levelCreate.Trangthai = true;
        //levelCreate.Vitri = thutu;
        

        sp = levelCreate.GetComponent<tk2dUIItem>();

        switch (thutu)
        {
            case 1:
                bt1 = levelCreate;
                sp.OnClick += onClick_sp1;
                break;
            case 2:
                bt2 = levelCreate;
                sp.OnClick += onClick_sp2;
                break;
            case 3:
                bt3 = levelCreate;
                sp.OnClick += onClick_sp3;
                break;
            case 4:
                bt4 = levelCreate;
                sp.OnClick += onClick_sp4;
                break;
            case 5:
                bt5 = levelCreate;
                sp.OnClick += onClick_sp5;
                break;
            case 6:
                bt6 = levelCreate;
                sp.OnClick += onClick_sp6;
                break;
            case 7:
                bt7 = levelCreate;
                sp.OnClick += onClick_sp7;
                break;
            case 8:
                bt8 = levelCreate;
                sp.OnClick += onClick_sp8;
                break;
            case 9:
                bt9 = levelCreate;
                sp.OnClick += onClick_sp9;
                break;
            case 10:
                bt10 = levelCreate;
                sp.OnClick += onClick_sp10;
                break;
            case 11:
                bt11 = levelCreate;
                sp.OnClick += onClick_sp11;
                break;
            case 12:
                bt12 = levelCreate;
                sp.OnClick += onClick_sp12;
                break;
            case 13:
                bt13 = levelCreate;
                sp.OnClick += onClick_sp13;
                break;
            case 14:
                bt14 = levelCreate;
                sp.OnClick += onClick_sp14;
                break;
            case 15:
                bt15 = levelCreate;
                sp.OnClick += onClick_sp15;
                break;
            case 16:
                bt16 = levelCreate;
                sp.OnClick += onClick_sp16;
                break;
            case 17:
                bt17 = levelCreate;
                sp.OnClick += onClick_sp17;
                break;
            case 18:
                bt18 = levelCreate;
                sp.OnClick += onClick_sp18;
                break;
            case 19:
                bt19 = levelCreate;
                sp.OnClick += onClick_sp19;
                break;
            case 20:
                bt20 = levelCreate;
                sp.OnClick += onClick_sp20;
                break;
            default:
                Debug.Log("Default case");
                break;
        }

        levelCreate.transform.parent = this.gameObject.transform;


    }

    void doPhanPhat(ref List<PhepToan> lstP, ref int vt, ref float positionX, ref float positionY)
    {
        int chon = UnityEngine.Random.Range(0, lstP.Count);




        CreateLevel(positionX, positionY, lstP[chon], vt);
        lstP.RemoveAt(chon);

        positionX += distanceX;
        if ((vt) % 4 == 0)
        {
            positionY -= distanceY;
            positionX = startX;

        }
        vt++;
    }

    public void Create()
    {
        #region Singleton

        float positionX = startX;
        float positionY = startY;
        List<PhepToan> lstTMG = new List<PhepToan>();


        chonData(ref lstTMG, GameController.instance.lstPhepToan, GameController.instance.level);
       

        #endregion

        if (checkCreate)
        {
            int vt = 1;

            for (int i = 0; i < 20; i++)
            {

                doPhanPhat(ref lstTMG, ref vt, ref positionX, ref positionY);
            }

            checkCreate = false;
        }
        else
        {
            setDataLst(ref lstTMG);
        }

        

        currentState = State.InGame1;
        txtLoading.gameObject.SetActive(false);
    }

    void setDataLst(ref List<PhepToan> lstP)
    {
        var children = new List<GameObject>();
        foreach (Transform child in this.transform)
        {
            children.Add(child.gameObject);
        }

        
        foreach (GameObject item in children)
        {

            if (item.CompareTag("nguoi"))
            {
                continue;
            }

            item.SetActive(true);

            int chon = UnityEngine.Random.Range(0, lstP.Count);

            item.GetComponent<SpItem>().Giatri = ClsThaoTac.doKetQua(lstP[chon].Ketqua);
            item.GetComponent<SpItem>().Pheptoan = "" + lstP[chon].Congthuc;
            item.GetComponent<SpItem>().setData(lstP[chon].Loai);
            item.GetComponent<SpItem>().Trangthai = true;

        lstP.RemoveAt(chon);
        }
       
    }



    void chonData(ref List<PhepToan> tmg1, List<PhepToan> lstTam, int loai)
    {

        #region Singleton

        List<PhepToan> lstRank = new List<PhepToan>();
        foreach (PhepToan item in lstTam)
        {
            if (item.Loai.Equals("" + loai))
            {
                lstRank.Add(item);
            }
        }

     

        if (loai == 5)
        {
            while (tmg1.Count < 20)
            {
                int chon = UnityEngine.Random.Range(0, lstRank.Count);

                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                        //Có trong mảng tmg1 rồi thì thoát ra
                    }
                }

                if (ok == false)
                {
                   
                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    double kqn = double.Parse(lstRank[chon].Ketqua);
                    int gtrd = UnityEngine.Random.Range(0, 8);
                    string stKq = "";


                    switch (gtrd)
                    {
                        case 0:
                            stKq = kqn + " mm";
                            break;
                        case 1:
                            stKq = (kqn / 10)+" cm";
                            break;
                        case 2:
                            stKq = (kqn / 100) + " dm";
                            break;
                        case 3:
                            stKq = (kqn / 1000000) + " km";
                            break;
                        case 4:
                            stKq = (kqn / 10000) + " dam";
                            break;
                        case 5:
                            stKq = (kqn / 100000) + " hm";
                            break;
                        default:
                            stKq = (kqn / 1000) + " m";                           
                            break;

                    }

                    PhepToan pt1 = new PhepToan(stKq, lstRank[chon].Ketqua, "number");

                    tmg1.Add(pt2);
                    tmg1.Add(pt1);

                }
            }
        }
        else
        {
            while (tmg1.Count < 20)
            {
                int chon = UnityEngine.Random.Range(0, lstRank.Count);

                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) == ClsThaoTac.doKetQua(tmg1[i].Ketqua))
                    {
                        ok = true;
                        break;
                    }
                }

                if (ok == false)
                {
                    string tambo = "" + lstRank[chon].Congthuc;
                    string tambo2 = "" + lstRank[chon].Congthuc;
                    if (tambo.Contains("c"))
                    {
                        string[] mang = tambo.Split('c');
                        if (mang[0].Contains("/") && mang[1].Contains("/"))
                        {
                            tambo = "phanhai";
                        }
                        else if (mang[0].Contains("/"))
                        {
                            tambo = "phantrai";
                        }
                        else if (mang[1].Contains("/"))
                        {
                            tambo = "phanphai";
                        }
                        else
                        {
                            tambo = "number";
                            tambo2 = mang[0] + ClsLanguage.doOf() + mang[1];
                        }
                    }
                    else if (tambo.Contains("]"))
                    {
                        if (tambo.Contains("+") || tambo.Contains("-") || tambo.Contains("x") || tambo.Contains(":"))
                        {
                            tambo = "mixhai";
                        }
                        else
                        {
                            tambo = "mix";
                        }
                    }
                    else if (tambo.Contains("/"))
                    {
                        if (tambo.Contains("+") || tambo.Contains("-") || tambo.Contains("x") || tambo.Contains(":"))
                        {
                            string[] mang = tambo.Split(new Char[] { '-', '+', 'x', ':'});
                            if (mang.Length >= 3)
                            {

                                int dem = 0;
                                for (int i = 0; i < tambo.Count(); i++)
                                {
                                    string dkm = "" + tambo[i];
                                    if (dkm.Equals("/"))
                                    {
                                        dem++;
                                    }
                                }
                                if (dem >= 2)
                                {

                                    tambo = "phansoba";
                                    
                                }
                                else
                                {
                                    tambo = "phanso";
                                }
                            }
                            else
                            {
                                if (mang[0].Contains("/") && mang[1].Contains("/"))
                                {
                                    tambo = "phansohai";
                                   
                                }
                                else if (mang[0].Contains("/"))
                                {
                                    tambo = "phansotrai";
                                }
                                else if (mang[1].Contains("/"))
                                {
                                    tambo = "phansophai";
                                }
                                else
                                {
                                    tambo = "phanso";
                                }
                            }
                        }
                        else
                        {
                            tambo = "phanso";
                        }
                    }
                    else
                    {
                        tambo = "number";
                    }


                    PhepToan pt2 = new PhepToan(tambo2, lstRank[chon].Ketqua, tambo);
                    PhepToan pt1 = ClsThaoTac.getPhepToan(lstRank[chon], ref lstRank, chon);

                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }
            }
        }
  
        #endregion


    }

    // Use this for initialization
    void Start()
    {
        txtLoading.text = ClsLanguage.doLoading();
	}
	
	// Update is called once per frame
	void Update () {

        if (currentState == State.InGame1 || currentState == State.Click1 || currentState == State.Click2)
        {
            if (demframe < 30)
            {
                demframe++;
            }
            else
            {
                mTime--;
                txtTime.text = ClsThaoTac.CoverTimeToString(mTime);
                //if (mTime <= 10)
                //{
                //    txtTime.color = new Color(1, 0, 1, 1);
                //}

                demframe = 0;
                if (mTime <= 0)
                {
                    GameOver();
                }
            }
        }

	}
}
