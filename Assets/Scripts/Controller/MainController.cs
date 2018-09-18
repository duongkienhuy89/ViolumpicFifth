using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class MainController : MonoBehaviour {
    
    public tk2dUIItem btnPlay; 
    public tk2dUIItem btnRank;
    public tk2dUIItem btnBuyVip;
    public tk2dUIItem btnShare;
    public tk2dUIItem btnRate;

    BannerView bannerView;

    private void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(Config.adsInIDBanner, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }


  
    int ok = 0;

    void btnShare_OnClick()
    {
		try
		{
        SoundManager.Instance.PlayAudioChoiTiep();
        ShareRate.Share();
		}
		catch (System.Exception)
		{

			throw;
		}

    }

    void btnRate_OnClick()
    {
		try
		{
        SoundManager.Instance.PlayAudioChoiTiep();
        ShareRate.Rate();
		}
		catch (System.Exception)
		{

			throw;
		}
    }

 



    void btnBuyVip_OnClick()
    {
		try
		{
        if (GameController.instance.ckClickPlay)
        {
            SoundManager.Instance.PlayAudioChoiTiep();
            PopUpController.instance.ShowBuyItem();
            PopUpController.instance.HideMainGame();

            if (GameController.instance.checkvip != 10)
            {
                bannerView.Hide();
            }
        }
		}
		catch (System.Exception)
		{

			throw;
		}
    }

    void btnRank_OnClick()
    {
		try
		{
        if (GameController.instance.ckClickPlay)
        {
            SoundManager.Instance.PlayAudioChoiTiep();
            if (GameController.instance.vuotqua < 1)
            {
                PopUpController.instance.HideMainGame();
                PopUpController.instance.ShowAdTriger();

            }
            else
            {
                if (ok % 2 == 0)
                {
                    SceneManager.LoadScene("Rank");
                    SoundManager.Instance.StopBGMusic();
                }
                else
                {
                    PopUpController.instance.HideMainGame();
                    PopUpController.instance.ShowAdTriger();
                }
            }

            if (GameController.instance.checkvip != 10)
            {
                bannerView.Hide();
            }
        }
		}
		catch (System.Exception)
		{

			throw;
		}
    }


    void btnPlay_OnClick()
    {
		try
		{
        if (GameController.instance.ckClickPlay)
        {
            PopUpController.instance.ShowLevel();
            PopUpController.instance.HideMainGame();
            SoundManager.Instance.PlayAudioChoiTiep();

            if (GameController.instance.checkvip != 10)
            {
                bannerView.Hide();
            }
        }
		}
		catch (System.Exception)
		{

			throw;
		}

    }

    public void setData()
    {
		try
		{
        if (GameController.instance.vuotqua < 1)
        {
            btnRank.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doQuangCao();
            
        }
        else
        {
            ok= UnityEngine.Random.Range(0, 9);

            if (ok % 2 == 0)
            {

                btnRank.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doXepHang();
            }
            else
            {
                btnRank.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doQuangCao();
            }
        }

        if (GameController.instance.checkvip != 10)
        {
            RequestBanner();
            bannerView.Show();
        }
		}
		catch (System.Exception)
		{

			throw;
		}
    }

	// Use this for initialization
	void Start () {
		try
		{
        btnRank.OnClick += btnRank_OnClick;
        btnPlay.OnClick += btnPlay_OnClick;
        btnBuyVip.OnClick += btnBuyVip_OnClick;
        btnShare.OnClick += btnShare_OnClick;
        btnRate.OnClick += btnRate_OnClick;
    
        btnPlay.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doVaoThi();      
        btnBuyVip.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doMuaVip();
        setData();
       
        if (GameController.instance.checkvip == 10)
        {
            btnBuyVip.gameObject.SetActive(false);
        }
		}
		catch (System.Exception)
		{

			throw;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
