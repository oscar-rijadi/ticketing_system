migration commands (in package manager console)

1) to enable migration (no need as already run)
Enable-Migrations -ProjectName TicketingSystem.EF -StartUpProjectName TicketingSystem.EF -MigrationsDirectory Migrations -ContextTypeName TicketingSystemContext -ContextAssemblyName TicketingSystem.EF -ConnectionStringName TicketingSystemConnection

2) Add migration (run when adding a new migration)
Add-Migration -ProjectName TicketingSystem.EF -StartUpProjectName TicketingSystem.EF -Name InitialCreate -ConfigurationTypeName TicketingSystem.EF.Migrations.Configuration -ConnectionStringName TicketingSystemConnection

3) Update database (to create/update the database - when seeding or migration changes)
Update-Database -ProjectName TicketingSystem.EF -StartUpProjectName TicketingSystem.EF -ConfigurationTypeName TicketingSystem.EF.Migrations.Configuration -ConnectionStringName TicketingSystemConnection