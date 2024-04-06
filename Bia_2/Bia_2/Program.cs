using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bia_2
{

    struct Product
    {
        public string ProductName;
        public double ProductPrice;
        public DateTime ExpiredDate;

        public int DaysUntilExpired()
        {
            TimeSpan timeUntilExpired = ExpiredDate - DateTime.Today;
            return (int)timeUntilExpired.TotalDays;
        }
    }
    internal class Program
    {
        static Product[] NhapThongTinSanPham(int N)
        {
            Product[] products = new Product[N];
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("\nNhap thong tin san pham thu :"+ (i + 1));
                Console.Write("Ten san pham: ");
                string productName = Console.ReadLine();

                Console.Write("Gia san pham: ");
                double productPrice = double.Parse(Console.ReadLine());

                Console.Write("Ngay het han (dd/MM/yyyy): ");
                DateTime expiredDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                products[i] = new Product
                {
                    ProductName = productName,
                    ProductPrice = productPrice,
                    ExpiredDate = expiredDate
                };
            }
            return products;
        }

        static void HienThiSanPhamHetHanTrong30Ngay(Product[] products)
        {
            Console.WriteLine("\nCac san pham co ngay het han trong vong 30 ngay:");
            foreach (var product in products)
            {
                int daysUntilExpired = product.DaysUntilExpired();
                if (daysUntilExpired <= 30)
                {
                    Console.WriteLine("Ten:" + (product.ProductName) + " Gia:" + (product.ProductPrice) + " Ngay het han: " + (product.ExpiredDate.ToString("dd/MM/yyyy")));
                }
            }
        }

        static void HienThiSanPhamCoTenDaiHon10KyTu(Product[] products)
        {
            Console.WriteLine("\nCac san pham co ten dai hon 10 ky tu:");
            foreach (var product in products)
            {
                if (product.ProductName.Length > 10)
                {
                    Console.WriteLine("Ten:" + (product.ProductName)+" Gia:"+ (product.ProductPrice)+" Ngay het han: "+(product.ExpiredDate.ToString("dd/MM/yyyy")));
                }
            }
        }

        static void Main(string[] args)
        {
            Product[] products = null;
            int numbeOfProduct = 0;
            while (true)
            {
                Console.WriteLine("\nMENU:");
                Console.WriteLine("1. Nhap thong tin san pham");
                Console.WriteLine("2. Hien thi cac san pham co ngay het han trong vong 30 ngay");
                Console.WriteLine("3. Hien thi cac san pham co ten dai hon 10 ky tu");
                Console.WriteLine("4. Thoat chuong trinh");

                Console.Write("Nhap lua chon cua ban: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            Console.Write("Nhap so luong san pham: ");
                            if (int.TryParse(Console.ReadLine(), out numbeOfProduct) && numbeOfProduct > 0 && numbeOfProduct < int.MaxValue)
                            {
                                products = NhapThongTinSanPham(numbeOfProduct);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("So luong san pham khong hop le moi ban nhap lai!!!");
                            }
                        }
                        break;
                    case 2:
                        if (products != null)
                            HienThiSanPhamHetHanTrong30Ngay(products);
                        else
                            Console.WriteLine("Danh sach san pham chua duoc nhap.");
                        break;
                    case 3:
                        if (products != null)
                            HienThiSanPhamCoTenDaiHon10KyTu(products);
                        else
                            Console.WriteLine("Danh sach san pham chua duoc nhap.");
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

