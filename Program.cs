using System;
using System.Collections.Generic;
using System.Linq;

class MainClass
{
    public static void Main(string[] args)
    {
        MusteriManager musteriManager = new MusteriManager();
        List<Musteri> musteriler = new List<Musteri>();

        byte MenuNumber = 0;

        MusteriManager.MenuSecim(ref MenuNumber);

        while (MenuNumber < 4 && MenuNumber > 0)
        {
            switch (MenuNumber)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Müşteri Listeleme Ekranı\n------------------------\n");
                    musteriManager.MusteriListesi = musteriler;
                    musteriManager.Listele();
                    break;
                case 2:
                    string devam = "E";
                    while (devam == "E")
                    {
                        Console.Clear();
                        Console.WriteLine("Müşteri Giriş Ekranı\n-------------------\n");
                        Musteri musteri = new Musteri();
                        int[] ids = new int[musteriler.Count];
                        for (int i = 0; i < musteriler.Count; i++) { ids[i] = musteriler[i].Id; }
                        musteri.Id = musteriler.Count > 0 ? ids.Max() + 1 : 1;
                        Console.Write("Adı = ");
                        musteri.Adi = Console.ReadLine();
                        Console.Write("Soyadı = ");
                        musteri.SoyAdi = Console.ReadLine();
                        musteriler.Add(musteri);
                        Console.WriteLine("Müşteri Eklendi!\n");
                        Console.Write("Yeni Müşteri Eklemek İster misiniz? E/H :");
                        devam = Console.ReadLine();
                    }

                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Müşteri Silme Ekranı\n--------------------\n");
                    Console.Write("Silmek istediğiniz Müşteri Adını giriniz :");
                    string Adi = Console.ReadLine();
                    Console.Write("Silmek istediğiniz Müşteri Soyadını giriniz :");
                    string SoyAdi = Console.ReadLine();
                    var result = from musterix in musteriler where musterix.Adi == Adi && musterix.SoyAdi == SoyAdi select musterix;
                    if (result.Count() > 0) { musteriler.Remove((Musteri)result.First()); } else { Console.WriteLine("\nMüşteri bulunamadı!\n"); }

                    musteriManager.Listele(musteriler);
                    break;
                case 0:
                    Console.WriteLine("Çıkış yaptınız!");
                    Console.ReadLine();
                    break;
            }
            MusteriManager.MenuSecim(ref MenuNumber);
        }

    }
}

//https://devnot.com/2016/az-bilinen-visual-studio-kisayollari/

class Musteri
{
    public int Id { get; set; }
    public string Adi { get; set; }
    public string SoyAdi { get; set; }
}

class MusteriManager
{
    public List<Musteri> MusteriListesi { get; set; }
    public void Ekle(Musteri musteri)
    {
        MusteriListesi.Add(musteri);
    }
    public void Sil(Musteri musteri)
    {
        MusteriListesi.Remove(musteri);
    }
    public void Listele()
    {

        Console.WriteLine("ID        ADI            SOYADI");
        Console.WriteLine("-------------------------------");
        foreach (Musteri musteri in MusteriListesi)
        {
            Console.WriteLine("{0}{1}{2}", musteri.Id.ToString().PadRight(10), musteri.Adi.PadRight(15), musteri.SoyAdi);
        }
        Console.ReadLine();
    }
    public void Listele(List<Musteri> musteriler)
    {
        Console.WriteLine("ID        ADI            SOYADI");
        Console.WriteLine("-------------------------------");
        foreach (Musteri musteri in musteriler)
        {
            Console.WriteLine("{0}{1}{2}", musteri.Id.ToString().PadRight(10), musteri.Adi.PadRight(15), musteri.SoyAdi);

        }
        Console.ReadLine();
    }

    public static void MenuSecim(ref byte menuSecim)
    {
        try
        {
            Console.WriteLine("\nX Bank Musteri Yönetim Sayfası\n------------------------------\n");
            Console.WriteLine("Çıkmak için 0 yazıp Enter'a basınız: ");
            Console.WriteLine("Müşteri listelemek için 1 yazıp Enter'a basınız: ");
            Console.WriteLine("Müşteri eklemek için 2 yazıp Enter'a basınız: ");
            Console.WriteLine("Müşteri silmek için 3 yazıp Enter'a basınız:\n");
            Console.Write("Seçiminizi Yapınız : ");
            menuSecim = Convert.ToByte(Console.ReadLine());
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
}