using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ThanhMau thanhMau;
    public float luongMauHienTai;
    public float luongMauToiDa = 10;
    void Start()
    {
        luongMauHienTai = luongMauToiDa;
        thanhMau.capNhatThanhMau(luongMauHienTai,luongMauToiDa);
    }

    private void OnMouseDown() {
        luongMauHienTai -= 2;
        thanhMau.capNhatThanhMau(luongMauHienTai,luongMauToiDa);
        if(luongMauHienTai < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
