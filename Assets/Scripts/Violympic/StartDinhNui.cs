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
        PopUpController.instance.HideStartDinhNui();
        PopUpController.instance.ShowQuestionDinhNui();
        SoundManager.Instance.PauseBGMusic();
        SoundManager.Instance.PlayAudioChoiTiep();
    }

	// Use this for initialization
	void Start () {
        btnVaoThi.OnClick += btnVaoThi_onClick;
        txtTitle.text = ClsLanguage.doTitleDinhNui();
        
        txtStart.text = ClsLanguage.doStart();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
