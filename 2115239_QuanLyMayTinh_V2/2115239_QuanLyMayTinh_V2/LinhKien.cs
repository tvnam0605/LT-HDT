using System;
using System.Collections.Generic;
using System.Text;

namespace _2115239_QuanLyMayTinh_V2
{
    public interface iLinhKien
    {
        string Hang { get; set; }
        float Gia { get; set; }
        //float SoCPU { get; set; }
        float GiaBan();
    }
}
