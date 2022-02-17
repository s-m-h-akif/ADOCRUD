using System;
using System.Data.SqlClient;
class ADOCRUD
{
    char choice = 'y';
    string name = " ", course = " ";
    void create() //creating the method to create the table
    {
        SqlConnection? con = null;
        try
        {
            //Created the Connection
            con = new SqlConnection("data source =.;database=student; integrated security=SSPI");//passing the connection string
            //Sql query to create the tabel.
            SqlCommand cm = new SqlCommand("create table students(studid int not null,name varchar(25),course varchar(25))", con);
            con.Open();//opening the connection
            cm.ExecuteNonQuery();
            Console.WriteLine("\n \t Table created successfulliy");

         }
        catch (Exception e)
        {
            Console.WriteLine("\n \t Something went wrong while connecting or executing" + e);
        }
        finally
        {
            con?.Close();
        }

    }
    //method to insert the value 
    void insert()
    {
        int id;
        Console.Write("\t Enter the Student Id :\t");
        id = Convert.ToInt32(Console.ReadLine());
        Console.Write("\t Enter the Name:\t");
        name = Console.ReadLine();//taking the value of id from user 
        Console.Write("\t Enter the Course:\t");
        course = Console.ReadLine(); //taking the value of course from user

        SqlConnection? con = null;
        //using try-catch for exception handling
        try
        {    
            //creating the connection 
            con = new SqlConnection("data source=.; database=student; integrated security=SSPI");
            //creating sqlCommand object to perform various opertions
            SqlCommand cm = new SqlCommand("insertstud", con);
              
            //opening the connection
            con.Open();
            cm.CommandType = System.Data.CommandType.StoredProcedure;
            cm.Parameters.Add(new SqlParameter("@studid", id));
            cm.Parameters.Add(new SqlParameter("@Name", name));
            cm.Parameters.Add(new SqlParameter("@Course", course));
            Console.WriteLine("\n \t value Inserted successfulliy");

        }
        catch (Exception e)
        {
            Console.WriteLine("OOPs, something went wrong." + e.Message);
        }
        // Closing the connection
        finally
        {
            con?.Close();
        }
    }
    //method to retrieve the value
    void retrieve()
    {
        SqlConnection? con = null;
        try
        {
            con = new SqlConnection("data source=.; database=student; integrated security=SSPI");
            SqlCommand cm = new SqlCommand("select * from student1", con);
            con.Open();
            // Executing the SQL query to retrive the data
            SqlDataReader dr = cm.ExecuteReader();
            Console.WriteLine("StudId \tName \tCourse");
            while (dr.Read())
            {
                Console.WriteLine(dr[0] + "\t" + dr[1] + " " + dr[2]);

            }

        }
        catch (Exception e)
        {
            Console.WriteLine("OOPs, something went wrong." + e.Message);
        }
        finally
        {
            con?.Close();
        }
    }

    //creating the main method
    public static void Main(String[] args)
    {
        //creating the object to call the methods
        ADOCRUD obj = new ADOCRUD();
        int val;
        while (obj.choice == 'y')
        {

        Console.WriteLine("***CHOOSE THE OPERATION YOU WANT TO PERFORM***");
        Console.WriteLine("Enter 1 For Creating the Table");
        Console.WriteLine("Enter 2 For Inserting the Information");
        Console.WriteLine("Enter 3 For  Retrieve  the Information");
        val = Convert.ToInt32(Console.ReadLine());

        //using switch case to provide option to the user for various operation
        switch (val)
        {
            case 1:
                obj.create();
                break;
            case 2:
                obj.insert();
                break;
            case 3:
                obj.retrieve();
                break;
            default:
                Console.WriteLine("Invalid data Inserted");
                break;
        }

            Console.WriteLine("\n Do you wish to continue ?? Enter small y for Yes, small n for NO");
            obj.choice = Convert.ToChar(Console.ReadLine());
        }
        Console.ReadLine();
    }
}
        
        

    

