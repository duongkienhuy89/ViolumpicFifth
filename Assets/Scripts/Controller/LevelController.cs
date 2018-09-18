using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {

    public LvItem lvPrefab;
    public float startX;
    public float distanceX;
    public float startY;
    public float distanceY;

    #region Singleton
    private static LevelController _instance;

    public static LevelController instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<LevelController>();
            return _instance;
        }
    }
    #endregion

    public tk2dUIItem btnBack;
    void onClick_Back()
    {
		try
		{
        PopUpController.instance.HideLevel();
        PopUpController.instance.ShowMainGame();
		}
		catch (System.Exception)
		{

			throw;
		}
    }

    public void resetData()
    {
        if (GameController.instance.ckResetLv == false)
        {
            //remove cây item trống không
            var children = new List<GameObject>();
            foreach (Transform child in this.transform)
            {
                children.Add(child.gameObject);
            }

            foreach (GameObject item in children)
            {
                if (item.CompareTag("nguoi"))
                {
                    continue;
                }

                item.GetComponent<LvItem>().setData(item.GetComponent<LvItem>().giatri);
            }
        }
    }

    void CreateItem(float positionX, float positionY, int vitri)
    {

        LvItem levelCreate = lvPrefab.Spawn<LvItem>
            (
               new Vector3(positionX, positionY, 85f),
             lvPrefab.transform.rotation
            );

        levelCreate.setData(vitri);

        levelCreate.transform.parent = this.gameObject.transform;
     

     

    }

    public void Createlevl(int sl)
    {
        float positionCreateX = startX;
        float positionCreateY = startY;
        for (int i = 1; i <= sl; i++)
        {
            CreateItem(positionCreateX, positionCreateY, i);
            positionCreateX += distanceX;
            if (i % 5 == 0)
            {
                positionCreateX = startX;
                positionCreateY -= distanceY;
            }
        }
    }

    void Awake()
    {
		try
		{
        Createlevl(20);
		}
		catch (System.Exception)
		{

			throw;
		}
    }

	// Use this for initialization
	void Start () {
        btnBack.OnClick += onClick_Back;

        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
