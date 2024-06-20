Connection string: 
"ConnectionStrings": {
    "Default": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=apbd;Integrated Security=True;"
  }
1. dotnet tool install --global dotnet-ef
2. dotnet ef migrations add Init
3. dotnet ef database update
4. Install Microsoft.EntityFramework in Nugget.

