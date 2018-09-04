using UnityEngine;
using System.Collections;

public class DinhNui  {

  
    string question;

    public string Question
    {
        get { return question; }
        set { question = value; }
    }


    string casea;

    public string Casea
    {
        get { return casea; }
        set { casea = value; }
    }
    string caseb;

    public string Caseb
    {
        get { return caseb; }
        set { caseb = value; }
    }
    string casec;

    public string Casec
    {
        get { return casec; }
        set { casec = value; }
    }
    string cased;



    public string Cased
    {
        get { return cased; }
        set { cased = value; }
    }
    int truecase;

    public int Truecase
    {
        get { return truecase; }
        set { truecase = value; }
    }

    string giaithich;

    public string Giaithich
    {
        get { return giaithich; }
        set { giaithich = value; }
    }
    int level;

    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    public DinhNui()
    {
    }

    public DinhNui( string quesion, string casea, string caseb, string casec, string cased, int truecase, string giaithich, int level)
    {
     
        this.question = quesion;
        this.casea = casea;
        this.caseb = caseb;
        this.casec = casec;
        this.cased = cased;
        this.truecase = truecase;
        this.giaithich = giaithich;
        this.level = level;
    }
}
