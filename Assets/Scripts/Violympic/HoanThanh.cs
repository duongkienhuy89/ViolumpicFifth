using UnityEngine;
using System.Collections;

public class HoanThanh : MonoBehaviour {

    public tk2dTextMesh txtTitle;
    public tk2dTextMesh txtContent;
    public tk2dUIItem btnContinute;

    void onClick_btnContinute()
    {
		try
		{
        PopUpController.instance.HideHoanThanh();
        PopUpController.instance.ShowLevel();
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
        btnContinute.OnClick += onClick_btnContinute;
        txtTitle.text = ClsLanguage.doTitleTuyetVoi();
        txtContent.text = ClsLanguage.doContentTuyetVoi();
        btnContinute.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doTitleTuyetVoi();
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
