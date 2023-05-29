using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2115239_QuanLyMayTinh
{
    public interface iLinhKien
    {
        string Hang { get; set; }
        float Gia { get; set; }
        //float SoCPU { get; set; }
        float GiaBan();
    }
}
