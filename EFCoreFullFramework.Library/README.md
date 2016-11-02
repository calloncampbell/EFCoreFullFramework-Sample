## Install Entity Framework
To use EF Core, install the package for the database provider(s) you want to target. This walkthrough uses SQL Server.

Run the following command in Package Manager Console:

```powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

We will also be using some Entity Framework commands to maintain the database. So we will install the commands package as well.

Run the following command in Package Manager Console:

```powershell
Install-Package Microsoft.EntityFrameworkCore.Tools –Pre
```

## Create your model

See 'EFCore' folder for details.

## Create your database

Now that you have a model, you can use migrations to create a database for you.

Run the following command in Package Manager Console to scaffold a migration to create the initial set of tables for your model:

``` powershell
Add-Migration MyFirstMigration
```

Run the following command in Package Manager Console to apply the new migration to the database. Because your database doesn’t exist yet, it will be created for you before the migration is applied.

``` powershell
update-database
```

After running 'update-datebase', you will see a new folder called "Migrations" added to the project.
