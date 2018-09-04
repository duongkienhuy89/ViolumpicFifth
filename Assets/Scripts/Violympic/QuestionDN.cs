using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class QuestionDN : MonoBehaviour {

    public GameObject bangbieu;
    public tk2dTextMesh txtTitle;
    public tk2dTextMesh txtContent;
    public tk2dUIItem btnA;
    public tk2dUIItem btnB;
    public tk2dUIItem btnC;
    public tk2dUIItem btnD;
    public tk2dUIItem btnContinute;
    public tk2dTextMesh txtGiaiThich;

    private tk2dTextMesh txtA;
    private tk2dTextMesh txtB;
    private tk2dTextMesh txtC;
    private tk2dTextMesh txtD;
   

    public List<DinhNui> lstLevel = new List<DinhNui>();
    //public List<DinhNui> lstBien = new List<DinhNui>();
    public int truecase = 0;
    public int select = 0;
 
    private tk2dSprite spSelect;
    private tk2dSprite spCase;
    public int diemSo = 0;
    public int demsai = 0;
    public int sttQuestion = 0;
    public tk2dSprite nguoi;
    public Vector3 po0 = new Vector3(269, -216, -1);
    public Vector3 po1 = new Vector3(151, -183, -1);
    public Vector3 po2 = new Vector3(10, -137, -1);
    public Vector3 po3 = new Vector3(10, -57, -1);
    public Vector3 po4 = new Vector3(75, 0, -1);
    public Vector3 po5 = new Vector3(174, 48, -1);
    public Vector3 po6 = new Vector3(263, 63, -1);
    public Vector3 po7 = new Vector3(234, 99, -1);
    public Vector3 po8 = new Vector3(155, 133, -1);
    public Vector3 po9 = new Vector3(200, 219, -1);
    public Vector3 po10 = new Vector3(243, 260, -1);

    public tk2dTextMesh txtTime;
    int mTime = 1200;
   
    int demframe = 0;

    public enum State
    {
        Start,
        InGame,
        Click,
        XuLyT,
        XyLyF,
        Stop
    }

    public State currentState;

    #region Singleton

    public void getDataLevel()
    {

        foreach (DinhNui item in GameController.instance.lstSum)
        {
            if (item.Level == GameController.instance.level)
            {
                lstLevel.Add(item);
            }
        }
        

       

        

        doSubGet(ref lstLevel);
        currentState = State.InGame;
        
    }
    #endregion

    void resetThongSo()
    {
            diemSo = 0;
     demsai = 0;
     sttQuestion = 0;
      mTime = 1200;
      nguoi.SetSprite("khihoi");
      demframe = 0;
      nguoi.gameObject.transform.localPosition = po0;
      nguoi.scale = new Vector3(0.5f, 0.5f, 1);
      lstLevel.Clear();
    }

    int doChonSai(int so)
    {
        int dapso = 0;
        int chon = UnityEngine.Random.Range(1, 31);
        if (chon % 2 == 0)
        {
            dapso = Math.Abs(so-chon);
        }
        else
        {
            dapso = Math.Abs(so + chon);
        }

        if (dapso == so)
        {
            dapso++;
        }

        return dapso;
    }
    void xulyPS(string dl, string da, tk2dTextMesh txt, tk2dUIItem bt)
    {
        if (dl.Contains("/"))
        {
            txt.gameObject.SetActive(false);
            bt.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            string[] mang = dl.Split('/');
            int k = mang[0].Length;
            if (k < mang[1].Length)
            {
                k = mang[1].Length;
            }
            string tam = "";
            for (int i = 0; i < k; i++)
            {
                tam += "_";
            }
            bt.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).GetComponent<tk2dTextMesh>().text = tam;

            string ts = mang[0].Trim();
            string ms = mang[1].Trim();
            int kc = Math.Abs(ts.Count() - ms.Count());
            if (ts.Count() > ms.Count())
            {
                if (kc == 1)
                {
                    ms = " " + ms;
                }
                else
                {
                    ms = "  " + ms;
                }
            }
            else if (ts.Count() < ms.Count())
            {
                if (kc == 1)
                {
                    ts = " " + ts;
                }
                else
                {
                    ts = "  " + ts;
                }
            }
          
            bt.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).GetComponent<tk2dTextMesh>().text = ts;
            bt.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).GetComponent<tk2dTextMesh>().text = ms;

        }
        else
        {
            txt.gameObject.SetActive(true);
            bt.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            txt.text = da + "." + dl;

        }
    }

    public void doSubGet(ref List<DinhNui> lst)
    {
        if (lst.Count > 0)
        {
            int chon = UnityEngine.Random.Range(0, lst.Count);
            txtContent.text = lst[chon].Question;
            xulyPS(lst[chon].Casea.Trim(), "A", txtA, btnA);
            xulyPS(lst[chon].Caseb.Trim(), "B", txtB, btnB);
            xulyPS(lst[chon].Casec.Trim(), "C", txtC, btnC);
            xulyPS(lst[chon].Cased.Trim(), "D", txtD, btnD);
            string giaithich;

            if (GameController.instance.checkvip == 10 || GameController.instance.level==1)
            {

                giaithich = lst[chon].Giaithich.Trim();
                if (giaithich.Equals("giaithich") || giaithich.Equals("gta"))
                {
                    string kq = "";
                    if (lst[chon].Truecase == 1)
                    {
                        kq = lst[chon].Casea;
                    }
                    else if (lst[chon].Truecase == 2)
                    {
                        kq = lst[chon].Caseb;
                    }
                    if (lst[chon].Truecase == 3)
                    {
                        kq = lst[chon].Casec;
                    }
                    else if (lst[chon].Truecase == 4)
                    {
                        kq = lst[chon].Cased;
                    }
                    giaithich = ClsLanguage.doDapSo() + kq;
                }
            }
            else
            {
                string kq = "";
                if (lst[chon].Truecase == 1)
                {
                    kq = lst[chon].Casea;
                }
                else if (lst[chon].Truecase == 2)
                {
                    kq = lst[chon].Caseb;
                }
                if (lst[chon].Truecase == 3)
                {
                    kq = lst[chon].Casec;
                }
                else if (lst[chon].Truecase == 4)
                {
                    kq = lst[chon].Cased;
                }
                
                giaithich = ClsLanguage.doDapSo() + kq + ClsLanguage.doBanCanMuaVip();
            }



            txtGiaiThich.text = ClsLanguage.doGiaiThich()+"" + giaithich;
            truecase = lst[chon].Truecase;
            lst.RemoveAt(chon);
            sttQuestion++;
            txtTitle.text = ClsLanguage.doQuestion() + " " + sttQuestion+".";
        }
        else
        {
        }
       
    }


    void btnA_OnClick()
    {
        if (currentState == State.InGame)
        {
            currentState = State.Click;
            select = 1;
            spSelect = btnA.gameObject.GetComponent<tk2dSprite>();
            doXuLy(select);
        }
    }
    void btnB_OnClick()
    {
        if (currentState == State.InGame)
        {
            currentState = State.Click;
            select = 2;
            spSelect = btnB.gameObject.GetComponent<tk2dSprite>();
            doXuLy(select);
        }
    }
    void btnC_OnClick()
    {
        if (currentState == State.InGame)
        {
            currentState = State.Click;
            select = 3;
            spSelect = btnC.gameObject.GetComponent<tk2dSprite>();
            doXuLy(select);
        }
    }
    void btnD_OnClick()
    {
        if (currentState == State.InGame)
        {
            currentState = State.Click;
            select = 4;
            spSelect = btnD.gameObject.GetComponent<tk2dSprite>();
            doXuLy(select);
        }
    }

    void doXuLy(int selectCase)
    {
        
            SoundManager.Instance.PlayAudioClick();
            nguoi.SetSprite("khixet");
          
            spSelect.color = new Color(0.2f, 0.2f, 0.2f);

            StartCoroutine(WaitTimeXuLyDN(1.5f));

        
    }

    IEnumerator WaitTimeXuLyDN(float time)
    {

        yield return new WaitForSeconds(time);

        if (select == truecase)
        {
            currentState = State.XuLyT;

            spSelect.color = new Color(1/(float)255,248/(float)255, 63/(float)255);
            diemSo += 10;
            SoundManager.Instance.Stop();
            SoundManager.Instance.PlayAudioChucTrue();
           
            StartCoroutine(WaitTimeDungRoiDN(1f));
        }
        else
        {
            
            currentState = State.XyLyF;
            if (truecase == 1)
            {
                spCase = btnA.gameObject.GetComponent<tk2dSprite>();
            }
            else if (truecase == 2)
            {
                spCase = btnB.gameObject.GetComponent<tk2dSprite>();
            }
            else if (truecase == 3)
            {
                spCase = btnC.gameObject.GetComponent<tk2dSprite>();
            }
            else
            {
                spCase = btnD.gameObject.GetComponent<tk2dSprite>();
            }
            spCase.color = new Color(1 / (float)255, 248 / (float)255, 63 / (float)255);
            spSelect.color = new Color(246 / (float)255, 13 / (float)255, 27 / (float)255);
            demsai++;
            StartCoroutine(WaitTimeSaiRoiDN(0.5f));


        }
    }

    IEnumerator WaitTimeDungRoiDN(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);
        // nếu đúng

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

        StartCoroutine(WaittingCamXuc(1f));
    }
    IEnumerator WaitTimeSaiRoiDN(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);
        SoundManager.Instance.Stop();

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
        StartCoroutine(WaittingGiaiThich(1.5f));
    }

    void doHideShow(bool ok)
    {
        btnA.gameObject.SetActive(ok);
        btnB.gameObject.SetActive(ok);
        btnC.gameObject.SetActive(ok);
        btnD.gameObject.SetActive(ok);
        btnContinute.gameObject.SetActive(!ok);
        txtGiaiThich.gameObject.SetActive(!ok);
    }

    IEnumerator WaittingGiaiThich(float time)
    {
        yield return new WaitForSeconds(time);
        doHideShow(false);

    }

    IEnumerator WaittingCamXuc(float time)
    {

        //do something...............
        yield return new WaitForSeconds(time);

     
            bangbieu.SetActive(false);
            StartCoroutine(WaittingDiChuyen(1f));
       
    }

    IEnumerator WaittingDiChuyen(float time)
    {
        yield return new WaitForSeconds(time);

        if (diemSo > 0 && diemSo<=10)
        {
            nguoi.gameObject.transform.localPosition = po1;
            nguoi.scale = new Vector3(0.49f, 0.49f, 1);
        }
        else if (diemSo>10&&diemSo<=20)
        {
            nguoi.gameObject.transform.localPosition = po2;
            nguoi.scale = new Vector3(0.48f, 0.48f, 1);
        }
        else if (diemSo > 20 && diemSo <= 30)
        {
            nguoi.gameObject.transform.localPosition = po3;
            nguoi.scale = new Vector3(0.46f, 0.46f, 1);
        }
        else if (diemSo > 30 && diemSo <= 40)
        {
            nguoi.gameObject.transform.localPosition = po4;
            nguoi.scale = new Vector3(0.45f, 0.45f, 1);
        }
        else if (diemSo > 40 && diemSo <= 50)
        {
            nguoi.gameObject.transform.localPosition = po5;
            nguoi.scale = new Vector3(0.44f, 0.44f, 1);
        }
        else if (diemSo > 50 && diemSo <= 60)
        {
            nguoi.gameObject.transform.localPosition = po6;
            nguoi.scale = new Vector3(0.43f, 0.43f, 1);
        }
        else if (diemSo > 60 && diemSo <= 70)
        {
            nguoi.gameObject.transform.localPosition = po7;
            nguoi.scale = new Vector3(0.42f, 0.42f, 1);
        }
        else if (diemSo > 70 && diemSo <= 80)
        {
            nguoi.gameObject.transform.localPosition = po8;
            nguoi.scale = new Vector3(0.41f, 0.41f, 1);
        }
        else if (diemSo > 80 && diemSo <= 90)
        {
            nguoi.gameObject.transform.localPosition = po9;
            nguoi.scale = new Vector3(0.4f, 0.4f, 1);
        }
        else if (diemSo > 90 && diemSo <= 100)
        {
            nguoi.gameObject.transform.localPosition = po10;
            nguoi.scale = new Vector3(0.39f, 0.39f, 1);
        }

        if (currentState == State.XuLyT)
        {
            nguoi.SetSprite("khicuoi");

        }
        else
        {
            nguoi.SetSprite("khikhoc");
        }
        StartCoroutine(WaittingChoiTiep(1f));
    }

    IEnumerator WaittingChoiTiep(float time)
    {
        yield return new WaitForSeconds(time);

        bangbieu.SetActive(true);
        if (currentState == State.XyLyF)
        {
            doHideShow(true);
        }
        resetColorBt();

        if (sttQuestion < 10)
        {
            doSubGet(ref lstLevel);
            currentState = State.InGame;
        }
        else
        {
            gameOver();
        }
    }

    void resetColorBt()
    {
        btnA.gameObject.GetComponent<tk2dSprite>().color = new Color(161 / (float)255, 176 / (float)255, 251 / (float)255);
        btnB.gameObject.GetComponent<tk2dSprite>().color = new Color(161 / (float)255, 176 / (float)255, 251 / (float)255);
        btnC.gameObject.GetComponent<tk2dSprite>().color = new Color(161 / (float)255, 176 / (float)255, 251 / (float)255);
        btnD.gameObject.GetComponent<tk2dSprite>().color = new Color(161 / (float)255, 176 / (float)255, 251 / (float)255);
      
        
       
    }

    void btnContinute_OnClick()
    {
        
        if (demsai < 3)
        {
            bangbieu.SetActive(false);
            StartCoroutine(WaittingDiChuyen(1f));
        }
        else
        {
            doHideShow(true);
            resetColorBt();
            gameOver();
        }
    }

    void gameOver()
    {

       
        currentState = State.Stop;
        if (diemSo < 0)
        {
            diemSo = 0;
        }
        GameController.instance.sumCoin += diemSo;
        GameController.instance.sumTime += mTime;
        PopUpController.instance.ShowStopDinhNui(diemSo, ClsThaoTac.CoverTimeToString(1200 - mTime));
        PopUpController.instance.HideQuestionDinhNui();
        resetThongSo();
    }

  

	// Use this for initialization
	void Start () {
        txtA = btnA.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>();
        txtB = btnB.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>();
        txtC = btnC.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>();
        txtD = btnD.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>();
        btnContinute.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text=ClsLanguage.doContinute();

        txtTitle.text = ClsLanguage.doQuestion();

        btnA.OnClick += btnA_OnClick;
        btnB.OnClick += btnB_OnClick;
        btnC.OnClick += btnC_OnClick;
        btnD.OnClick += btnD_OnClick;
        btnContinute.OnClick += btnContinute_OnClick;
	}
	
	// Update is called once per frame
	void Update () {

        if (currentState != State.Start&&currentState!=State.Stop)
        {
        //đếm ngược thời gian từ 20 phút
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
                    //currentState = State.Stop;
                    //hết giờ thì game over
                    doHideShow(true);
                    resetColorBt();
                    gameOver();
                }
            }
        }
	}
}
