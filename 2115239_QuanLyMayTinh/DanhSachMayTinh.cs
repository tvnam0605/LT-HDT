using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace _2115239_QuanLyMayTinh
{
   public class DanhSachMayTinh
    {
        List<MayTinh> DanhSach;

        public DanhSachMayTinh()
        {
            DanhSach = new List<MayTinh>();
        }

        public void Them(MayTinh mayTinh)
        {
            DanhSach.Add(mayTinh);
        }

        public void NhapTuFile(string tenFile)
        {
            StreamReader reader = new StreamReader(tenFile);
            int i = 1;
            string s = "";
            while ((s = reader.ReadLine()) != null)
            {
                MayTinh mayTinh = new MayTinh(i.ToString(), s);
                i++;
                Them(mayTinh);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var mayTinh in DanhSach)
            {
                sb.AppendLine(mayTinh.ToString());
            }
            return sb.ToString();
        }

        public DanhSachMayTinh TimMayTinh_Ram_Samsung()
        {
            DanhSachMayTinh kq = new DanhSachMayTinh();
            foreach (var mayTinh in DanhSach)
            {
                if (mayTinh.CoRAMSamSung())
                    kq.Them(mayTinh);
            }
            return kq;
        }
        public float TimGiaTriCaoNhat()
        {
            float max = DanhSach[0].TinhTien();
            foreach (var mayTinh in DanhSach)
            {
                if (mayTinh.TinhTien() > max) max = mayTinh.TinhTien();

            }
            return max;

        }
        public float TimGiaTriThapNhat()
        {
            float min = DanhSach[0].TinhTien();
            foreach (var mayTinh in DanhSach)
            {
                if (mayTinh.TinhTien() < min) min = mayTinh.TinhTien();

            }
            return min;

        }
        public float TimGiaCPUMin()
        {
            float min = float.MaxValue;
            foreach (var mayTinh in DanhSach)
            {
                if (mayTinh.TinhGiaCPU() < min) min = mayTinh.TinhGiaCPU();

            }
            return min;

        }
        public DanhSachMayTinh TimMayTinhGiaCaoNhat()
        {
            float max = TimGiaTriCaoNhat();
            DanhSachMayTinh kq = new DanhSachMayTinh();
            foreach (var mayTinh in DanhSach)
            {
                if (mayTinh.TinhTien() == max)
                    kq.Them(mayTinh);
            }

            return kq;
        }
        public DanhSachMayTinh TimMayTinhGiaThapNhat()
        {
            float min = TimGiaTriThapNhat();
            DanhSachMayTinh kq = new DanhSachMayTinh();
            foreach (var mayTinh in DanhSach)
            {
                if (mayTinh.TinhTien() == min)
                    kq.Them(mayTinh);
            }

            return kq;
        }
        public DanhSachMayTinh TimCacMayTinhGiaCPUMin()
        {
            float min = TimGiaCPUMin();
            DanhSachMayTinh kq = new DanhSachMayTinh();
            foreach (var mayTinh in DanhSach)
            {
                if (mayTinh.TinhGiaCPU() == min)
                    kq.Them(mayTinh);
            }

            return kq;
        }
        public float TimDungLuongRam_Max()
        {
            float max = DanhSach[0].TinhDungLuongRam();
            foreach (var mayTinh in DanhSach)
            {
                if (mayTinh.TinhDungLuongRam() > max) max = mayTinh.TinhDungLuongRam();

            }
            return max;
        }
       
        public DanhSachMayTinh TimMayTinhDungLuongRam_Max()
        {
            float max = TimDungLuongRam_Max();
            DanhSachMayTinh kq = new DanhSachMayTinh();
            foreach (var mayTinh in DanhSach)
            {
                if (mayTinh.TinhDungLuongRam() == max)
                    kq.Them(mayTinh);
            }

            return kq;
        }
        public float DemCPU()
        {
            float soLuong = 0;
            foreach (var mayTinh in DanhSach)
            {
                soLuong += mayTinh.DemSoLuongCPU1May();
            }
            return soLuong;
        }
        
        public DanhSachMayTinh Tim_MT_Dung_2CPU()
        {
            float temp =DemCPU();
            DanhSachMayTinh kq = new DanhSachMayTinh();
            foreach (var mayTinh in DanhSach)
            {
                if (mayTinh.DemSoLuongCPU1May() == 2)
                kq.Them(mayTinh);
            }
            return kq;
        }
        public int DemThietBiTheoHang(string hang)
        {
            int dem = 0;
            foreach (var item in DanhSach)
            {
                dem += item.DemTheoHang(hang);
            }
            return dem;
        }

        public void ThemDanhSachHang(List<string> kq, List<string> hang)
        {
            foreach (var item in hang)
            {
                if (!kq.Contains(item))
                    kq.Add(item);
            }
        }

        public List<string> TimDanhSachHang()
        {
            List<string> kq = new List<string>();
            foreach (var item in DanhSach)
            {
                ThemDanhSachHang(kq, item.TimDanhSachHang());
            }
            return kq;
        }
        public int TimThietBiNhieuNhat()
        {
            int max = -1;
            List<string> ds = TimDanhSachHang();
            foreach (var item in ds)
            {
                int tam = DemThietBiTheoHang(item);
                if (max < tam)
                    max = tam;
            }
            return max;
        }

        public List<string> TimHangSXNhieuNhat()
        {
            List<string> kq = new List<string>();
            int max = TimThietBiNhieuNhat();
            List<string> ds = TimDanhSachHang();
            foreach (var item in ds)
            {
                int tam = DemThietBiTheoHang(item);
                if (tam == max)
                    kq.Add(item);
            }
            return kq;
        }
        public float TinhSoLKCuaHangDuocSuDung(string tenHang)
        {
            int soLuong = 0;
            foreach (var mayTinh in DanhSach)
            {
                soLuong += mayTinh.TimSoLuongLinhKienHangDungTrong1MT(tenHang);
            }
            return soLuong;
        }
        public enum KieuSapXep
        {
            SapGiaTang,
            SapGiaGiam
        }
        public void SapXep(KieuSapXep k)
        {
            for (int i = 0; i<DanhSach.Count - 1; i++)
                for (int j = i +1; j <DanhSach.Count; j++)
                {
                    if (KiemTraDieuKien(k, DanhSach[i], DanhSach[j]))
                    {
                        MayTinh tmp = DanhSach[i];
                        DanhSach[i] = DanhSach[j];
                        DanhSach[j] = tmp;
                    }
                }
        }
        public bool KiemTraDieuKien (KieuSapXep k, MayTinh a, MayTinh b)
        {
            switch (k)
            {
                case KieuSapXep.SapGiaTang:
                    if (a.TinhTien() > b.TinhTien())
                        return true;
                    break;
                case KieuSapXep.SapGiaGiam:
                    if (a.TinhTien() < b.TinhTien())
                        return true;
                    break;
                default:
                    break;
            }
            return false;
        }
        public void SapTangGia()
        {
            SapXep(KieuSapXep.SapGiaTang);
        }
        public void SapGiamGia()
        {
            SapXep(KieuSapXep.SapGiaGiam);
        }
    }
}
