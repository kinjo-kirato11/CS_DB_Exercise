using CS_DB_Exercise.Infrastructures;
using CS_DB_Exercise.Infrastructures.Queries;
using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Accessors;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;


namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        var accessor = new DepartementAccessor(new AppDbContext());
        // すべての部署を取得する
        var departments = accessor.FindAll();
        Console.WriteLine("すべての部署を取得する");
        foreach (var d in departments)
        {
            Console.WriteLine(d);
        }

        // 指定した部署Idの部署を取得する(存在する部署Id)
         department = accessor.FindById(2);
        Console.WriteLine($"存在する部署Id:{department!.ToString()}");
        
        // 指定した部署Idの部署を取得する(存在しない部署Id)
      
        if (department == null)
        {
            Console.WriteLine($"部署Id:10の部署に所属する社員は存在しません");
        }
         department = accessor.FindById(3);
        Console.WriteLine(EmployeeAccessor.FindByDeptId(department));



    }
}