using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class StopGame : MonoBehaviour {

    public tk2dSprite sa_Nguoi;
    public tk2dTextMesh txtHoanThanh;
    public tk2dTextMesh txtTitle;
    public tk2dTextMesh txtTongDiem;
    public tk2dUIItem btnContinute;
    public tk2dSprite rate;

    InterstitialAd interstitial;
  
  

    void onClick_Continute()
    {
        if (GameController.instance.checkvip != 10)
        {
            ShowAdsInterstitial();
        }

        PopUpController.instance.HideStopGame();
        if (GameController.instance.level < 21)
        {
            PopUpController.instance.ShowStartGame();
        }
        else
        {
            PopUpController.instance.ShowHoanThanh();
        }
        GameController.instance.sumCoin = 0;
        GameController.instance.sumTime = 0;
    }


    private void LoadAdsInterstitial()
    {
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(Config.adsInIDGameOver);
        // Create an empty ad request.
        AdRequest requestIN = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("365BCE5DDF729BFD1E6E40D79CE8F42B").Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(requestIN);
    }

 

    private void ShowAdsInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void HideAdsInterstitial()
    {
        interstitial.Destroy();
    }

  

    public void setData()
    {
        LoadAdsInterstitial();

        if (GameController.instance.sumCoin < 150)
        {
            txtHoanThanh.text = ClsLanguage.doChuaVuotQua() + GameController.instance.level;
            rate.SetSprite("khongsao");
            sa_Nguoi.SetSprite("khikhoc");
            int chon = UnityEngine.Random.Range(0, 2);
            if (chon == 0)
            {
                SoundManager.Instance.PlayAudioChucMung1();
            }
            else
            {
                SoundManager.Instance.PlayAudioChucMung2();
            }
        }
        else
        {
            txtHoanThanh.text = ClsLanguage.doVuotQua() + GameController.instance.level;
            if (GameController.instance.sumCoin >= 300)
            {
                rate.SetSprite("basao");
            }
            else if (GameController.instance.sumCoin > 280)
            {
                rate.SetSprite("haisao");
            }
            else
            {
                rate.SetSprite("motsao");
            }
            sa_Nguoi.SetSprite("khicuoi");
            SoundManager.Instance.PlayAudioChucMung3();


            //luu diem vao tong diem
            GameController.instance.stSumcoin = "";
            if (int.Parse(GameController.instance.mang[GameController.instance.level-1]) < GameController.instance.sumCoin)
            {
                GameController.instance.mang[GameController.instance.level - 1] = "" + GameController.instance.sumCoin;
            }

            GameController.instance.stSumcoin = GameController.instance.mang[0];
            for (int i = 1; i < GameController.instance.mang.Length; i++)
            {
                GameController.instance.stSumcoin =GameController.instance.stSumcoin+"+"+ GameController.instance.mang[i];
            }
            DataManager.SaveHightStringCoin(GameController.instance.stSumcoin);


            //lu so giay tat ca 3 vong
            if (GameController.instance.level > GameController.instance.vuotqua)
            {
                DataManager.SaveHightSecond(GameController.instance.sumTime);
            }



            //luu level vuot qua
            if (GameController.instance.vuotqua < GameController.instance.level)
            {
                GameController.instance.vuotqua = GameController.instance.level;
                DataManager.SaveHightLevel(GameController.instance.level);
            }

            GameController.instance.level++;
        }
        txtTongDiem.text = ClsLanguage.doTongDiem() + GameController.instance.sumCoin + "/300";
       
    }

	// Use this for initialization
	void Start () {

        btnContinute.OnClick += onClick_Continute;
        btnContinute.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doContinute();
        txtTitle.text = ClsLanguage.doTongKet();
        LoadAdsInterstitial();

       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
