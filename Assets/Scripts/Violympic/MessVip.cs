using UnityEngine;
using System.Collections;

public class MessVip : MonoBehaviour {

    public tk2dTextMesh txtContent;
    public tk2dTextMesh txtBuyVip;
    public tk2dUIItem btnContinute;

    public tk2dUIItem btnBack;


    public void btnBack_onClick()
    {
        //PopUpController.instance.HideMessVip();
        //PopUpController.instance.ShowMainGame();

        int chon = UnityEngine.Random.Range(0, 3);
        if (chon == 0)
        {
            ShareRate.RateAdCa();
        }
        else
        {
            ShareRate.RateAdGa();
        }
    }


    public void btnContinute_onClick()
    {
        PopUpController.instance.HideMessVip();
        PopUpController.instance.ShowBuyItem();
    }

    // Use this for initialization
    void Start()
    {

        txtContent.text = ClsLanguage.doThongBao();
        txtBuyVip.text = ClsLanguage.doMuaVip();

        btnContinute.OnClick += btnContinute_onClick;
        btnBack.OnClick += btnBack_onClick;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
