using UnityEngine;
using System.Collections;

public class PhepToan  {

    string congthuc;

    public string Congthuc
    {
        get { return congthuc; }
        set { congthuc = value; }
    }
    string ketqua;

    public string Ketqua
    {
        get { return ketqua; }
        set { ketqua = value; }
    }
    string loai;

    public string Loai
    {
        get { return loai; }
        set { loai = value; }
    }

    public PhepToan(string congthuc, string ketqua, string loai)
    {
        this.congthuc = congthuc;
        this.ketqua = ketqua;
        this.loai = loai;
    }
}
