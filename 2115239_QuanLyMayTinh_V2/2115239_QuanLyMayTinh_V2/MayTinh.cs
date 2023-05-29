using System;
using System.Collections.Generic;
using System.Text;

namespace _2115239_QuanLyMayTinh_V2
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
                if (linhKien.Contains("MainBoard:"))
                    Them(new MainBoard(linhKien));
            }
        }
        public float giaMT()
        {
            float gia = 0;
            foreach (var item in DanhSachLinhKien)
            {
                gia += item.GiaBan();
            }
            return gia;
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
        public float DemMainBoard()
        {
            float dem = 0;
            foreach (var item in DanhSachLinhKien)
            {
                if (item is MainBoard)
                    dem++;
            }
            return dem;
        }
        public string TimHangCuaMainBoard()
        {
            string kq = "";
            foreach (var item in DanhSachLinhKien)
                if (item is MainBoard)
                {
                    kq += ((MainBoard)item).Hang;
                    if (kq.Contains(((MainBoard)item).Hang))
                        break;
                }
            return kq;
        }
        public int DemMainBoardTheoNuoc(string nSX)
        {
            int kq = 0;
            foreach (var item in DanhSachLinhKien)
            {
                if (item is MainBoard && (((MainBoard)item).nuocSX).Contains(nSX))
                    kq++;
            }
            return kq;
        }
        public string LayTenNuocSXMainBoard()
        {
            string kq = "";
            foreach (var item in DanhSachLinhKien)
            {
                if (item is MainBoard)
                    kq += (((MainBoard)item).nuocSX);
            }
            return kq;
        }
    }
}
    
