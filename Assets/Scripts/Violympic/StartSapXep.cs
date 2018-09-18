using UnityEngine;
using System.Collections;

public class StartSapXep : MonoBehaviour {

    public tk2dTextMesh txtTitle;
    public tk2dTextMesh txtContent;
    public tk2dUIItem btnPlay;


    void btnPlay_OnClick()
    {
		try
		{
        SoundManager.Instance.PauseBGMusic();
        PopUpController.instance.HideStartSapXep();
        PopUpController.instance.ShowQuestionSapXep();
        SoundManager.Instance.PlayAudioChoiTiep();
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
        btnPlay.OnClick += btnPlay_OnClick;

        txtTitle.text = ClsLanguage.doTileSapXep();
        txtContent.text = ClsLanguage.doSapXep();
        btnPlay.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doVaoThi();
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
