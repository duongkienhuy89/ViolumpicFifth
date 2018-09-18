using UnityEngine;
using System.Collections;

public class StartBangNhau : MonoBehaviour {


    public tk2dTextMesh txtTitle;
    public tk2dTextMesh txtContent;
    public tk2dUIItem btnPlay;

    public void setData(int lesson)
    {
		try
		{
        txtContent.text = ClsLanguage.doLesson() + lesson + ":" + ClsLanguage.doContentCapBangNhau();
		}
		catch (System.Exception)
		{

			throw;
		}
    }

    void onClick_btnPlay()
    {
		try
		{
        PopUpController.instance.HideStartBangNhau();
        PopUpController.instance.ShowQuestionBangNhau();
        SoundManager.Instance.PauseBGMusic();
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
        btnPlay.OnClick += onClick_btnPlay;

        txtTitle.text = ClsLanguage.doTitleCapBangNhau();
    
        btnPlay.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doStart();
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
