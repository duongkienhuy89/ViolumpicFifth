using UnityEngine;
using System.Collections;

public class StartDinhNui : MonoBehaviour {

   public tk2dUIItem btnVaoThi;
   public tk2dTextMesh txtTitle;
   public tk2dTextMesh txtContent;
   public tk2dTextMesh txtStart;

   

   public void setData(int lesson)
   {
       txtContent.text = ClsLanguage.doLesson() + lesson + ":" + ClsLanguage.doContentDinhNui();
   }

    void btnVaoThi_onClick()
    {
		try
		{
        PopUpController.instance.HideStartDinhNui();
        PopUpController.instance.ShowQuestionDinhNui();
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
        btnVaoThi.OnClick += btnVaoThi_onClick;
        txtTitle.text = ClsLanguage.doTitleDinhNui();
        
        txtStart.text = ClsLanguage.doStart();
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
