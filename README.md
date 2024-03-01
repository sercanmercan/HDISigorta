Using Technology;
- .Net Core 7
- Entity Framework
- SignalR
- Mssql

  I did this project with onion architecture which has domain, application, infrastructure, persistence and presentation layers. Domain layer has entities. Application layer has interface of repositories, dtos and exception. Persistence layer has helper class, repositories, dbcontext, migrations, mapping profile and configuration class. Infrastructure has token service. Presentation layer has controllers.

This project contains profitability ratio, risk cost ratio and profitability cost. I applied the calculations as follows.

  Profitability ratio = [[selling price - (buying price + total repair cost)] / buying price + total repair cost] * 100
  
  Risk cost ratio = [(total repair cost / selling price) * 100]/ total repair cost

  Profitability cost = selling price - (buying price + total repair cost)

  Uml diagram is as follows

![image](https://github.com/sercanmercan/HDISigorta/assets/39940013/261313cc-4120-45a7-8941-c9dd7876174c)
