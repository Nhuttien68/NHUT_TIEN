using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1
{
    struct NhanVien
    {
        public string maNhanVien;
        public string hoDem;
        public string ten;
        public DateTime ngaySinh;
        public DateTime ngayVaoLam;
    }
    internal class Program
    {
        static NhanVien[] NhapDanhSachNhanVien(int N)
        {
            NhanVien[] danhSachNV = new NhanVien[N];
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Nhap thong tin nhan vien thu" + (i + 1));
                Console.Write("Ma nhan vien: ");
                danhSachNV[i].maNhanVien = Console.ReadLine();
                Console.Write("Ho dem: ");
                danhSachNV[i].hoDem = Console.ReadLine();
                Console.Write("Ten: ");
                danhSachNV[i].ten = Console.ReadLine();

                while (true)
                {
                    Console.Write("Ngay sinh (dd/MM/yyyy): ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ngaySinh) && ngaySinh < DateTime.Today)
                    {     
                        if(ngaySinh < DateTime.Today.AddYears(-18))
                        {
                            danhSachNV[i].ngaySinh = ngaySinh;
                             break;
                        }
                        else
                        {
                            Console.WriteLine("Nhan vien chua du 18 tuoi!!!!");
                        }
                            
                    }
                    else
                    {
                        Console.WriteLine("Ngay sinh khong hop le. Vui long nhap lai.");
                    }
                }

                while (true)
                {
                    Console.Write("Ngay vao lam (dd/MM/yyyy): ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ngayVaoLam) && ngayVaoLam < DateTime.Today && ngayVaoLam > danhSachNV[i].ngaySinh)
                    {
                        danhSachNV[i].ngayVaoLam = ngayVaoLam;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ngay vao lam khong hop le. Vui long nhap lai.");
                    }
                }
            }
            return danhSachNV;
        }

        static void HienThiDanhSachNhanVien(NhanVien[] danhSachNV)
        {
            Console.WriteLine("\nDanh sach nhan vien:");
            for (int i = 0; i < danhSachNV.Length; i++)
            {
                Console.WriteLine("Nhan vien "+(i + 1));
                Console.WriteLine("Ma NV : " + (danhSachNV[i].maNhanVien));
                Console.WriteLine("Ho ten :" + (danhSachNV[i].hoDem) + (danhSachNV[i].ten));
                Console.WriteLine("Ngay sinh : "+(danhSachNV[i].ngaySinh.ToString("dd/MM/yyyy")));
                Console.WriteLine("Ngay vao lam: "+(danhSachNV[i].ngayVaoLam.ToString("dd/MM/yyyy")));
                Console.WriteLine();
            }
        }

        static void SapXepTheoNgaySinhGiamDan(NhanVien[] danhSachNV)
        {
            int n = danhSachNV.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (danhSachNV[j].ngaySinh > danhSachNV[maxIndex].ngaySinh)
                    {
                        maxIndex = j;
                    }
                }
                if (maxIndex != i)
                {
                    NhanVien temp = danhSachNV[i];
                    danhSachNV[i] = danhSachNV[maxIndex];
                    danhSachNV[maxIndex] = temp;
                }
            }
        }

        static void InNhanVienCoSoNamLamViecLonHonBang(NhanVien[] danhSachNV, int soNam)
        {
            Console.WriteLine("\nDanh sach nhan vien co so nam lam viec >=" +soNam+":");
            for (int i = 0; i < danhSachNV.Length; i++)
            {
                if ((DateTime.Now - danhSachNV[i].ngayVaoLam).TotalDays / 365 >= soNam)
                {
                    Console.WriteLine("Nhan vien "+(i + 1)+":");
                    Console.WriteLine("Ma NV:" + (danhSachNV[i].maNhanVien));
                    Console.WriteLine("Ho ten:" + (danhSachNV[i].hoDem + danhSachNV[i].ten));
                    Console.WriteLine("Ngay sinh:" + (danhSachNV[i].ngaySinh.ToString("dd/MM/yyyy")));
                    Console.WriteLine("Ngay vao lam:"+ (danhSachNV[i].ngayVaoLam.ToString("dd/MM/yyyy")));
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            NhanVien[] danhSachNV = null;
            int soLuongNhanien = 0;

            while (true)
            {
                Console.WriteLine("\nMENU:");
                Console.WriteLine("1. Nhap danh sach nhan vien");
                Console.WriteLine("2. Hien thi danh sach nhan vien");
                Console.WriteLine("3. Sap xep theo ngay sinh giam dan");
                Console.WriteLine("4. In danh sach nhan vien co so nam lam viec >= 5");
                Console.WriteLine("5. Thoat chuong trinh");

                Console.Write("Nhap lua chon cua ban: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            Console.Write("Nhap so luong nhan vien: ");
                        if( int.TryParse(Console.ReadLine(), out soLuongNhanien) && soLuongNhanien > 0 && soLuongNhanien < int.MaxValue)
                        {
                            danhSachNV = NhapDanhSachNhanVien(soLuongNhanien);
                                break;
                        }
                        else
                        {
                            Console.WriteLine("So luong nhan vien khong phù hop, moi nhap lai!!!");
                        }                 
                        }
                        break;
                    case 2:
                        if (danhSachNV != null)
                            HienThiDanhSachNhanVien(danhSachNV);
                        else
                            Console.WriteLine("Danh sach nhan vien chua duoc nhap.");
                        break;
                    case 3:
                        if (danhSachNV != null)
                        {
                            SapXepTheoNgaySinhGiamDan(danhSachNV);
                            Console.WriteLine("Danh sach nhan vien sau khi sap xep la");
                            HienThiDanhSachNhanVien(danhSachNV);
                        }
                        else
                        {
                            Console.WriteLine("Danh sach nhan vien chua duoc nhap.");
                        }
                        break;
                    case 4:
                        if (danhSachNV != null)
                            InNhanVienCoSoNamLamViecLonHonBang(danhSachNV,5);
                        else
                            Console.WriteLine("Danh sach nhan vien chua duoc nhap.");
                        break;
                    case 5:
                        Console.WriteLine("Chuong trinh ket thuc.");
                        return;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                        break;
                }
            }
        }
    }  
}

