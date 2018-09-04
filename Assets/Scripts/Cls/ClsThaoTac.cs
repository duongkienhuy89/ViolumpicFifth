using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;


public class ClsThaoTac  {

    public static double doKetQua(string tmp)
    {
        double ok;
    
            if (tmp.Contains("/") || tmp.Contains(":"))
            {
                string[] mang = tmp.Split(new Char[] { '/', ':' });
                ok = Math.Round((double.Parse(mang[0]) / double.Parse(mang[1])), 6);
            }
            else
            {
                ok = Math.Round(double.Parse(tmp), 6);
            }
         
        return ok;
    }

    public static string CoverTimeToString(int mTime)
    {
        string stTime = "";
        int timeN = mTime / 60;
        int timeD = mTime % 60;
        if (timeD >= 10)
        {
            stTime = "" + timeN + ":" + timeD;
        }
        else
        {
            stTime = "" + timeN + ":0" + timeD;
        }
        return stTime;
    }

   

 

  
   


    public static PhepToan getPhepToan(PhepToan giatri,ref List<PhepToan> lst, int pc)
    {
        lst.RemoveAt(pc);
        List<PhepToan> tmg = new List<PhepToan>();
        foreach (PhepToan item in lst)
        {
            if (item.Congthuc.Equals(giatri.Congthuc))
                continue;
            if (ClsThaoTac.doKetQua(item.Ketqua) == ClsThaoTac.doKetQua((giatri.Ketqua)))
            {
                tmg.Add(item);
            }
        }

        if (tmg.Count > 0)
        {
            int chon = UnityEngine.Random.Range(0, tmg.Count);
            string tambo = "" + tmg[chon].Congthuc;
            string tambo2 = "" + tmg[chon].Congthuc;

            if (tambo.Contains("c"))
            {
                string[] mang = tambo.Split('c');
                if (mang[0].Contains("/") && mang[1].Contains("/"))
                {
                    tambo = "phanhai";
                }
                else if (mang[0].Contains("/"))
                {
                    tambo = "phantrai";
                }
                else if (mang[1].Contains("/"))
                {
                    tambo = "phanphai";
                }
                else
                {
                    tambo = "number";
                    tambo2 = mang[0] + ClsLanguage.doOf() + mang[1];
                }
            }
            else if (tambo.Contains("]"))
            {
                if (tambo.Contains("+") || tambo.Contains("-") || tambo.Contains("x") || tambo.Contains(":"))
                {
                    tambo = "mixhai";
                }
                else
                {
                    tambo = "mix";
                }
            }
            else if (tambo.Contains("/"))
            {
                if (tambo.Contains("+") || tambo.Contains("-") || tambo.Contains("x") || tambo.Contains(":"))
                {
                    string[] mang = tambo.Split(new Char[] { '-', '+', 'x', ':' });
                    if (mang.Length >= 3)
                    {

                        int dem = 0;
                        for (int i = 0; i < tambo.Count(); i++)
                        {
                            string dkm = "" + tambo[i];
                            if (dkm.Equals("/"))
                            {
                                dem++;
                            }
                        }
                        if (dem >= 2)
                        {

                            tambo = "phansoba";

                        }
                        else
                        {
                            tambo = "phanso";
                        }
                    }
                    else
                    {
                        if (mang[0].Contains("/") && mang[1].Contains("/"))
                        {
                            tambo = "phansohai";

                        }
                        else if (mang[0].Contains("/"))
                        {
                            tambo = "phansotrai";
                        }
                        else if (mang[1].Contains("/"))
                        {
                            tambo = "phansophai";
                        }
                        else
                        {
                            tambo = "phanso";
                        }
                    }
                }
                else
                {
                    tambo = "phanso";
                }
            }
            else
            {
                tambo = "number";
            }

            return new PhepToan(tambo2, tmg[chon].Ketqua, tambo);
           
        }
        else
        {
            if (giatri.Ketqua.Contains("/"))
            {
                return new PhepToan("" + giatri.Ketqua, giatri.Ketqua, "phanso");
            }
            else
            {
                return new PhepToan("" + giatri.Ketqua, giatri.Ketqua, "number");
            }
        }
    }

    }

