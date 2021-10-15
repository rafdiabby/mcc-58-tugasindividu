using System;
using System.Collections.Generic;

namespace BankSystem
{
     class Program
    {
        static void Main(string[] args)
        {
            List<Nasabah> dataNasabah = new List<Nasabah>();
            Initiate(dataNasabah);
            int menu;
            bool exit = false;
            do
            {
                Menu(out menu);
                switch (menu)
                {
                    case 1: MenuLogin(dataNasabah);break;
                    case 2: Registrasi(dataNasabah);break;
                    case 3: exit = true; break;
                }

            } while (exit==false);
            Console.Clear();
        }

        public static void Initiate(List<Nasabah> dataNasabah)
        {
            dataNasabah.Add(new Nasabah("Budi Sujono", "BS001", "123456", 100000f));
            dataNasabah.Add(new Nasabah("Asep Sukirno", "AS002", "234567", 430000f));
            dataNasabah.Add(new Nasabah("Cecep Supriatna", "CS003", "345678", 3000000f));
            dataNasabah.Add(new Nasabah("Admin", "admin", "admin", 100000000f));

        }
        public static void Menu(out int menu)
        {
            //menampilkan menu utama program
            Console.WriteLine("+++++++++++++++++++++++++");
            Console.WriteLine("Selamat datang di e-banking");
            Console.WriteLine("+++++++++++++++++++++++++");
            Console.WriteLine("Pilih menu yang ingin diakses :");
            Console.WriteLine(" 1. Login e-banking");
            Console.WriteLine(" 2. Registrasi e-banking");
            Console.WriteLine(" 3. Keluar");
            Console.WriteLine("");
            Console.Write("Silahkan ketik menu yang diinginkan lalu tekan enter...  ");
            //menu = int.Parse(Console.ReadLine());
            menu = 0;
            try
            {
                menu = Convert.ToInt32(Console.ReadLine());
                if (menu > 3)
                {
                    throw new FormatException();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Silahkan pilih menu dari 1 hingga 3.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public static void MenuLogin(List<Nasabah> dataNasabah)
        {
            Console.Clear();
            Console.WriteLine("Silahkan masukkan user ID dan password anda...");
            Console.Write("User ID  : ");
            string userId = Console.ReadLine();
            Console.Write("Password : ");
            string password = Console.ReadLine();
            int id = 0;

            foreach (var data in dataNasabah)
            {
                
                if (userId == data.idNasabah)
                {
                    if (BCrypt.Net.BCrypt.Verify(password, data.passwordNasabah))
                    {
                        Transaksi(dataNasabah, id);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Password salah, silahkan ulangi");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    
                }
                else if (id == dataNasabah.Count - 1)
                {
                    Console.WriteLine("Data nasabah tidak ditemukan, kembali ke menu utama");
                    Console.ReadLine();
                    Console.Clear();
                }
                id += 1;
               
            }
        }

        public static void Transaksi(List<Nasabah> dataNasabah, int id)
        {
            bool exitTransaksi = false;
            do
            {
                Console.Clear();
                Console.WriteLine("+++++++++++++++");
                Console.WriteLine("Pilih menu transaksi :");
                Console.WriteLine(" 1. Tarik Tunai");
                Console.WriteLine(" 2. Setor Tunai");
                Console.WriteLine(" 3. Cek Saldo");
                Console.WriteLine(" 4. Selesai Transaksi");
                Console.Write(" Silahkan ketikkan angka menu transaksi... ");
                int menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1: TarikTunai(dataNasabah, id); break;
                    case 2: SetorTunai(dataNasabah, id); break;
                    case 3: CekSaldo(dataNasabah, id); break;
                    case 4: exitTransaksi = true; Console.Clear(); break;
                }

            } while (exitTransaksi == false);
        }

        public static void TarikTunai(List<Nasabah> dataNasabah, int id)
        {
            Console.Clear();
            Console.WriteLine("Masukkan jumlah uang yang akan ditarik.. ");
            float jumlah = float.Parse(Console.ReadLine());
            //cek apakah saldo mencukupi

            if (jumlah <= dataNasabah[id].SaldoNasabah)
            {
                dataNasabah[id].SaldoNasabah = -jumlah;
                Console.WriteLine("Transaksi berhasil, sisa saldo anda adalah :");
                Console.WriteLine("************");
                Console.WriteLine($" Rp. {String.Format("{0:n0}", dataNasabah[id].SaldoNasabah)}");
                Console.WriteLine("************");
                Console.WriteLine("Tekan enter untuk kembali ke menu utama...");
                Console.ReadLine();
                Console.Clear();

            }
            else
            {
                Console.WriteLine("Maaf saldo anda tidak cukup, kembali ke menu utama...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public static void SetorTunai(List<Nasabah> dataNasabah, int id)
        {
            Console.Clear();
            Console.WriteLine("Masukkan jumlah uang yang akan disetor.. ");
            float jumlah = float.Parse(Console.ReadLine());
                       
            dataNasabah[id].SaldoNasabah = jumlah;
            Console.WriteLine("Transaksi berhasil, saldo anda sekarang adalah :");
            Console.WriteLine("************");
            Console.WriteLine($" Rp. {String.Format("{0:n0}", dataNasabah[id].SaldoNasabah)}");
            Console.WriteLine("************");
            Console.WriteLine("Tekan enter untuk kembali ke menu utama...");
            Console.ReadLine();
            Console.Clear();

        }

        public static void CekSaldo(List<Nasabah> dataNasabah, int id)
        {
            Console.Clear();
            Console.WriteLine("Saldo anda sekarang adalah :");
            Console.WriteLine("************");
            Console.WriteLine($" Rp. {String.Format("{0:n0}", dataNasabah[id].SaldoNasabah)}");
            Console.WriteLine("************");
            Console.WriteLine("Tekan enter untuk kembali ke menu utama...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void Registrasi(List<Nasabah> dataNasabah)
        {
            Console.Clear();
            Console.WriteLine("Silahkan masukkan data yang dibutuhkan seperti pada form berikut :");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.Write($"Nama lengkap         : ");
            string tempNama = Console.ReadLine();
            Console.Write($"User ID              : ");
            string tempId = Console.ReadLine();
            string tempPass;
            string confirmPass
            //Console.Write("Password             :");
            //string tempPass = Console.ReadLine();
            //Console.Write("Konfirmasi Password  :");
            //string confirmPass = Console.ReadLine();

            bool passwordOk = false;
            //if (tempPass == confirmPass)
            //{
            //    passwordOk = true;
            //}
            //else
            //{ passwordOk = false; }

            while (passwordOk = false)
            {
                Console.Clear();
                Console.WriteLine("Silahkan masukkan data yang dibutuhkan seperti pada form berikut :");
                Console.WriteLine("-------------------------------------------------------------------");
                Console.Write($"Nama lengkap         : {tempNama}");
                Console.Write($"User ID              : {tempId}");
                Console.Write("Password             :");
                string tempPass = Console.ReadLine();
                Console.Write("Konfirmasi Password  :");
                string confirmPass = Console.ReadLine();

                bool passwordOk = false;
                if (tempPass == confirmPass)
                {
                    passwordOk = true;
                }
                else
                { passwordOk = false; }
            }
            //if (Console.ReadLine() == tempPass))
            //{

            //}

            dataNasabah.Add(new Nasabah(tempNama, tempId, tempPass));
            Console.WriteLine("Data berhasil diregistrasi, silahkan login untuk bertransaksi");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
