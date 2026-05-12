using CS_DB_Exercise.Infrastructures;
using CS_DB_Exercise.Infrastructures.Queries;
using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures.Contexts;

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
        var department = accessor.FindById(2);
        Console.WriteLine($"存在する部署Id:{department!.ToString()}");
        
        // 指定した部署Idの部署を取得する(存在しない部署Id)
        department = accessor.FindById(100);
        if (department == null)
        {
            Console.WriteLine($"部署Id:100の部署は存在しません。");
        }
    }
}