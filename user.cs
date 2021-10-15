using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public class Nasabah
    {
        //bikin class dan konstruktor untuk objek nasabah
        public string namaNasabah;
        public string idNasabah;
        public string passwordNasabah;
        protected float saldoNasabah;
        public float biayaTransaksi;

        public float SaldoNasabah
        { 
            get { return saldoNasabah; } 
            set { saldoNasabah = saldoNasabah + value; }
        }

        public virtual void Welcome()
        { Console.WriteLine($"Selamat datang {namaNasabah}, nikmati layanan kami sebagai nasabah reguler"); }

        public Nasabah(string namaNasabah, string idNasabah, string passwordNasabah, float saldoNasabah = 0f)
        {
            this.namaNasabah = namaNasabah;
            this.idNasabah = idNasabah;
            this.passwordNasabah = passwordNasabah;
            this.saldoNasabah = saldoNasabah;
            this.biayaTransaksi = 6500f;
        }
    }

    public class NasabahPrioritas : Nasabah
    {
        public NasabahPrioritas(string namaNasabah, string idNasabah, string passwordNasabah, float saldoNasabah) : base(namaNasabah, idNasabah, passwordNasabah, saldoNasabah)
        { this.biayaTransaksi = 0;   }
        public override void Welcome()
        { 
            Console.WriteLine($"Selamat datang {namaNasabah}");
            Console.WriteLine("nikmati layanan gratis biaya transaksi dengan status anda sebagai nasabah prioritas");
        }

    }
}
