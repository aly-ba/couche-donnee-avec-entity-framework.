using AWModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Objects;
using System.Diagnostics;
using System.Linq;
using System.Data.EntityClient;
using System.Data;

namespace QueryTests
{
    
  
  [TestClass()]
  public class SalesEntitiesTest
  {

     [TestMethod()]
     public void GetSomeCustomers()
    {

      var context = new SalesEntities();
      var query = from c in context.Customers orderby c.LastName where c.FirstName=="Robert" select c;
      var customers =query.ToList();

      foreach (var cust in customers)
        Debug.WriteLine(cust.LastName.Trim() + ", " + cust.FirstName);
     }

     [TestMethod()]
     public void GetSomeCustomersUsingLinqMethod()
     {

       var context = new SalesEntities();
       var query = context.Customers.OrderBy(c => c.LastName).Where(c => c.FirstName == "Robert");
       var customers = query.ToList();

       foreach (var cust in customers)
         Debug.WriteLine(cust.LastName.Trim() + ", " + cust.FirstName);
     }

     [TestMethod()]
     public void GetSomeCustomersUsingESQL()
     {

       var context = new SalesEntities();
       var esql = "SELECT VALUE c FROM SalesEntities.Customers AS c " + 
                  "WHERE c.FirstName='Robert' ORDER BY c.LastName";
       var query=context.CreateQuery<Customer>(esql);
       var customers = query.ToList();

       foreach (var cust in customers)
         Debug.WriteLine(cust.LastName.Trim() + ", " + cust.FirstName);
     }

    
     [TestMethod()]
     public void GetSomeCustomersUsingESQLRawQuerying()
     {
       var context=new SalesEntities(); //I needed this in the test, but you shouldn't need it in regular code
       using (var conn = new EntityConnection("name=SalesEntities"))
       {
         conn.Open();
         EntityCommand cmd = conn.CreateCommand();
         cmd.CommandText =   "SELECT VALUE c FROM SalesEntities.Customers AS c " + 
                  "WHERE c.FirstName='Robert' ORDER BY c.LastName";
         EntityDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess|CommandBehavior.CloseConnection);
       }
     }













     [TestMethod()]
     public void RunVariousQueriesForProfiling()
     {
       var context = new SalesEntities();

      //simple query
       (from c in context.Customers select c).ToList();

       //query with variable parameter
       string sort = "Robert";
       (from c in context.Customers orderby c.LastName where c.FirstName == sort select c).ToList();

       //query with hard coded parameter      
       (from c in context.Customers orderby c.LastName where c.FirstName == "Robert" select c).ToList();
       
       //Entity SQL via Query Builder Methods
       context.Customers.OrderBy("it.LastName").Where("it.FirstName='Robert'").ToList();

       //Entity SQL with forced parameters
       var query = context.CreateQuery<Customer>("SELECT VALUE c FROM SalesEntities.Customers AS c WHERE c.FirstName=@fn");
       var whereParameter = new ObjectParameter("fn", "Robert");
       query.Parameters.Add(whereParameter);
       query.ToList();

       //sql injection with LINQ to Entities?
        sort = "John';EXEC sys.sp_helpuser--";
       (from c in context.Customers orderby c.LastName where c.FirstName == sort select c).ToList();

       //sql injection with Entity SQL?
       sort = "John';EXEC sys.sp_helpuser--";
       var esql = "it.FirstName=" + sort;
       context.Customers.Where(esql).ToList();
     }
   
  }
}
