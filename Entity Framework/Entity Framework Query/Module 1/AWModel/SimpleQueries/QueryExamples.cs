using System;
using System.Linq;
using AWModel;

namespace SimpleQueries
{
  class QueryExamples
  {
    static void Main()
    {

      GetSomeCustomers();
     
    }
    private static void GetSomeCustomers()
    {

      var context = new SalesEntities();
      var query = from c in context.Customers orderby c.LastName where c.FirstName=="Robert"  select c;
      var customers =query.ToList();
     
    
    }
  }
}
