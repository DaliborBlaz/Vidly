namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0c17da61-f47a-4206-849f-dc1b3131a73c', N'admin1@vidly.com', 0, N'AImcK6M1O602w6N9uOXivuIC3wQGlq+4+j2lP7PHp1B8XESNbRsxhRaZE8IYiZ/XVQ==', N'f55333ed-98cb-4134-90a4-3f7d50024746', NULL, 0, 0, NULL, 1, 0, N'admin1@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'72dcb3f4-374a-4e83-87d2-ec2f8ec59670', N'guest@gmail.com', 0, N'AARFSBKC+g3OCkzSOAnrEwrCzEN/ffuya+o3GKd7jkacBC3Jn1ALfGZ2Zgy+am+V1g==', N'562b42c7-707f-41ec-941d-b6e671048203', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c0f2715a-64f5-4471-b246-3c8370367fe0', N'canManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0c17da61-f47a-4206-849f-dc1b3131a73c', N'c0f2715a-64f5-4471-b246-3c8370367fe0')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
