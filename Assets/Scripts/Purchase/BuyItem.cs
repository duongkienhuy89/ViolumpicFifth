using UnityEngine;
using System.Collections;

public class BuyItem : MonoBehaviour {

    public tk2dTextMesh txtTitle;
    public tk2dTextMesh txtContent;
    public tk2dUIItem btnCancel;
    public tk2dUIItem btnBuy;

    void btnCancel_OnClick()
    {
		try
		{
        PopUpController.instance.HideBuyItem();
        PopUpController.instance.ShowMainGame();
		}
		catch (System.Exception)
		{

			throw;
		}
    }

    void btnBuy_OnClick()
    {
		try
		{
        IAPManager.instance.BuyVipLevel();
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
        btnCancel.OnClick += btnCancel_OnClick;
        btnBuy.OnClick += btnBuy_OnClick;
        txtTitle.text = ClsLanguage.doActiVip();
        txtContent.text = ClsLanguage.doContenVip();
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
