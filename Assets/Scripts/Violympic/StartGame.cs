using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

    public tk2dUIItem btnVaoThi;
    public tk2dUIItem btnBack;
    public tk2dTextMesh txtTitle;
    public tk2dTextMesh txtContent;
    public tk2dTextMesh txtPlay;

    void onClick_Back()
    {
		try
		{
        PopUpController.instance.HideStartGame();
        PopUpController.instance.ShowLevel();
		}
		catch (System.Exception)
		{

			throw;
		}
    }

    void onClick_VaoThi()
    {
		try
		{
         PopUpController.instance.HideStartGame();
       
        GameController.instance.ShowLevel1();
        GameController.instance.ckResetLv = false;
      
        SoundManager.Instance.PlayAudioChoiTiep();
		}
		catch (System.Exception)
		{

			throw;
		}
    }
    public void setData()
    {
        txtTitle.text = ClsLanguage.doBatDau() + GameController.instance.level;
       
    }

	// Use this for initialization
	void Start () {
		try
		{
        btnVaoThi.OnClick += onClick_VaoThi;
        btnBack.OnClick += onClick_Back;
        
        txtContent.text = ClsLanguage.doContentBatDau();
        txtPlay.text = ClsLanguage.doVaoThi();
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
