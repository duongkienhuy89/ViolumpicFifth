using UnityEngine;
using System.Collections;

public class PopUpController : MonoBehaviour {

    #region Singleton
    private static PopUpController _instance;

    public static PopUpController instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<PopUpController>();
            return _instance;
        }
    }
    #endregion


    public float showY;
    public float hideY;   

    public float moveSpeed;

    public MainController maingame;
    public GameObject loading;
    public LevelController level;
    public StartGame startgame;
    public StartDinhNui startdinhnui;
    public QuestionDN questionDn;
    public StopDinhNui stopDN;
    public StartBangNhau startBangNhau;
    public QuestionBangNhau questionBN;
    public StopBangNhau stopBN;
    public GameObject startsapxep;
    public QuestionSapXep questionSX;
    public StopSapXep stopSX;
    public GameObject startthongthai;
    public QuestionMonkey questionMonkey;
    public StopMonkey stopMk;
    public StopGame stopGame;
    public GameObject hoanthanh;
    public GameObject buyvip;
    public Advertise ad;

    public GameObject MessVip;

    public void ShowMessVip()
    {

        StartCoroutine(ieMoveDown(MessVip, showY));
    }
    public void HideMessVip()
    {
        StartCoroutine(ieMoveUp(MessVip, hideY));
    }

    public void ShowAdTriger()
    {
        ad.setData();
        StartCoroutine(ieMoveDown(ad.gameObject, showY));
    }
    public void HideAdTriger()
    {
        StartCoroutine(ieMoveUp(ad.gameObject, hideY));
    }


    public void ShowBuyItem()
    {

        StartCoroutine(ieMoveDown(buyvip, showY));
    }
    public void HideBuyItem()
    {
        StartCoroutine(ieMoveUp(buyvip, hideY));
    }

    public void ShowHoanThanh()
    {

        StartCoroutine(ieMoveDown(hoanthanh, showY));
    }
    public void HideHoanThanh()
    {
        StartCoroutine(ieMoveUp(hoanthanh, hideY));
    }


    public void ShowStopGame()
    {
        stopGame.setData();
        StartCoroutine(ieMoveDown(stopGame.gameObject, showY));
    }
    public void HideStopGame()
    {
        StartCoroutine(ieMoveUp(stopGame.gameObject, hideY));
    }

    public void ShowStopMonkey(int diem, string time)
    {
        stopMk.setData(diem, time);

        StartCoroutine(ieMoveDown(stopMk.gameObject, showY));
    }
    public void HideStopMonkey()
    {
        StartCoroutine(ieMoveUp(stopMk.gameObject, hideY));
    }

  
    public void ShowQuestionMonkey()
    {
        questionMonkey.loadData();
        StartCoroutine(ieMoveDown(questionMonkey.gameObject, showY));
    }
    public void HideQuestionMonkey()
    {
        StartCoroutine(ieMoveUp(questionMonkey.gameObject, hideY));
    }

    public void ShowStartThongThai()
    {

        StartCoroutine(ieMoveDown(startthongthai, showY));
    }
    public void HideStartThongThai()
    {
        StartCoroutine(ieMoveUp(startthongthai, hideY));
    }


    public void ShowStopSapXep(int diem, string time)
    {
        stopSX.setData(diem, time);

        StartCoroutine(ieMoveDown(stopSX.gameObject, showY));
    }
    public void HideStopSapXep()
    {
        StartCoroutine(ieMoveUp(stopSX.gameObject, hideY));
    }




    public void ShowQuestionSapXep()
    {
        questionSX.setPlay();
        StartCoroutine(ieMoveDown(questionSX.gameObject, showY));
    }
    public void HideQuestionSapXep()
    {
        StartCoroutine(ieMoveUp(questionSX.gameObject, hideY));
    }


    public void ShowStartSapXep()
    {

        StartCoroutine(ieMoveDown(startsapxep, showY));
    }
    public void HideStartSapXep()
    {
        StartCoroutine(ieMoveUp(startsapxep, hideY));
    }

    public void ShowStopBangNhau(int diem, string time)
    {
        stopBN.setData(diem, time);

        StartCoroutine(ieMoveDown(stopBN.gameObject, showY));
    }
    public void HideStopBangNhau()
    {
        StartCoroutine(ieMoveUp(stopBN.gameObject, hideY));
    }

    //public void setDataBangNhau()
    //{
    //    questionBN.loadData();
    //}

    public void ShowQuestionBangNhau()
    {
        questionBN.setPlay();
        StartCoroutine(ieMoveDown(questionBN.gameObject, showY));
    }
    public void HideQuestionBangNhau()
    {
        StartCoroutine(ieMoveUp(questionBN.gameObject, hideY));
    }

    public void ShowStartBangNhau(int lesson)
    {
        startBangNhau.setData(lesson);
        StartCoroutine(ieMoveDown(startBangNhau.gameObject, showY));
    }
    public void HideStartBangNhau()
    {
        StartCoroutine(ieMoveUp(startBangNhau.gameObject, hideY));
    }

    public void ShowStopDinhNui(int diem,string time)
    {
        stopDN.setData(diem, time);

        StartCoroutine(ieMoveDown(stopDN.gameObject, showY));
    }
    public void HideStopDinhNui()
    {
        StartCoroutine(ieMoveUp(stopDN.gameObject, hideY));
    }

    public void ShowQuestionDinhNui()
    {

        questionDn.getDataLevel();
        StartCoroutine(ieMoveDown(questionDn.gameObject, showY));
    }
    public void HideQuestionDinhNui()
    {
        StartCoroutine(ieMoveUp(questionDn.gameObject, hideY));
    }

    public void ShowStartDinhNui(int lesson)
    {
        startdinhnui.setData(lesson);
        StartCoroutine(ieMoveDown(startdinhnui.gameObject, showY));
    }
    public void HideStartDinhNui()
    {
        StartCoroutine(ieMoveUp(startdinhnui.gameObject, hideY));
    }

    public void ShowStartGame()
    {
        startgame.setData();
        StartCoroutine(ieMoveDown(startgame.gameObject, showY));
    }
    public void HideStartGame()
    {
        StartCoroutine(ieMoveUp(startgame.gameObject, hideY));
    }

    public void ShowLevel()
    {
        level.resetData();
        StartCoroutine(ieMoveDown(level.gameObject, showY));
    }
    public void HideLevel()
    {
        
        StartCoroutine(ieMoveUp(level.gameObject, hideY));
    }
    public void HideLoading()
    {
        StartCoroutine(ieMoveUp(loading, hideY));
        //loading.transform.position = new Vector3(loading.gameObject.transform.position.x, hideY, loading.gameObject.transform.position.z);
    }


    public void ShowMainGame()
    {
        maingame.setData();
        StartCoroutine(ieMoveDown(maingame.gameObject, showY));
    }
    public void HideMainGame()
    {
        StartCoroutine(ieMoveUp(maingame.gameObject, hideY));
    }


    IEnumerator ieMoveDown(GameObject popup, float SY)
    {
        while (popup.transform.position.y >= SY)
        {
            popup.transform.position += Vector3.down
                * (moveSpeed)
                * Time.deltaTime;
            yield return 0;
        }
        popup.transform.position = new Vector3(popup.gameObject.transform.position.x, SY, popup.gameObject.transform.position.z);

    }

    IEnumerator ieMoveUp(GameObject popup, float HY)
    {
        while (popup.transform.position.y <= HY)
        {
            popup.transform.position += Vector3.up
                * (moveSpeed)
                * Time.deltaTime;
            yield return 0;
        }
        popup.transform.position = new Vector3(popup.gameObject.transform.position.x, HY, popup.gameObject.transform.position.z);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
