using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2115239_QuanLyMayTinh
{
   public class RAM : iLinhKien

    {
        public float dungLuong;
        public string Hang { get; set; }
        public float Gia { get; set; }

        public RAM()
        {

        }

        public RAM(string text)
        {
            string[] str = text.Split(';');
            Hang = str[0];
            Gia = float.Parse(str[1]);
            dungLuong = float.Parse(str[2]);
        }

        public RAM(string hang, float gia, float dungLuong)
        {
            this.dungLuong = dungLuong;
        }

        public float GiaBan()
        {
            return this.Gia;
        }

        public override string ToString()
        {
            return string.Format("RAM: hang {0}, gia {1}, dung luong {2}GB", Hang, Gia, dungLuong);
        }
    }
}
