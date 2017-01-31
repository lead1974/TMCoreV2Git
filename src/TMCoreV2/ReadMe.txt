1. Setup MailKit
2. Re-structure project (Models -> ViewModels, add DataAccess)
3. create DB locally in App_Data folder:
    a. run your app and create the DB in the default location
    b. Open Microsoft Sql Server Management Studio (or you prefer IDE) and create a new connection to point to (localdb)\mssqllocaldb
    c. Script Database as CREATE
    d. Change the path in the FILENAME
    e. Remove the DB you created on step 1 (choose close existing connections)
    f. Run the script
Migration:
a. PM> cd C:\Andrey\Notes\VF\WebApps\labweb\TMCoreV2\src\TMCoreV2
b. PM> dotnet ef
c. PM> dotnet ef migrations add IdentityDataModel
d. dotnet ef migrations add BlogDataModel
e. dotnet ef database update  
  

To "unapply" the most (recent?) migration after it has already been applied to the database: 
1) Open the SQL Server Object Explorer (View -> "SQL Server Object Explorer")
2) Navigate to the database that is linked to your project by expanding the small triangles to the side. 
3) Expand "Tables" 
4) Find the table named "dbo._EFMigrationsHistory". 
5) Right click on it and select "View Data" to see the table entries in Visual Studio. 
6) Delete the row corresponding to your migration that you want to unapply (Say "yes" to the warning, if prompted). 
7) Run "dotnet ef migrations remove" again in the command window in the directory that has the project.json file     

Install Kendo-UI open command line: bower install https://bower.telerik.com/bower-kendo-ui.git enter credentials: aparahnevi@venturafoods.com / V3ntura!23   
Install Telerik.UI.for.AspNet.Core using instructions here: http://www.telerik.com/blogs/official-asp.net-core-1-support-now-in-ui-for-aspnet-mvc                                                                                                            