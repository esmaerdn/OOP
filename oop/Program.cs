// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information

//Referans Tipleri 
//int gibi sayısal verile stack bölüümünde tutulur , arrayler referans tiptir ve heap bölümünde tutulur.

/*int sayi1 = 10;
int sayi2 = 20;
sayi1 = sayi2;
sayi2 = 100;

Console.WriteLine(sayi1);     //Ekranda 20 yazar.


int[] sayilar1 = new[] { 1, 2, 3 };
int[] sayilar2 = new[] {10,20,30 };
sayilar1 = sayilar2;
sayilar2[0] = 1000;

Console.WriteLine(sayilar1[0]);    // Ekranda 1000 yazar.*/


//----------CLASS------------------------

        CreditManager creditManager = new CreditManager();
        creditManager.Calculate();
        creditManager.Calculate();
        creditManager.Save();


        Customer customer = new Customer();  //örneğini oluşturmak, instance creation 
        customer.Id = 1;
        customer.City = "İstanbul";



        Company company = new Company();
        company.TaxNumber = "123456";
        company.CompanyName = "Test";
        company.Id = 2;

        CustomerManager customerManager2 = new CustomerManager(new Person());



        Person person = new Person();
        person.NationalIdentity = "12345678";
        person.FirstName = "Esma";
        person.LastName = "Erden";


        CustomerManager customerManager = new CustomerManager(customer);
        customerManager.Save();
        customerManager.Save();
        customerManager.Delete();


        CustomerManager customerManager1 = new CustomerManager(new Customer(), new MilitaryCreditManager());
        customerManager.GiveCredit();


        Console.ReadLine();



//Class => İçerisinde yapacağımız işlemleri tutan veya herhangi bir konuda bilgi tutan yapılardır


class CreditManager
{
    public void Calculate()
    {
        Console.WriteLine("Hesaplandı");
    }

    public void Save()
    {
        Console.WriteLine("Kredi verildi.");
    }

}

class Customer
{
    public Customer()
    {
        Console.WriteLine("Müşteri nesnesi başlatıldı");

    }
    public int Id { get; set; }

    public string City { get; set; }

}
class Person : Customer         // INHERITANCE ":" işareti ile extends(inherit) olmuş olur.
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }
}

class Company : Customer        // INHERITANCE. Şirket, müşteri nesnesinden miras alır.
{
    public string CompanyName { get; set; }

    public string TaxNumber { get; set; }

}

// Katmanlı mimariler


class CustomerManager
{
    private Customer _customer;
    private ICreditManager _creditManager;

    public CustomerManager(Customer customer, ICreditManager creditManager) //constructor
    {
        _customer = customer;
        _creditManager = creditManager;

    }

    public void Save()
    {
        Console.WriteLine("Müşteri kaydedildi:");

    }
    public void Delete()
    {
        Console.WriteLine("Müşteri silindi:");

    }

    public void GiveCredit()
    {
        _creditManager.Calculate();
        Console.WriteLine("Kredi verildi");

    }
}


interface ICreditManager
{
    void Calculate();  //imza
    void Save();
}
abstract class BaseCreditManager : ICreditManager  //Abstract class
{
    public abstract void Calculate();     //Tamamlanmamış.

    public void Save() // Sabittir.Tamamlanmış.
    {
        Console.WriteLine("Müşteri kaydedildi:");

    }

}

class MilitaryCreditManager : BaseCreditManager, ICreditManager
{
    public override void Calculate()  // override=üstüne yaz.
    {
        Console.WriteLine("Asker kredisi hesaplandı");

    }


    public void GiveCredit()
    {
        Console.WriteLine("Kredi verildi");

    }
}

//---------INTERFACE-----------
// Inteface referanstiptir.Interface'in amacı yazılımdaki bağımlılıkları engellemektir.
//Bir class sadece bir class'ı inherit edebilir.
//Bir class birden fazla interface'i implemente edebilir. 
