using UnityEngine;
using System.Collections;

public class HoanThanh : MonoBehaviour {

    public tk2dTextMesh txtTitle;
    public tk2dTextMesh txtContent;
    public tk2dUIItem btnContinute;

    void onClick_btnContinute()
    {
        PopUpController.instance.HideHoanThanh();
        PopUpController.instance.ShowLevel();
    }

	// Use this for initialization
	void Start () {
        btnContinute.OnClick += onClick_btnContinute;
        txtTitle.text = ClsLanguage.doTitleTuyetVoi();
        txtContent.text = ClsLanguage.doContentTuyetVoi();
        btnContinute.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doTitleTuyetVoi();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
