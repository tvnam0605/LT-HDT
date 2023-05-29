using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2115239_QuanLyMayTinh
{
    class Program
    {
        public static void XuatMenu()
        {
            Console.WriteLine("0.	Thoát khỏi chương trình");
            Console.WriteLine("1.	Nhập dữ liệu từ tập tin");
            Console.WriteLine("2.	Xuất dữ liệu");
            Console.WriteLine("3.	Tìm tất cả máy tính có giá cao nhất, giá CPU thấp nhất");
            Console.WriteLine("4.	Tìm tất cả máy tính có RAM có dung lượng cao nhất");
            Console.WriteLine("5.	Tìm hãng có nhiều linh kiện nhất");
            Console.WriteLine("6.	Tìm máy tính có giá cao nhất, thấp nhất");
            Console.WriteLine("7.	Tìm máy tính sử dụng 2 CPU");
            Console.WriteLine("8.	Tìm số lượng linh kiện được sử dụng của hãng bất kỳ");
            Console.WriteLine("9.	Sắp xếp danh sách máy tính theo chiều tăng, giảm của giá máy tính, số lượng CPU, số lượng Ram");
            Console.WriteLine("10.	Xóa tất cả máy tính có dung lượng RAM là x");
            Console.WriteLine("11.	Đếm số lượng CPU, RAM được sử dụng");
            Console.WriteLine("12.	Hiển thị các hãng theo chiều tăng, giảm của số lượng thiết bị được sử dụng");
            Console.WriteLine("13.	Sử dụng enum tạo thực đơn cho các yêu câu trên");
        }

        public enum Menu
        {
            Thoat,
            Nhap,
            Xuat,
            Tim_MT_CaoNhat_CPU_ThapNhat,
            Tim_MT_RAM_NhieuNhat,
            Tim_Hang_LK_NhieuNhat,
            Tim_MT_Gia_CaoNhat_ThapNhat,
            Tim_MT_Dung2CPU,
            Tim_SL_LK_DC_SD_HangBatKy,
            SapGia_Tang_Giam
              
            //...
        }

        public static int ChonMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine(new string('=', 50));
                XuatMenu();
                Console.WriteLine(new string('=', 50));
                Console.Write("Nhập số thứ tự chức năng: ");
                int menu = int.Parse(Console.ReadLine());
                if (0 <= menu && menu <= 13)
                    return menu;
            }
        }

        public static void XuLyMenu(Menu menu, DanhSachMayTinh danhSachMayTinh)
        {
            string chuoi1;
            Console.Clear();
            switch (menu)
            {
                case Menu.Thoat:
                    break;
                case Menu.Nhap:
                    Console.WriteLine("Nhap tu file");
                    danhSachMayTinh.NhapTuFile("dulieu.csv");
                    Console.WriteLine("Doc thanh cong ");
                    //.. Doc thanh cong???
                    break;
                case Menu.Xuat:
                    Console.WriteLine("Xuat Danh sach vua nhap");
                    Console.WriteLine(danhSachMayTinh);
                    break;
                case Menu.Tim_MT_CaoNhat_CPU_ThapNhat:
                    Console.WriteLine("Danh sach may tinh co gia cao nhat:");
                    Console.WriteLine(danhSachMayTinh.TimMayTinhGiaCaoNhat());
                    Console.WriteLine("Danh sach may tinh co gia CPU thap nhat:");
                    Console.WriteLine(danhSachMayTinh.TimCacMayTinhGiaCPUMin());
                    break;
                case Menu.Tim_MT_RAM_NhieuNhat:
                    Console.WriteLine("Danh sach may tinh co dung luong RAM nhieu nhat");
                    Console.WriteLine(danhSachMayTinh.TimMayTinhDungLuongRam_Max());
                    break;
                case Menu.Tim_Hang_LK_NhieuNhat:
                    Console.WriteLine("Tim Hang nhieu linh kien nhat ");
                    
                    foreach (string s in danhSachMayTinh.TimHangSXNhieuNhat())
                        Console.WriteLine(s + " so lan " + danhSachMayTinh.DemThietBiTheoHang(s));
                   

                    break;

                case Menu.Tim_MT_Gia_CaoNhat_ThapNhat:
                    Console.WriteLine("May tinh gia cao nhat");
                    Console.WriteLine(danhSachMayTinh.TimMayTinhGiaCaoNhat());
                    Console.WriteLine("May tinh gia thap nhat");
                    Console.WriteLine(danhSachMayTinh.TimMayTinhGiaThapNhat());
                    break;
                case Menu.Tim_MT_Dung2CPU:
                    Console.WriteLine("May Tinh dung 2 CPu");
                    Console.WriteLine(danhSachMayTinh.Tim_MT_Dung_2CPU());
                    break;
                case Menu.Tim_SL_LK_DC_SD_HangBatKy:
                    Console.WriteLine("Tim so luong linh kien duoc su dung cua hang bat ky");
                    Console.Write("Nhap ten hang muon tim kiem: ");
                    chuoi1 = Console.ReadLine();
                    if (danhSachMayTinh.TinhSoLKCuaHangDuocSuDung(chuoi1)==0)
                        Console.WriteLine("Khong tim thay linh kien hang {0}", chuoi1);
                    Console.WriteLine("So luong linh kien cua hang {0} duoc su dung {1}: ",chuoi1, danhSachMayTinh.TinhSoLKCuaHangDuocSuDung(chuoi1));
                    break;
                case Menu.SapGia_Tang_Giam:
                    Console.WriteLine("Danh sach ban dau: ");
                    Console.WriteLine(danhSachMayTinh);
                    Console.WriteLine(" Danh sach sap tang theo gia: ");
                     danhSachMayTinh.SapTangGia();
                    Console.WriteLine("Danh sach sap giam theo gia: ");
                    danhSachMayTinh.SapGiamGia();

                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }

        public static void Main(string[] args)
        {
            DanhSachMayTinh ds = new DanhSachMayTinh();
            do
            {
                int menu = ChonMenu();
                XuLyMenu((Menu)menu, ds);
                if (menu == 0)
                    return;
            } while (true);
            Console.ReadKey();
        }
    }
}
