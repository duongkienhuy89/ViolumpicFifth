using UnityEngine;
using System.Collections;

public class LvItem : MonoBehaviour {

    private tk2dSprite spiteLv;

    private GameObject txtSp;
    private tk2dTextMesh txtMesh;
    private tk2dSprite spiteRate;
    private tk2dUIItem itemLevel;
    public int giatri = 1;

    void Awake()
    {
        spiteLv = this.gameObject.GetComponent<tk2dSprite>();
        txtSp = this.gameObject.transform.GetChild(1).gameObject;
        txtMesh = txtSp.GetComponent<tk2dTextMesh>();
        spiteRate = this.gameObject.transform.GetChild(0).GetComponent<tk2dSprite>();
        itemLevel = this.gameObject.GetComponent<tk2dUIItem>();
    }

    public void setData(int gt)
    {
        giatri = gt;
        if (gt > (GameController.instance.vuotqua + 1))
        {
            spiteLv.SetSprite("levellock");
            txtSp.SetActive(false);
            spiteRate.gameObject.SetActive(false);
            spiteLv.color = new Color(1, 1, 1, 1);
           
        }
        else
        {
            spiteRate.gameObject.SetActive(true);
            spiteLv.SetSprite("levelopen");
            txtSp.SetActive(true);
            txtMesh.text = "" + gt;
            spiteLv.color = new Color(1, 1, 0, 1);
            if (gt == (GameController.instance.vuotqua + 1))
            {
                spiteRate.SetSprite("khongsao");
            }
            else
            {
                if (int.Parse(GameController.instance.mang[gt - 1]) >=300)
                {
                    spiteRate.SetSprite("basao");
                }
                else if (int.Parse(GameController.instance.mang[gt - 1]) > 280)
                {
                    spiteRate.SetSprite("haisao");
                }
                else
                {
                    spiteRate.SetSprite("motsao");
                }
            }
        }
    }

    void btnItem_onClick()
    {
       
        if ((GameController.instance.vuotqua + 1) >= giatri)
        {
            GameController.instance.level = giatri;
            PopUpController.instance.HideLevel();
            PopUpController.instance.ShowStartGame();
            GameController.instance.ckResetLv = true;
            SoundManager.Instance.PlayAudioChoiTiep();
        }
    }

	// Use this for initialization
	void Start () {
        itemLevel.OnClick += btnItem_onClick;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
