using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _2115239_QuanLyMayTinh_V2
{
    class Program
    {
        public static void XuatMenu()
        {
            Console.WriteLine("0.   Thoat khoi chuong trinh");
            Console.WriteLine("1.   Nhap tu file");
            Console.WriteLine("2.   Xem du lieu");
            Console.WriteLine("3.	Tìm nước có số lượng MainBoard là x");
            Console.WriteLine("4.	Tìm nước sản xuất nhiều MainBoard n");
            Console.WriteLine("5.	Tìm tất cả máy tính sử dụng MainBoax");
            Console.WriteLine("6.	Tìm tất cả máy tính không sử dụng MainBoard x");
            Console.WriteLine("7.	Xóa tất cả máy tính sử dụng MainBoard x ");
            Console.WriteLine("8.	Tìm vị trí của máy tính sử dụng MainBoard x ");
            Console.WriteLine("9.	Tìm hãng có số lượng sản xuất MainBoard ít nhất theo một nước nào đó.");
            Console.WriteLine("10.	Tìm hãng có số lượng sản xuất MainBoard nhiều nhất theo một nước nào đó.");
            Console.WriteLine("11.	Tính tổng giá trị của máy tính có sụng MainBoard sản xuất tại nước x nào đó");
            

        }
        public enum Menu
        {
            Thoat,
            Nhap,
            Xuat,
            TimNuoc_SL_MainBoard_La_X,
            TimNuocSXNhieuMainBoardNhat,
            TimTatCaMayTinhSDMainBoard,
            TimALLMTKhongSDMainBoardX,
            XoaALLMayTinhSDMainBoard,
            TimVTCuaMTSDMainBoardX,
            TimHangCoSLSXMainItNhatTheoNuocNaoDo,
            TimHangCoSLSXMainNhieuNhatTheoNuocNaoDo,
            TinhTongGiaTriCuaMayTinhCoSDMainBoardSXTaiNuocX
        }
        public static int ChonMenu()
        {
           while(true)
            {
                Console.Clear();
                Console.OutputEncoding = System.Text.Encoding.UTF8;
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
           
            Console.Clear();
            float gia;
            int x;
            string h;
            int dem;
            List<string> listStr = new List<string>();
            DanhSachMayTinh dsmt = new DanhSachMayTinh();
            List<int> listInt = new List<int>();
            switch (menu)
            {
                case Menu.Thoat:
                    Console.WriteLine("0. Thoat khoi chuong trinh");
                    

                    break;
                case Menu.Nhap:
                    Console.WriteLine("1. Nhap tu file");
                    danhSachMayTinh.NhapTuFile("dulieu.csv");
                    Console.WriteLine("Nhap thanh cong");
                    break;
                case Menu.Xuat:
                    Console.WriteLine(danhSachMayTinh);
                    break;
                case Menu.TimNuoc_SL_MainBoard_La_X:
                    Console.WriteLine("Tim nuoc co soluong MainBoard la x");
                    Console.Write("Nhập số MainBoard x = ");
                    x = int.Parse(Console.ReadLine());
                    listStr = danhSachMayTinh.TimNuocCoSoLuongMainBoardLaX(x);
                    if (danhSachMayTinh.IsEmTyListStr(listStr))
                        Console.WriteLine("Không có nước nào có số lượng {0} MainBoard ", x);
                    else
                    {
                        for (int i = 0; i < listStr.Count; i++)
                            Console.WriteLine(listStr[i] + "\n");
                    }
                    break;
                case Menu.TimNuocSXNhieuMainBoardNhat:
                    Console.WriteLine("Tìm nước sản xuất nhiều MainBoard Nhất.");
                    listStr = danhSachMayTinh.TimNuocSXNhieuMainBoardNhat();
                    
                    for (int i = 0; i < listStr.Count; i++)
                        Console.WriteLine(listStr[i] + "\n");
                    break;
                case Menu.TimTatCaMayTinhSDMainBoard:
                    Console.WriteLine(" TÌm tất cả máy tính sử dụng MainBoard của nước x");
                    Console.Write("Nhập nước sản xuất muốn tìm: ");
                    h = Console.ReadLine();
                    dsmt = danhSachMayTinh.TimTatCaMayTInhSDMainBoardNuocX(h);
                    if (dsmt.IsEmptyCollection()) 
                        Console.WriteLine("Không có MainBoard nào được sản xuất tại {0}",h);
                    else
                        Console.WriteLine("Danh sách các máy tính có MainBoard được sản xuất tại {0} là {1} ", h,dsmt);
                    break;
                case Menu.TimALLMTKhongSDMainBoardX:
                    Console.WriteLine("Tìm Tất cả máy tính không sử dung MainBoard của nước X");
                    Console.Write("Nhập nước sản xuất muốn tìm: ");
                    h = Console.ReadLine();
                    dsmt = danhSachMayTinh.TimTatCaMayTinhKhongSDMainBoardNuocX(h);
                    if (dsmt.IsEmptyCollection())
                        Console.WriteLine("KHông có MainBoard nào sản xuất tại nước {0} ", h);
                    else
                        Console.WriteLine("Danh sách máy không sử dụng MainBoard được sản xuất tại {0} la {1}\n ", h,dsmt);
                    break;
                case Menu.XoaALLMayTinhSDMainBoard:
                    Console.WriteLine("Xóa tất cả máy tính có sử dụng MainBoard.");
                    Console.Write("Nhập nước sản xuất MainBoard muốn xóa");
                    h = Console.ReadLine();
                    danhSachMayTinh.XoaALLMayTinhSDMainBoardX(h);
                    Console.WriteLine("Danh sách sau khi xóa máy tính sử dụng MainBoard {0} là {1} ",h,danhSachMayTinh);
                    break;
                case Menu.TimVTCuaMTSDMainBoardX:
                    Console.WriteLine("Tìm vị trí của máy tính sử dụng MainBoard X");
                    Console.Write("Nhập tên nước sản xuất: ");
                    h = Console.ReadLine();
                    listInt = danhSachMayTinh.TimVTMTSDMainBoardSXTaiX(h);
                    if (danhSachMayTinh.IsEmpTyListInt(listInt))
                        Console.WriteLine("\n Không có MainBoard nào sản xuất tại {0} ",h);
                    else
                    {
                        Console.WriteLine("Vị trí các máy tính có MainBoard sản xuất tại {0} là ",h);
                        for (int i =0; i<listInt.Count; i++)
                            Console.WriteLine(listInt[i] + "\t");
                    }

                    break;
                case Menu.TimHangCoSLSXMainItNhatTheoNuocNaoDo:
                    Console.WriteLine("Tìm hãng có số lượng MainBoard ít nhất theo nước nào đó");
                    Console.Write("Nhập nước cần tìm: ");
                    h = Console.ReadLine();
                    listStr = danhSachMayTinh.TimHangCoSoMainBoardItNhatTheoNuocSX(h);
                    for (int i=0; i<listStr.Count; i++)
                        Console.WriteLine(listStr[i] + "\n");
                    break;
                case Menu.TimHangCoSLSXMainNhieuNhatTheoNuocNaoDo:
                    Console.WriteLine("Tìm hãng có số lượng MainBoard nhiều nhất theo nước nào đó");
                    Console.Write("Nhập nước SX: ");
                    h = Console.ReadLine();
                    listStr = danhSachMayTinh.TimHangCoSoMainBoardNhieuNhatTheoNuocSX(h);
                    if (dsmt.IsEmTyListStr(listStr))
                        Console.WriteLine("Không có MainBoard dược sx tại {0}", h);
                    else
                    {
                        for (int i = 0; i < listStr.Count; i++)
                            Console.WriteLine(listStr[i] + "\n");
                    }
                    break;
                case Menu.TinhTongGiaTriCuaMayTinhCoSDMainBoardSXTaiNuocX:
                    Console.Write("Nhập nước SX: ");
                    h = Console.ReadLine();
                    gia = danhSachMayTinh.TinhTongGiaBanMainBoardTheoNuoc(h);
                    Console.Write("Tổng giá máy tính có MainBoard sx tại {0} là: {1}", h, gia);
                    break;
                default:
                    break;
            }
            Console.ReadKey();

        }
        static void Main(string[] args)
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
