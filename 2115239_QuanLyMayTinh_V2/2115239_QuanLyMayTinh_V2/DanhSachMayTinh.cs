using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _2115239_QuanLyMayTinh_V2
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
        public void Xoa(MayTinh mayTinh)
        {
            DanhSach.Remove(mayTinh);
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
        int DemMainBoardTheoNuoc(string nuoc)
        {
            int kq = 0;
            foreach (var item in DanhSach)
            {
                kq += item.DemMainBoardTheoNuoc(nuoc);
            }
            return kq;
        }
        public DanhSachMayTinh TimTatCaMTSDMainBoardNuocX(string nuoc)
        {
            DanhSachMayTinh kq = new DanhSachMayTinh();
            for (int i = 0; i < DanhSach.Count; i++)
                if (DanhSach[i].LayTenNuocSXMainBoard().Contains(nuoc))
                    kq.Them(DanhSach[i]);
            return kq;
        }
        List<string> LayDSPhanBiet(List<string> x)
        {
            List<string> kq = new List<string>();
            for (int i = 0; i < x.Count; i++)
                if ((kq.Contains(x[i])) == false)
                    kq.Add(x[i]);
            return kq;
        }
        List<string> LayTenNuocSX()
        {
            List<string> kq = new List<string>();
            foreach (var item in DanhSach)
                kq.Add(item.LayTenNuocSXMainBoard());
            return kq;
        }
        public List<string> TimNuocCoSoLuongMainBoardLaX(int x)
        {
            List<string> kq = new List<string>();
            int count = 0;
            List<string> nuoc = LayDSPhanBiet(LayTenNuocSX());
            for (int i = 0; i < nuoc.Count; i++)
            {
                count = DemMainBoardTheoNuoc(nuoc[i]);
                if (count == x)
                    kq.Add(nuoc[i]);
            }
            return kq;
        }
        public bool IsEmTyListStr(List<string> x)
        {
            if (x.Count == 0)
                return true;
            return false;
        }
        int TimSoMainBoardMaxTheoNuocSX()
        {
            int max = 0;
            List<string> nuoc = LayDSPhanBiet(LayTenNuocSX());
            max = DemMainBoardTheoNuoc(nuoc[0]);
            for (int i = 1; i < nuoc.Count; i++)
            {
                int count = DemMainBoardTheoNuoc(nuoc[1]);
                if (count > max)
                    max = count;
            }
            return max;
        }
        public List<string> TimNuocSXNhieuMainBoardNhat()
        {
            List<string> kq = new List<string>();
            int max = TimSoMainBoardMaxTheoNuocSX();
            List<string> nuoc = LayDSPhanBiet(LayTenNuocSX());
            for (int i = 0; i < nuoc.Count; i++)
            {
                if (DemMainBoardTheoNuoc(nuoc[i]) == max)
                    kq.Add(nuoc[i]);
            }
            return kq;
        }
        public DanhSachMayTinh TimTatCaMayTInhSDMainBoardNuocX(string nuoc)
        {
            DanhSachMayTinh kq = new DanhSachMayTinh();
            for (int i = 0; i < DanhSach.Count; i++)
                if (DanhSach[i].LayTenNuocSXMainBoard().Contains(nuoc) == true)
                    kq.Them(DanhSach[i]);
            return kq;
        }
       
        public bool IsEmptyCollection()
        {
            if (DanhSach.Count == 0)
                return true;
            return false;
        }
        public DanhSachMayTinh TimTatCaMayTinhKhongSDMainBoardNuocX(string nuoc)
        {
            DanhSachMayTinh kq = new DanhSachMayTinh();
            for (int i = 0; i < DanhSach.Count; i++)
                if (DanhSach[i].LayTenNuocSXMainBoard().Contains(nuoc) == false)
                    kq.Them(DanhSach[i]);
            return kq;
        }
        public void XoaALLMayTinhSDMainBoardX(string nuoc)
        {
            for (int i = 0; i < DanhSach.Count; i++)
            {
                if (DanhSach[i].LayTenNuocSXMainBoard().Contains(nuoc))
                {
                    DanhSach.RemoveAt(i);
                    i--;
                }
            }
        }
        public List<int> TimVTMTSDMainBoardSXTaiX(string nuoc)
        {
            List<int> kq = new List<int>();
            for (int i = 0; i < DanhSach.Count; i++)
                if (DanhSach[i].LayTenNuocSXMainBoard().Contains(nuoc))
                    kq.Add(i+1);
            return kq;
        }
        public bool IsEmpTyListInt(List<int> x)
        {
            if (x.Count == 0)
                return true;
            return false;
        }
        //===========================================================
        int TimSoMainBoardItNhatCuaHangTheoNuoc(string n)
        {
            int min = int.MaxValue;
            List<string> hangMB = TimHangMainBoardTheoNuoc(n);
            for (int i =0; i<hangMB.Count; i++)
            {
                int count = DemMainBoardHangTheoNuocY(n, hangMB[i]);
                if (count < min)
                    min = count;
                    
            }
            return min;
        }
        int DemMainBoardHangTheoNuocY(string n, string h)
        {
            int kq = 0;
            for (int i = 0; i < DanhSach.Count; i++)
                if (DanhSach[i].LayTenNuocSXMainBoard().Contains(n) && (DanhSach[i].LayTenNuocSXMainBoard().Contains(h)))
                    kq++;
            return kq;
        }
        List<string> TimHangMainBoardTheoNuoc(string n)
        {
            List<string> kq = new List<string>();
            foreach (var item in DanhSach)
                if (item.LayTenNuocSXMainBoard().Contains(n))
                    kq.Add(item.TimHangCuaMainBoard());
            return kq;
        }
        public List<string> TimHangCoSoMainBoardItNhatTheoNuocSX(string n)
        {
            List<string> kq = new List<string>();
            List<string> hangMB = TimHangMainBoardTheoNuoc(n);
            int min = TimSoMainBoardItNhatCuaHangTheoNuoc(n);
            for (int i=0; i<hangMB.Count; i++)
            {
                int count = DemMainBoardHangTheoNuocY(n, hangMB[i]);
                if (count == min)
                    kq.Add(hangMB[i]);
            }
            kq = LayDSPhanBiet(kq);
            return kq;
        } 
        //max
        public List<string> TimHangCoSoMainBoardNhieuNhatTheoNuocSX(string n)
        {
            List<string> kq = new List<string>();
            List<string> hangMB = TimHangMainBoardTheoNuoc(n);
            int max = TimSoMainBoardNhieuNhatCuaHangTheoNuoc(n);
            for (int i=0; i<hangMB.Count; i++)
            {
                int count = DemMainBoardHangTheoNuocY(n, hangMB[i]);
                if (count == max)
                    kq.Add(hangMB[i]);
            }
            kq = LayDSPhanBiet(kq);
            return kq;
        }
        int TimSoMainBoardNhieuNhatCuaHangTheoNuoc(string n)
        {
            int max = 0;
            List<string> hangMB = TimHangMainBoardTheoNuoc(n);
            for (int i=0; i< hangMB.Count; i++)
            {
                int count = DemMainBoardHangTheoNuocY(n, hangMB[i]);
                if (count > max)
                    max = count;
            }
            return max;
        }    
        public float TinhTongGiaBanMainBoardTheoNuoc(string n)
        {
            float kq = 0;
            for (int i = 0; i < DanhSach.Count; i++)
                if (DanhSach[i].LayTenNuocSXMainBoard().Contains(n))
                    kq += DanhSach[i].giaMT();
            return kq;
        }
    }
}
