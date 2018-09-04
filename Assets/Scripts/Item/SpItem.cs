using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class SpItem : MonoBehaviour {


    public string mLoai;
    public double giatri = 1;
    
    //dung de test

    //int vitri = 0;

    //public int Vitri
    //{
    //    get { return vitri; }
    //    set { vitri = value; }
    //}

    public double Giatri
    {
        get { return giatri; }
        set { giatri = value; }
    }

    string pheptoan = "";

    public string Pheptoan
    {
        get { return pheptoan; }
        set { pheptoan = value; }
    }

    private bool trangthai = true;

    public bool Trangthai
    {
        get { return trangthai; }
        set { trangthai = value; }
    }

    //public void RecycleSp()
    //{
    //    this.Recycle<SpItem>();
    //}

    void setEnHi(GameObject gao)
    {
        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(false);
        }
        gao.SetActive(true);
    }
 

    public void setData(string loai)
    {
        this.gameObject.GetComponent<tk2dSprite>().SetSprite("nhapnhay");

        if (loai.Trim().Equals("phanso"))
        {

            setEnHi(this.gameObject.transform.GetChild(1).gameObject);
       

            if (pheptoan.Contains("/") || pheptoan.Contains(":"))
            {
                string[] mang = pheptoan.Split('/');
                string ts = mang[0].Trim();
                string ms = mang[1].Trim();
                int kc = Math.Abs(ts.Count() - ms.Count());
                if (ts.Count() > ms.Count())
                {
                    if (kc == 1)
                    {
                        ms = " " + ms;
                    }
                    else
                    {
                        ms = "  " + ms;
                    }
                }
                else if (ts.Count() < ms.Count())
                {
                    if (kc == 1)
                    {
                        ts = " " + ts;
                    }
                    else
                    {
                        ts = "  " + ts;
                    }
                }

                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ts;
                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).GetComponent<tk2dTextMesh>().text = ms;
                int mC = mang[0].Length;
                if (mC < mang[1].Length)
                {
                    mC = mang[1].Length;
                }
                if (mC > 11)
                {
                    mC = 11;
                }
                string tam = "";
                for (int i = 0; i < mC; i++)
                {
                    tam += "_";
                }
                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).GetComponent<tk2dTextMesh>().text = "" + tam;
            }
           
        }
       else if (loai.Trim().Equals("phansohai"))
       {
           setEnHi(this.gameObject.transform.GetChild(2).gameObject);

           string dau = "";
           if (pheptoan.Contains("+"))
           {
               dau = "+";
           }
           else if (pheptoan.Contains("-"))
           {
               dau = "-";
           }
           else if (pheptoan.Contains("x"))
           {
               dau = "x";
           }
           else if (pheptoan.Contains(":"))
           {
               dau = ":";
           }
           string[] mang = pheptoan.Split(new Char[] { '-', '+', 'x', ':', '/' });

           string ts = mang[0].Trim();
           string ms = mang[1].Trim();
           int kc = Math.Abs(ts.Count() - ms.Count());
           if (ts.Count() > ms.Count())
           {
               if (kc == 1)
               {
                   ms = " " + ms;
               }
               else
               {
                   ms = "  " + ms;
               }
           }
           else if (ts.Count() < ms.Count())
           {
               if (kc == 1)
               {
                   ts = " " + ts;
               }
               else
               {
                   ts = "  " + ts;
               }
           }

           this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ts;
           this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).GetComponent<tk2dTextMesh>().text = ms;

            ts = mang[2].Trim();
            ms = mang[3].Trim();
            kc = Math.Abs(ts.Count() - ms.Count());
           if (ts.Count() > ms.Count())
           {
               if (kc == 1)
               {
                   ms = " " + ms;
               }
               else
               {
                   ms = "  " + ms;
               }
           }
           else if (ts.Count() < ms.Count())
           {
               if (kc == 1)
               {
                   ts = " " + ts;
               }
               else
               {
                   ts = "  " + ts;
               }
           }

           this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(4).GetComponent<tk2dTextMesh>().text =ts;
           this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(5).GetComponent<tk2dTextMesh>().text = ms;
           this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(6).GetComponent<tk2dTextMesh>().text = dau;

           int mC = mang[0].Length;
           if (mC < mang[1].Length)
           {
               mC = mang[1].Length;
           }
         
           string tam = "";
           for (int i = 0; i < mC; i++)
           {
               tam += "_";
           }
           this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).GetComponent<tk2dTextMesh>().text = tam;

           mC = mang[2].Length;
           tam = "";
           if (mC < mang[3].Length)
           {
               mC = mang[3].Length;
           }

           for (int i = 0; i < mC; i++)
           {
               tam += "_";
           }
           this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).GetComponent<tk2dTextMesh>().text = tam;

       }
        else if (loai.Trim().Equals("phansotrai"))
        {
            setEnHi(this.gameObject.transform.GetChild(3).gameObject);
            string dau = "";
            if (pheptoan.Contains("+"))
            {
                dau = "+";
            }
            else if (pheptoan.Contains("-"))
            {
                dau = "-";
            }
            else if (pheptoan.Contains("x"))
            {
                dau = "x";
            }
            else if (pheptoan.Contains(":"))
            {
                dau = ":";
            }
            string[] mang = pheptoan.Split(new Char[] { '-', '+', 'x', ':', '/' });
            string ts = mang[0].Trim();
            string ms = mang[1].Trim();
            int kc = Math.Abs(ts.Count() - ms.Count());
            if (ts.Count() > ms.Count())
            {
                if (kc == 1)
                {
                    ms = " " + ms;
                }
                else
                {
                    ms = "  " + ms;
                }
            }
            else if (ts.Count() < ms.Count())
            {
                if (kc == 1)
                {
                    ts = " " + ts;
                }
                else
                {
                    ts = "  " + ts;
                }
            }
            this.gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ts;
            this.gameObject.transform.GetChild(3).gameObject.transform.GetChild(2).GetComponent<tk2dTextMesh>().text = ms;
            this.gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).GetComponent<tk2dTextMesh>().text = mang[2];
            int mC = mang[0].Length;
            if (mC < mang[1].Length)
            {
                mC = mang[1].Length;
            }
            if (mC >= 4)
                mC = 3;
            string tam = "";
            for (int i = 0; i < mC; i++)
            {
                tam += "_";
            }
            this.gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).GetComponent<tk2dTextMesh>().text = tam;
            this.gameObject.transform.GetChild(3).gameObject.transform.GetChild(4).GetComponent<tk2dTextMesh>().text = dau;

        }
        else if (loai.Trim().Equals("phansophai"))
        {
            setEnHi(this.gameObject.transform.GetChild(4).gameObject);
            string dau = "";
            if (pheptoan.Contains("+"))
            {
                dau = "+";
            }
            else if (pheptoan.Contains("-"))
            {
                dau = "-";
            }
            else if (pheptoan.Contains("x"))
            {
                dau = "x";
            }
            else if (pheptoan.Contains(":"))
            {
                dau = ":";
            }
            string[] mang = pheptoan.Split(new Char[] { '-', '+', 'x', ':', '/' });
            this.gameObject.transform.GetChild(4).gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = mang[0];
            string ts = mang[1].Trim();
            string ms = mang[2].Trim();
            int kc = Math.Abs(ts.Count() - ms.Count());
            if (ts.Count() > ms.Count())
            {
                if (kc == 1)
                {
                    ms = " " + ms;
                }
                else
                {
                    ms = "  " + ms;
                }
            }
            else if (ts.Count() < ms.Count())
            {
                if (kc == 1)
                {
                    ts = " " + ts;
                }
                else
                {
                    ts = "  " + ts;
                }
            }
            this.gameObject.transform.GetChild(4).gameObject.transform.GetChild(2).GetComponent<tk2dTextMesh>().text = ts;
            this.gameObject.transform.GetChild(4).gameObject.transform.GetChild(3).GetComponent<tk2dTextMesh>().text = ms;
            int mC = mang[1].Length;
            if (mC < mang[2].Length)
            {
                mC = mang[2].Length;
            }
            string tam = "";
            for (int i = 0; i < mC; i++)
            {
                tam += "_";
            }
            this.gameObject.transform.GetChild(4).gameObject.transform.GetChild(1).GetComponent<tk2dTextMesh>().text = tam;
            this.gameObject.transform.GetChild(4).gameObject.transform.GetChild(4).GetComponent<tk2dTextMesh>().text = dau;

        }
        else if (loai.Trim().Equals("phansoba"))
        {
            setEnHi(this.gameObject.transform.GetChild(5).gameObject);
            string dau1 = "";
            string dau2 = "";
            if (pheptoan.Contains("+") && pheptoan.Contains("-"))
            {
                int vtd1 = pheptoan.IndexOf('+');
                int vtd2 = pheptoan.IndexOf('-');
                if (vtd1 > vtd2)
                {
                    dau1 = "-";
                    dau2 = "+";
                }
                else
                {
                    dau1 = "+";
                    dau2 = "-";
                }
                
            }
            else if (pheptoan.Contains("+") && pheptoan.Contains("x"))
            {
                int vtd1 = pheptoan.IndexOf('+');
                int vtd2 = pheptoan.IndexOf('x');
                if (vtd1 > vtd2)
                {
                    dau1 = "x";
                    dau2 = "+";
                }
                else
                {
                    dau1 = "+";
                    dau2 = "x";
                }
            }
            else if (pheptoan.Contains("+") && pheptoan.Contains(":"))
            {
                int vtd1 = pheptoan.IndexOf('+');
                int vtd2 = pheptoan.IndexOf(':');
                if (vtd1 > vtd2)
                {
                    dau1 = ":";
                    dau2 = "+";
                }
                else
                {
                    dau1 = "+";
                    dau2 = ":";
                }
            }
            else if (pheptoan.Contains("-") && pheptoan.Contains("x"))
            {
                int vtd1 = pheptoan.IndexOf('-');
                int vtd2 = pheptoan.IndexOf('x');
                if (vtd1 > vtd2)
                {
                    dau1 = "x";
                    dau2 = "-";
                }
                else
                {
                    dau1 = "-";
                    dau2 = "x";
                }
            }
            else if (pheptoan.Contains("-") && pheptoan.Contains(":"))
            {
                int vtd1 = pheptoan.IndexOf('-');
                int vtd2 = pheptoan.IndexOf(':');
                if (vtd1 > vtd2)
                {
                    dau1 = ":";
                    dau2 = "-";
                }
                else
                {
                    dau1 = "-";
                    dau2 = ":";
                }
            }
            else if (pheptoan.Contains("x") && pheptoan.Contains(":"))
            {
                int vtd1 = pheptoan.IndexOf('x');
                int vtd2 = pheptoan.IndexOf(':');
                if (vtd1 > vtd2)
                {
                    dau1 = ":";
                    dau2 = "x";
                }
                else
                {
                    dau1 = "x";
                    dau2 = ":";
                }
            }
            else if (pheptoan.Contains("+"))
            {
                dau1 = "+";
                dau2 = "+";
            }
            else if (pheptoan.Contains("-"))
            {
                dau1 = "-";
                dau2 = "-";
            }
            else if (pheptoan.Contains("x"))
            {
                dau1 = "x";
                dau2 = "x";
            }
            else if (pheptoan.Contains(":"))
            {
                dau1 = ":";
                dau2 = ":";
            }

            string[] mang = pheptoan.Split(new Char[] { '-', '+', 'x', ':', '/' });
            this.gameObject.transform.GetChild(5).gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = mang[0];
            this.gameObject.transform.GetChild(5).gameObject.transform.GetChild(2).GetComponent<tk2dTextMesh>().text = mang[1];
            this.gameObject.transform.GetChild(5).gameObject.transform.GetChild(4).GetComponent<tk2dTextMesh>().text = mang[2];
            this.gameObject.transform.GetChild(5).gameObject.transform.GetChild(5).GetComponent<tk2dTextMesh>().text = mang[3];
            this.gameObject.transform.GetChild(5).gameObject.transform.GetChild(10).GetComponent<tk2dTextMesh>().text = mang[4];
            this.gameObject.transform.GetChild(5).gameObject.transform.GetChild(9).GetComponent<tk2dTextMesh>().text = mang[5];
            this.gameObject.transform.GetChild(5).gameObject.transform.GetChild(6).GetComponent<tk2dTextMesh>().text = dau1;
            this.gameObject.transform.GetChild(5).gameObject.transform.GetChild(7).GetComponent<tk2dTextMesh>().text = dau2;

            int mC = mang[0].Length;
            if (mC < mang[1].Length)
            {
                mC = mang[1].Length;
            }
            string tam = "";
            for (int i = 0; i < mC; i++)
            {
                tam += "_";
            }
            this.gameObject.transform.GetChild(5).gameObject.transform.GetChild(1).GetComponent<tk2dTextMesh>().text = tam;

            mC = mang[2].Length;
            if (mC < mang[3].Length)
            {
                mC = mang[3].Length;
            }
             tam = "";
            for (int i = 0; i < mC; i++)
            {
                tam += "_";
            }
            this.gameObject.transform.GetChild(5).gameObject.transform.GetChild(3).GetComponent<tk2dTextMesh>().text = tam;

            mC = mang[4].Length;
            if (mC < mang[5].Length)
            {
                mC = mang[5].Length;
            }
            tam = "";
            for (int i = 0; i < mC; i++)
            {
                tam += "_";
            }
            this.gameObject.transform.GetChild(5).gameObject.transform.GetChild(8).GetComponent<tk2dTextMesh>().text = tam;

        }
        else if (loai.Trim().Equals("mix"))
        {
            setEnHi(this.gameObject.transform.GetChild(6).gameObject);
            string[] mang = pheptoan.Split(new Char[] { ']', '/' });
            string mixso = mang[0].Trim();
            if (mixso.Count() == 1)
                mixso = "  " + mixso;
            this.gameObject.transform.GetChild(6).gameObject.transform.GetChild(3).GetComponent<tk2dTextMesh>().text = mixso;

            string ts = mang[1].Trim();
            string ms = mang[2].Trim();
            int kc = Math.Abs(ts.Count() - ms.Count());
            if (ts.Count() > ms.Count())
            {
                if (kc == 1)
                {
                    ms = " " + ms;
                }
                else
                {
                    ms = "  " + ms;
                }
            }
            else if (ts.Count() < ms.Count())
            {
                if (kc == 1)
                {
                    ts = " " + ts;
                }
                else
                {
                    ts = "  " + ts;
                }
            }
            this.gameObject.transform.GetChild(6).gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ts;
            this.gameObject.transform.GetChild(6).gameObject.transform.GetChild(2).GetComponent<tk2dTextMesh>().text = ms;
            int mC = mang[1].Length;
            if (mC < mang[2].Length)
            {
                mC = mang[2].Length;
            }
            string tam = "";
            for (int i = 0; i < mC; i++)
            {
                tam += "_";
            }
            this.gameObject.transform.GetChild(6).gameObject.transform.GetChild(1).GetComponent<tk2dTextMesh>().text = tam;
        }
        else if (loai.Trim().Equals("mixhai"))
        {
            setEnHi(this.gameObject.transform.GetChild(7).gameObject);
            string dau = "";
            if (pheptoan.Contains("+"))
            {
                dau = "+";
            }
            else if (pheptoan.Contains("-"))
            {
                dau = "-";
            }
            else if (pheptoan.Contains("x"))
            {
                dau = "x";
            }
            else if (pheptoan.Contains(":"))
            {
                dau = ":";
            }
            string[] mang = pheptoan.Split(new Char[] { '-', '+', 'x', ':', '/',']' });
            this.gameObject.transform.GetChild(7).gameObject.transform.GetChild(7).GetComponent<tk2dTextMesh>().text = mang[0];

            string ts = mang[1].Trim();
            string ms = mang[2].Trim();
            int kc = Math.Abs(ts.Count() - ms.Count());
            if (ts.Count() > ms.Count())
            {
                if (kc == 1)
                {
                    ms = " " + ms;
                }
                else
                {
                    ms = "  " + ms;
                }
            }
            else if (ts.Count() < ms.Count())
            {
                if (kc == 1)
                {
                    ts = " " + ts;
                }
                else
                {
                    ts = "  " + ts;
                }
            }
            this.gameObject.transform.GetChild(7).gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ts;
            this.gameObject.transform.GetChild(7).gameObject.transform.GetChild(2).GetComponent<tk2dTextMesh>().text = ms;
            this.gameObject.transform.GetChild(7).gameObject.transform.GetChild(8).GetComponent<tk2dTextMesh>().text = mang[3];

             ts = mang[4].Trim();
             ms = mang[5].Trim();
             kc = Math.Abs(ts.Count() - ms.Count());
            if (ts.Count() > ms.Count())
            {
                if (kc == 1)
                {
                    ms = " " + ms;
                }
                else
                {
                    ms = "  " + ms;
                }
            }
            else if (ts.Count() < ms.Count())
            {
                if (kc == 1)
                {
                    ts = " " + ts;
                }
                else
                {
                    ts = "  " + ts;
                }
            }
            this.gameObject.transform.GetChild(7).gameObject.transform.GetChild(4).GetComponent<tk2dTextMesh>().text =ts;
            this.gameObject.transform.GetChild(7).gameObject.transform.GetChild(5).GetComponent<tk2dTextMesh>().text = ms;
            this.gameObject.transform.GetChild(7).gameObject.transform.GetChild(6).GetComponent<tk2dTextMesh>().text = dau;

            int mC = mang[1].Length;
            if (mC < mang[2].Length)
            {
                mC = mang[2].Length;
            }
            string tam = "";
            for (int i = 0; i < mC; i++)
            {
                tam += "_";
            }
            this.gameObject.transform.GetChild(7).gameObject.transform.GetChild(1).GetComponent<tk2dTextMesh>().text = tam;

            mC = mang[4].Length;
            if (mC < mang[5].Length)
            {
                mC = mang[5].Length;
            }
            tam = "";
            for (int i = 0; i < mC; i++)
            {
                tam += "_";
            }
            this.gameObject.transform.GetChild(7).gameObject.transform.GetChild(3).GetComponent<tk2dTextMesh>().text = tam;
        }
        else if (loai.Trim().Equals("phanhai"))
        {
            setEnHi(this.gameObject.transform.GetChild(8).gameObject);
            string[] mang = pheptoan.Split(new Char[] { '/', 'c' });

            string ts = mang[0].Trim();
            string ms = mang[1].Trim();
            int kc = Math.Abs(ts.Count() - ms.Count());
            if (ts.Count() > ms.Count())
            {
                if (kc == 1)
                {
                    ms = " " + ms;
                }
                else
                {
                    ms = "  " + ms;
                }
            }
            else if (ts.Count() < ms.Count())
            {
                if (kc == 1)
                {
                    ts = " " + ts;
                }
                else
                {
                    ts = "  " + ts;
                }
            }
            this.gameObject.transform.GetChild(8).gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ts;
            this.gameObject.transform.GetChild(8).gameObject.transform.GetChild(2).GetComponent<tk2dTextMesh>().text = ms;

             ts = mang[2].Trim();
             ms = mang[3].Trim();
             kc = Math.Abs(ts.Count() - ms.Count());
            if (ts.Count() > ms.Count())
            {
                if (kc == 1)
                {
                    ms = " " + ms;
                }
                else
                {
                    ms = "  " + ms;
                }
            }
            else if (ts.Count() < ms.Count())
            {
                if (kc == 1)
                {
                    ts = " " + ts;
                }
                else
                {
                    ts = "  " + ts;
                }
            }
            this.gameObject.transform.GetChild(8).gameObject.transform.GetChild(4).GetComponent<tk2dTextMesh>().text = ts;
            this.gameObject.transform.GetChild(8).gameObject.transform.GetChild(5).GetComponent<tk2dTextMesh>().text = ms;

            int mC = mang[0].Length;
            if (mC < mang[1].Length)
            {
                mC = mang[1].Length;
            }
            string tam = "";
            for (int i = 0; i < mC; i++)
            {
                tam += "_";
            }
            this.gameObject.transform.GetChild(8).gameObject.transform.GetChild(1).GetComponent<tk2dTextMesh>().text = tam;


            mC = mang[2].Length;
            if (mC < mang[3].Length)
            {
                mC = mang[3].Length;
            }
            tam = "";
            for (int i = 0; i < mC; i++)
            {
                tam += "_";
            }
            this.gameObject.transform.GetChild(8).gameObject.transform.GetChild(3).GetComponent<tk2dTextMesh>().text = tam;
            this.gameObject.transform.GetChild(8).gameObject.transform.GetChild(6).GetComponent<tk2dTextMesh>().text = ClsLanguage.doOf().Trim();

        }
        else if (loai.Trim().Equals("phantrai"))
        {
            setEnHi(this.gameObject.transform.GetChild(9).gameObject);
            string[] mang = pheptoan.Split(new Char[] { '/', 'c' });
            string ts = mang[0].Trim();
            string ms = mang[1].Trim();
            int kc = Math.Abs(ts.Count() - ms.Count());
            if (ts.Count() > ms.Count())
            {
                if (kc == 1)
                {
                    ms = " " + ms;
                }
                else
                {
                    ms = "  " + ms;
                }
            }
            else if (ts.Count() < ms.Count())
            {
                if (kc == 1)
                {
                    ts = " " + ts;
                }
                else
                {
                    ts = "  " + ts;
                }
            }
            this.gameObject.transform.GetChild(9).gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ts;
            this.gameObject.transform.GetChild(9).gameObject.transform.GetChild(2).GetComponent<tk2dTextMesh>().text = ms;
            this.gameObject.transform.GetChild(9).gameObject.transform.GetChild(3).GetComponent<tk2dTextMesh>().text = ClsLanguage.doOf().Trim() + " " + mang[2];
           
            int mC = mang[0].Length;
            if (mC < mang[1].Length)
            {
                mC = mang[1].Length;
            }
            string tam = "";
            for (int i = 0; i < mC; i++)
            {
                tam += "_";
            }
            this.gameObject.transform.GetChild(9).gameObject.transform.GetChild(1).GetComponent<tk2dTextMesh>().text = tam;
        }
        else if (loai.Trim().Equals("phanphai"))
        {
            setEnHi(this.gameObject.transform.GetChild(10).gameObject);
            string[] mang = pheptoan.Split(new Char[] { '/', 'c' });
            this.gameObject.transform.GetChild(10).gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = mang[0]+" "+ClsLanguage.doOf().Trim();
            string ts = mang[1].Trim();
            string ms = mang[2].Trim();
            int kc = Math.Abs(ts.Count() - ms.Count());
            if (ts.Count() > ms.Count())
            {
                if (kc == 1)
                {
                    ms = " " + ms;
                }
                else
                {
                    ms = "  " + ms;
                }
            }
            else if (ts.Count() < ms.Count())
            {
                if (kc == 1)
                {
                    ts = " " + ts;
                }
                else
                {
                    ts = "  " + ts;
                }
            }
            this.gameObject.transform.GetChild(10).gameObject.transform.GetChild(2).GetComponent<tk2dTextMesh>().text = ts;
            this.gameObject.transform.GetChild(10).gameObject.transform.GetChild(3).GetComponent<tk2dTextMesh>().text = ms;
            int mC = mang[1].Length;
            if (mC < mang[2].Length)
            {
                mC = mang[2].Length;
            }
            string tam = "";
            for (int i = 0; i < mC; i++)
            {
                tam += "_";
            }
            this.gameObject.transform.GetChild(10).gameObject.transform.GetChild(1).GetComponent<tk2dTextMesh>().text = tam;
        }
        else
        {
            setEnHi(this.gameObject.transform.GetChild(0).gameObject);
            this.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = pheptoan;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
