namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [TelNum]) VALUES (N'6fa03f0a-09bc-4cf0-a8f8-184d3a65a338', N'admin2@vidly.com', 0, N'AOQ2U0GwGQ5liIu9l3nbHdZpQtnivNsS7WPP+btPbAh3KAGFLH2zRrbJVYxMfgkOpw==', N'20b0c1d9-d6bb-4ec4-8e49-2d2da8e08cc3', NULL, 0, 0, NULL, 1, 0, N'admin2@vidly.com', N'12345', N'12345')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c0f2715a-64f5-4471-b246-3c8370367fe0', N'canManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6fa03f0a-09bc-4cf0-a8f8-184d3a65a338', N'c0f2715a-64f5-4471-b246-3c8370367fe0')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
