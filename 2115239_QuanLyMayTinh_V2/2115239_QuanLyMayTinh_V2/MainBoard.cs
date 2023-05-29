using System;
using System.Collections.Generic;
using System.Text;

namespace _2115239_QuanLyMayTinh_V2
{
   public class MainBoard:iLinhKien

    {
        public string nuocSX;
        public string Hang { get; set; }
        public float Gia { get; set; }
        public MainBoard()
        {

        }
        public MainBoard (string s)
        {
            string[] str = s.Split(';');
            nuocSX = str[0];
            Hang = str[1];
            Gia = float.Parse(str[2]);
        }
        public float GiaBan()
        {
           return this.Gia;
        }
        public MainBoard(string nuocSX, string Hang, string Gia)
        {
            this.nuocSX = nuocSX;
        }
        public override string ToString()
        {
            return string.Format("MainBoard: Nuoc san xuat {0}, Hang {1}, gia {2}", nuocSX, Hang, Gia);
        }

    }
}
