using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{

    public AudioSource audioSourceBGMusicPrefab;
    private AudioSource audioSourceBGMusicCreated;

    public AudioClip[] arrAudioClip;

    #region Singleton
    private static SoundManager _instance;

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<SoundManager>();
            return _instance;
        }
    }
    #endregion

    void Awake()
    {
        PlayBGMusic();
        DontDestroyOnLoad(this.gameObject);
    }

    void PlayBGMusic()
    {
        audioSourceBGMusicCreated =
            GameObject.Instantiate
            (
                audioSourceBGMusicPrefab
            ) as AudioSource;
        audioSourceBGMusicCreated.loop = false;
        audioSourceBGMusicCreated.Play();

        DontDestroyOnLoad
        (
            audioSourceBGMusicCreated
        );
    }

    public void rePlayBGMusic()
    {
        audioSourceBGMusicCreated.Play();
    }
    public void StopBGMusic()
    {
        audioSourceBGMusicCreated.Stop();
    }

   public void PauseBGMusic()
    {
        audioSourceBGMusicCreated.Pause();
    }

    public void PlayAudioChucMung1()
    {
        if (GameController.instance.tienganh)
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[27]);
        }
        else
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[0]);
        }
    }

    public void PlayAudioChucMung2()
    {
        if (GameController.instance.tienganh)
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[27]);
        }
        else
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[1]);
        }

    }



    public void PlayAudioChucMung3()
    {
        if (GameController.instance.tienganh)
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[26]);
        }
        else
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[2]);
        }
    }



    public void PlayAudioChucMung4()
    {
        if (GameController.instance.tienganh)
        {
            //tk2dUIAudioManager.Instance.Play(arrAudioClip[26]);
        }
        else
        {

            tk2dUIAudioManager.Instance.Play(arrAudioClip[3]);
        }
    }

   
    public void PlayAudioChucDung1(int chon)
    {
        if (GameController.instance.tienganh)
        {
            if (chon % 2 == 0)
            {
                tk2dUIAudioManager.Instance.Play(arrAudioClip[16]);
            }
            else
            {
                tk2dUIAudioManager.Instance.Play(arrAudioClip[17]);
            }
        }
        else
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[4]);
        }
    }
    public void PlayAudioChucDung2(int chon)
    {
        if (GameController.instance.tienganh)
        {
            if (chon % 2 == 0)
            {
                tk2dUIAudioManager.Instance.Play(arrAudioClip[18]);
            }
            else
            {
                tk2dUIAudioManager.Instance.Play(arrAudioClip[19]);
            }
        }
        else
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[5]);
        }
    }
    public void PlayAudioChucDung3(int chon)
    {
        if (GameController.instance.tienganh)
        {
            if (chon % 2 == 0)
            {
                tk2dUIAudioManager.Instance.Play(arrAudioClip[20]);
            }
            else
            {
                tk2dUIAudioManager.Instance.Play(arrAudioClip[21]);
            }
        }
        else
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[6]);
        }
    }
    public void PlayAudioChucDung4(int chon)
    {
        if (GameController.instance.tienganh)
        {
            if (chon % 2 == 0)
            {
                tk2dUIAudioManager.Instance.Play(arrAudioClip[22]);
            }
            else
            {
                tk2dUIAudioManager.Instance.Play(arrAudioClip[23]);
            }
        }
        else
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[7]);
        }
    }
    public void PlayAudioChucDung5(int chon)
    {
        if (GameController.instance.tienganh)
        {
            if (chon % 2 == 0)
            {
                tk2dUIAudioManager.Instance.Play(arrAudioClip[24]);
            }
            else
            {
                tk2dUIAudioManager.Instance.Play(arrAudioClip[25]);
            }
        }
        else
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[8]);
        }
    }

    public void PlayAudioChucSai1()
    {
        if (GameController.instance.tienganh)
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[27]);
        }
        else
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[9]);
        }
    }

    public void PlayAudioChucSai2()
    {
        if (GameController.instance.tienganh)
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[27]);
        }
        else
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[10]);
        }
    }

    public void PlayAudioChucSai3()
    {
        if (GameController.instance.tienganh)
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[27]);
        }
        else
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[11]);
        }
    }

    public void PlayAudioChucSai4()
    {
        if (GameController.instance.tienganh)
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[27]);
        }
        else
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[12]);
        }
    }

    public void PlayAudioChucSai5()
    {
        if (GameController.instance.tienganh)
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[27]);
        }
        else
        {
            tk2dUIAudioManager.Instance.Play(arrAudioClip[13]);
        }
    }

    public void PlayAudioChucTrue()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[14]);
    }

    public void PlayAudioClick()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[15]);
    }


    public void PlayAudioChoiTiep()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[28]);
    }





    void UpVolue()
    {
        // do something
    }
    public void Stop()
    {
        tk2dUIAudioManager.Instance.curentStop();
    }

    void DownVolumn()
    {
        // do something
    }
}
