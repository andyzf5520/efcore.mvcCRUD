using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyCoreMvc.Models.AiticleModels;
using StudyCoreMvc.Models.BooksModels;

namespace StudyCoreMvc.Models
{
    public class StudyCoreMvcContext : DbContext
    {
        public StudyCoreMvcContext (DbContextOptions<StudyCoreMvcContext> options)
            : base(options)
        {
            //调用基类有参构造函数  :Base(参数)
            //    工具 - > NuGet软件包管理器 - >软件包管理器控制台
            ////创建模型的初始表 
            //Add-Migration InitialCreate
            ////将新迁移应用于数据库 
            //Update-Database 
            // 或者使用cmd
            //在vs中右键项目 -》在资源管理器中打开文件 -》点击src路径文件夹 -》找到对应的项目文件夹 -》按住键盘Shift + 鼠标右键项目文件夹 -》选择在此处打开命令窗口，然后分别输入如下命令：

            //dotnet ef migrations add Initial dotnet ef database update
            //可以在vs中点击 试图-》Sql Server对象管理器-》点击LocalDB -》数据库 -》
            //aspnet - Text.Core - 2c3af9e6 - 9257 - 4859 - 9cea - dcc21968bf8b 能看到增加了个本地数据库，再打开表Article，能看到字段是咋们刚才在Article类中对应的属性，
            //值得注意的时候这里直接默认了ID为咋们的主键，这里应该是默认第一个属性字段为主键 
        }

        public DbSet<StudyCoreMvc.Models.AiticleModels.Article> Article { get; set; }

        public DbSet<StudyCoreMvc.Models.BooksModels.Book> Book { get; set; }
    }
}
