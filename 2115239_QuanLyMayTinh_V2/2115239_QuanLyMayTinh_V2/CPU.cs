using System;
using System.Collections.Generic;
using System.Text;

namespace _2115239_QuanLyMayTinh_V2
{
    public class CPU : iLinhKien
    {

        float tocDo;
        public string Hang { get; set; }
        public float Gia { get; set; }

        public CPU()
        {

        }

        public CPU(string text)
        {
            string[] str = text.Split(';');
            Hang = str[0];
            Gia = float.Parse(str[1]);
            tocDo = float.Parse(str[2]);
        }

        public CPU(string hang, float gia, float tocDo)
        {
            this.tocDo = tocDo;
        }

        public float GiaBan()
        {
            return this.Gia;
        }

        public override string ToString()
        {
            return string.Format("CPU: hang {0}, gia {1}, toc do {2}GHz", Hang, Gia, tocDo);
        }
    }
}
