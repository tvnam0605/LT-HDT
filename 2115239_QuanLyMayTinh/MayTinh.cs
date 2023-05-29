using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2115239_QuanLyMayTinh
{
    public class MayTinh
    {
        public string MaMay;
        public List<iLinhKien> DanhSachLinhKien = new List<iLinhKien>();

        public MayTinh(string maMay)
        {
            this.MaMay = maMay;
        }

        public MayTinh(string maMay, string text)
        {
            this.MaMay = maMay;
            string[] str = text.Split(',');
            foreach (var linhKien in str)
            {
                if (linhKien.Contains("CPU:"))
                    Them(new CPU(linhKien));
                else if (linhKien.Contains("RAM:"))
                    Them(new RAM(linhKien));
            }
        }

        public void Them(iLinhKien linhKien)
        {
            DanhSachLinhKien.Add(linhKien);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("May tinh co ma " + MaMay + ". Danh sach linh kien:");
            int i = 1;
            foreach (var linhKien in DanhSachLinhKien)
            {
                sb.AppendLine(String.Format("\t{0}. {1}", i, linhKien));
                i++;
            }
            return sb.ToString();
        }

        public bool CoRAMSamSung()
        {
            foreach (var linhKien in DanhSachLinhKien)
            {
                if (linhKien is RAM && linhKien.Hang.Equals("Samsung", StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
        public float TinhTien()
        {
            float Gia = 0;
            foreach (iLinhKien lk in DanhSachLinhKien)
            {
                Gia += lk.Gia;
            }
            return Gia;
        }
        public float TinhGiaCPU()
        {
            float Gia = 0;
            foreach (iLinhKien lk in DanhSachLinhKien)
            {
                if (lk is CPU)
                    Gia += lk.Gia;
            }
            return Gia;
        }
      
        public float TinhDungLuongRam()
        {
            float dungluong = 0;
            foreach (var linhKien in DanhSachLinhKien)
            {
                if (linhKien is RAM)
                    dungluong += ((RAM)linhKien).dungLuong;
            }
            return dungluong;
        }
       public float DemSoLuongCPU1May()
       {
            float soLuong = 0;
            foreach (var linhKien in DanhSachLinhKien)
            {
                if (linhKien is CPU)
                    soLuong++;
            }
            return soLuong;
       }
        public int DemTheoHang(string hang)
        {
            int dem = 0;
            foreach (var item in DanhSachLinhKien)
            {
                if (item.Hang == hang) dem++;
            }
            return dem;
        }

        public List<string> TimDanhSachHang()
        {
            List<string> kq = new List<string>();
            foreach (var item in DanhSachLinhKien)
            {
                kq.Add(item.Hang);
            }
            return kq;
        }
        public int TimSoLuongLinhKienHangDungTrong1MT(string tenHang)
        {
            int soLuong = 0;
            foreach (var item in DanhSachLinhKien)
            {
                if (string.Compare(item.Hang, tenHang, true) == 0)
                    soLuong++;
            }
            return soLuong;
        }
    }
}
