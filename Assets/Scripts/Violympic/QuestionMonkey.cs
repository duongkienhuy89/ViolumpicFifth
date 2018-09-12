using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class QuestionMonkey : MonoBehaviour
{


    public SpItemMonkey spPrefab;
    public float startX;
    public float distanceX;

    public float startY;
    public tk2dSprite ConKhi;

    private SpItemMonkey bt1;
    private SpItemMonkey bt2;
    private SpItemMonkey bt3;
    private SpItemMonkey bt4;
    private SpItemMonkey bt5;
    private SpItemMonkey bt6;
    private SpItemMonkey bt7;
    private SpItemMonkey bt8;
    private SpItemMonkey bt9;
    private SpItemMonkey bt10;
    private SpItemMonkey bt11;
    private SpItemMonkey bt12;
    private SpItemMonkey bt13;
    private SpItemMonkey bt14;
    private SpItemMonkey bt15;
    private SpItemMonkey bt16;
    private SpItemMonkey bt17;
    private SpItemMonkey bt18;
    private SpItemMonkey bt19;
    private SpItemMonkey bt20;

    public GameObject respawn;

    public GameObject XuLy;
    private tk2dUIItem sp;

    public float KhoangCach;
    int buoc = 1;
    private float positionStartX;
    public tk2dUIItem btnNext;
    private SpItemMonkey BangSoSanh;
    private SpItemMonkey BangKq;

    List<SpItemMonkey> children = new List<SpItemMonkey>();
    int vtg;

    private tk2dSprite sprite;

    int mDem = 0;



    int mTime = 1200;

    int demframe = 0;
    public tk2dTextMesh txtTime;
    public tk2dTextMesh txtLoading;

    int mDiemB3 = 0;


    public enum State
    {
        Start,
        InGame1,
        Click1

    }

    public State currentState;


    void btnOnClick_Next()
    {
		try
		{
        if (currentState == State.InGame1)
        {
            if (buoc < 4)
            {
                buoc++;
                respawn.transform.position = new Vector3(respawn.transform.position.x - KhoangCach, respawn.transform.position.y, respawn.transform.position.z);

            }
            else
            {
                buoc = 1;
                respawn.transform.position = new Vector3(positionStartX, respawn.transform.position.y, respawn.transform.position.z);
            }


            XuLy.transform.position = respawn.transform.position;
        }
		}
		catch (System.Exception)
		{

			throw;
		}

    }

    public void XuatDaTa()
    {
        if (children.Count > 0)
        {
            PhepToan tmvi;
            int chon = UnityEngine.Random.Range(0, children.Count);

            vtg = chon;

            tmvi = new PhepToan(children[chon].Pheptoan, ""+children[chon].Giatri, children[chon].mLoai);
            BangKq = children[chon];


            SpItemMonkey levelCreate = spPrefab.Spawn<SpItemMonkey>
                (
                   new Vector3(-5f, -241f, 33),
                 spPrefab.transform.rotation
                );
            levelCreate.Giatri = ClsThaoTac.doKetQua(tmvi.Ketqua);
            levelCreate.Pheptoan = "" + tmvi.Congthuc;

            levelCreate.setData(tmvi.Loai);
            BangSoSanh = levelCreate;
            BangSoSanh.gameObject.SetActive(true);
            currentState = State.InGame1;

            ConKhi.SetSprite("khihoi");

        }


    }


    public void loadData()
    {
        StartCoroutine(WaitTimeLoadData(1.2f));
    }

    IEnumerator WaitTimeLoadData(float time)
    {
        yield return new WaitForSeconds(time);
        Create();
    }

    public void Create()
    {


        float positionX = startX;

        List<PhepToan> lstTMG = new List<PhepToan>();
        List<PhepToan> lstTMG2 = new List<PhepToan>();

        chonData(ref lstTMG, ref lstTMG2, GameController.instance.lstPhepToan, GameController.instance.level);
        
       


        int vt = 1;

        for (int i = 1; i <= 10; i++)
        {

            doPhanPhat(ref lstTMG, ref lstTMG2, ref vt, ref positionX);
        }

        foreach (Transform child in XuLy.transform)
        {
            children.Add(child.GetComponent<SpItemMonkey>());

        }
        XuatDaTa();
        txtLoading.gameObject.SetActive(false);
    }

    void chonData(ref List<PhepToan> tmg1, ref List<PhepToan> tmg2, List<PhepToan> lstTam, int loai)
    {

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
            while (tmg1.Count < 10)
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
                            stKq = (kqn / 10) + " cm";
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

                    if (chon % 2 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }
                }
            }
        }
        else
        {
            while (tmg1.Count < 10)
            {

                int chon = UnityEngine.Random.Range(0, lstRank.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
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
                            string[] mang = tambo.Split(new Char[] { '-', '+', 'x', ':' });
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
                    PhepToan pt1;
                    if (chon % 3 == 0)
                    {

                        if (lstRank[chon].Ketqua.Contains("/"))
                        {
                            pt1 = new PhepToan(lstRank[chon].Ketqua, lstRank[chon].Ketqua, "phanso");
                        }
                        else
                        {
                            pt1 = new PhepToan(lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                        }
                    }
                    else
                    {
                        pt1 = ClsThaoTac.getPhepToan(lstRank[chon], ref lstRank, chon);
                    }
                   // PhepToan pt1 = ClsThaoTac.getPhepToan(lstRank[chon], ref lstRank, chon);

                    if (chon % 2 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }
                }
            }
        }


    }


    void doPhanPhat(ref List<PhepToan> lstP, ref List<PhepToan> lstXL, ref int vt, ref float positionX)
    {
        int chon = UnityEngine.Random.Range(0, lstP.Count);




        CreateLevel(positionX, lstP[chon], vt);
        CreateLevel(positionX, lstXL[chon]);
        lstP.RemoveAt(chon);
        lstXL.RemoveAt(chon);

        if (vt % 3 == 0)
        {
            positionX += distanceX * 2;
        }
        else
        {
            positionX += distanceX;
        }

        vt++;
    }

    void CreateLevel(float positionX, PhepToan vio, int thutu)
    {


        SpItemMonkey levelCreate = spPrefab.Spawn<SpItemMonkey>
            (
               new Vector3(positionX, startY, 70f),
             spPrefab.transform.rotation
            );
        levelCreate.Giatri = ClsThaoTac.doKetQua(vio.Ketqua);
        levelCreate.Pheptoan = "" + vio.Congthuc;
        levelCreate.setData(vio.Loai);
        levelCreate.Trangthai = true;
        levelCreate.Vitri = thutu;



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
        levelCreate.transform.parent = respawn.transform;
    }

    void CreateLevel(float positionX, PhepToan vio)
    {

        SpItemMonkey levelCreate = spPrefab.Spawn<SpItemMonkey>
           (
              new Vector3(positionX, startY - 115f, 71f),
            spPrefab.transform.rotation
           );
        levelCreate.Giatri = ClsThaoTac.doKetQua(vio.Ketqua);
        levelCreate.Pheptoan = "" + vio.Congthuc;
        levelCreate.setData(vio.Loai);


        levelCreate.transform.parent = XuLy.transform;
        levelCreate.gameObject.SetActive(false);

    }
    IEnumerator WaitTimeXuatData(float time)
    {
        yield return new WaitForSeconds(time);
        XuatDaTa();
    }

    void doXuLy(SpItemMonkey bt)
    {
		try
		{
        if (currentState == State.InGame1)
        {
            if (bt.Trangthai == true)
            {
                bt.Trangthai = false;

                ConKhi.SetSprite("khixet");
                sprite = bt.GetComponent<tk2dSprite>();
                sprite.color = new Color(1, 1, 0.5f, 1);
                currentState = State.Click1;
                SoundManager.Instance.PlayAudioClick();
                StartCoroutine(WaitTimeXuLyTT(1f, bt));
            }
        }
	}
	catch (System.Exception)
	{

		throw;
	}

    }

    IEnumerator WaitTimeXuLyTT(float time, SpItemMonkey bt)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        sprite.color = new Color(1, 1, 1, 1);

        if (bt.Giatri == BangSoSanh.Giatri)
        {
            mDiemB3 += 10;
            SoundManager.Instance.Stop();
            SoundManager.Instance.PlayAudioChucTrue();
            children.RemoveAt(vtg);
            //if (children.Count <= 0)
            //{
            //    GameOver();
            //}
            StartCoroutine(WaitTimeDungRoiTT(0.5f));
        }
        else
        {
            mDiemB3 -= 2;
            StartCoroutine(WaitTimeSaiRoiTT(0.5f));
            bt.Trangthai = true;
        }
    }
    IEnumerator WaitTimeDungRoiTT(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        SoundManager.Instance.Stop();
        ConKhi.SetSprite("khicuoi");

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
        BangKq.gameObject.SetActive(true);
        BangSoSanh.gameObject.SetActive(false);
        BangSoSanh.RecycleSp();


        if (children.Count > 0)
        {

            StartCoroutine(WaitTimeXuatData(1.5f));
        }
        else
        {
            StartCoroutine(WaitTimeGameOver(1f));
        }
    }

    IEnumerator WaitTimeGameOver(float time)
    {
        yield return new WaitForSeconds(time);
        GameOver();
    }

    IEnumerator WaitTimeSaiRoiTT(float time)
    {
        yield return new WaitForSeconds(time);

        SoundManager.Instance.Stop();
        ConKhi.SetSprite("khikhoc");
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
        BangSoSanh.gameObject.SetActive(false);
        BangSoSanh.RecycleSp();


        if (mDem >= 3)
        {
            StartCoroutine(WaitTimeGameOver(1f));



        }
        else
        {
            StartCoroutine(WaitTimeXuatData(1.5f));
        }
    }

    void GameOver()
    {
        currentState = State.Start;
        PopUpController.instance.HideQuestionMonkey();
        if (mDiemB3 < 0)
        {
            mDiemB3 = 0;
        }
        GameController.instance.sumCoin += mDiemB3;
        GameController.instance.sumTime += mTime;
        PopUpController.instance.ShowStopMonkey(mDiemB3, ClsThaoTac.CoverTimeToString(1200 - mTime));

        resetTL();
    }
    public void resetTL()
    {
        mTime = 1200;
        ConKhi.SetSprite("khixet");
        demframe = 0;
        mDem = 0;
        mDiemB3 = 0;
        buoc = 1;
        respawn.transform.position = new Vector3(positionStartX, respawn.transform.position.y, respawn.transform.position.z);
        XuLy.transform.position = respawn.transform.position;
        currentState = State.Start;
        children.Clear();
        txtLoading.gameObject.SetActive(true);

        //remove item in key chinh
        var keychinh = new List<GameObject>();
        foreach (Transform child in respawn.transform)
        {
            keychinh.Add(child.gameObject);
        }


        foreach (GameObject item in keychinh)
        {
            RemoveEvent(item.GetComponent<SpItemMonkey>());
            item.transform.parent = null;
            item.transform.Recycle();
        }

        // remove key phu o key xu ly

        var keyxuly = new List<GameObject>();
        foreach (Transform child in XuLy.transform)
        {
            keyxuly.Add(child.gameObject);
        }


        foreach (GameObject item in keyxuly)
        {
            RemoveEvent(item.GetComponent<SpItemMonkey>());
            item.transform.parent = null;
            item.transform.Recycle();
        }

    }

    void RemoveEvent(SpItemMonkey pSP)
    {

        int tmg = pSP.Vitri;
        tk2dUIItem uiitem = pSP.GetComponent<tk2dUIItem>();
        switch (tmg)
        {
            case 1:
                uiitem.OnClick -= onClick_sp1;
                break;
            case 2:
                uiitem.OnClick -= onClick_sp2;
                break;
            case 3:
                uiitem.OnClick -= onClick_sp3;
                break;
            case 4:
                uiitem.OnClick -= onClick_sp4;
                break;
            case 5:
                uiitem.OnClick -= onClick_sp5;
                break;
            case 6:
                uiitem.OnClick -= onClick_sp6;
                break;
            case 7:
                uiitem.OnClick -= onClick_sp7;
                break;
            case 8:
                uiitem.OnClick -= onClick_sp8;
                break;
            case 9:
                uiitem.OnClick -= onClick_sp9;
                break;
            case 10:
                uiitem.OnClick -= onClick_sp10;
                break;
            case 11:
                uiitem.OnClick -= onClick_sp11;
                break;
            case 12:
                uiitem.OnClick -= onClick_sp12;
                break;
            case 13:
                uiitem.OnClick -= onClick_sp13;
                break;
            case 14:
                uiitem.OnClick -= onClick_sp14;
                break;
            case 15:
                uiitem.OnClick -= onClick_sp15;
                break;
            case 16:
                uiitem.OnClick -= onClick_sp16;
                break;
            case 17:
                uiitem.OnClick -= onClick_sp17;
                break;
            case 18:
                uiitem.OnClick -= onClick_sp18;
                break;
            case 19:
                uiitem.OnClick -= onClick_sp19;
                break;
            case 20:
                uiitem.OnClick -= onClick_sp20;
                break;
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




    // Use this for initialization
    void Start()
    {

        btnNext.OnClick += btnOnClick_Next;
        positionStartX = respawn.transform.position.x;
        txtLoading.text = ClsLanguage.doLoading();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == State.InGame1 || currentState == State.Click1)
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
                    BangSoSanh.gameObject.SetActive(false);
                    BangSoSanh.RecycleSp();
                    GameOver();
                }
            }
        }
    }
}
