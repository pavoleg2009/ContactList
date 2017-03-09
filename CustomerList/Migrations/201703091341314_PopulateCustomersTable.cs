namespace CustomerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomersTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (FirstName, LastName, PhoneNumber, Email) VALUES ('Gregory', 'Huffman', '07624073918', 'Praesent@pedenec.net')");
            Sql("INSERT INTO Customers (FirstName, LastName, PhoneNumber, Email) VALUES ('Tad', 'Vazquez', '0169771036', 'dapibus.gravida@necimperdietnec.co.uk')");
            Sql("INSERT INTO Customers (FirstName, LastName, PhoneNumber, Email) VALUES ('William', 'Abbott', '0198457054', 'non.justo.Proin@mauris.net')");
            Sql("INSERT INTO Customers (FirstName, LastName, PhoneNumber, Email) VALUES ('Amal', 'Shaw', '07648300002', 'ornare.sagittis@ipsumPhasellus.co.uk')");
            Sql("INSERT INTO Customers (FirstName, LastName, PhoneNumber, Email) VALUES ('Avram', 'Barrett', '0128968589', 'Donec@lobortisultrices.co.uk')");
            Sql("INSERT INTO Customers (FirstName, LastName, PhoneNumber, Email) VALUES ('Hamilton', 'Web', '0191341035', 'Nam@noncursusnon.ca')");
            Sql("INSERT INTO Customers (FirstName, LastName, PhoneNumber, Email) VALUES ('Emerson', 'Osborn', '0800090144', 'Sed.congue@auctor.co.uk')");
            Sql("INSERT INTO Customers (FirstName, LastName, PhoneNumber, Email) VALUES ('Rashad', 'Johnson', '02283246041', 'fringilla.Donec@Infaucibus.org')");
            Sql("INSERT INTO Customers (FirstName, LastName, PhoneNumber, Email) VALUES ('Brody', 'Page', '01345903264', 'nibh.Phasellus@eratvel.co.uk')");
            Sql("INSERT INTO Customers (FirstName, LastName, PhoneNumber, Email) VALUES ('Armando', 'Bradford', '07073485382', 'rutrum.eu@velpedeblandit.com')");
            Sql("INSERT INTO Customers (FirstName, LastName, PhoneNumber, Email) VALUES ('Malik', 'Carpenter', '01156669816', 'id.ante@pede.edu')");
            Sql("INSERT INTO Customers (FirstName, LastName, PhoneNumber, Email) VALUES ('Reece', 'Figueroa', '01188641600', 'tellus@primisin.net')");
            Sql("INSERT INTO Customers (FirstName, LastName, PhoneNumber, Email) VALUES ('Orlando', 'Morales', '0800750400', 'magna.Ut@iaculis.net')");
        }

        public override void Down()
        {
            Sql("DELETE * FROM Customers");
        }
    }
}
