 # MyAPI
 # ASP.net Core 3.1 Web-API
  - DBMS - PostgreSQL and using EF Core
  - Some DTOs for controllers
  - Repository design pattern
  - And client app on Angular
 # Setup Instructions
1. dotnet restore
2. Now 'cd' into 'ClientApp' and run npm install
3. Configure the connection to the database in a files 'appsettings.json' and 'DatabaseContext'
4. Now 'cd' into root directory and run 'dotnet ef migrations add init', after this run 'dotnet ef update database'
5. Run 'dotnet watch run'for start

 :black_medium_small_square: If "ef" not recognized as a command then run in terminal 'dotnet tool install --global dotnet-ef'
