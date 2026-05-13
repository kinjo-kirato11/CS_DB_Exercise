using Microsoft.EntityFrameworkCore;

using CS_DB_Exercise.Infrastructures.Accessors;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;

namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        // 演習用DbContextを生成する
        var context = new AppDbContext();

        // departmentテーブルアクセスクラスを生成する
        var departmentAccessor = new DepartmentAccessor(context);

        // 演習-15 トランザクション制御機能を確認する
        Exercise15(context, departmentAccessor);
    }

    /// <summary>
    /// 演習-15 トランザクション制御機能を確認する
    /// </summary>
    /// <param name="context">演習用DbContext</param>
    /// <param name="departmentAccessor">Departmentテーブルアクセスクラス</param>
    /// <returns></returns>
    private static void Exercise15(DbContext context, DepartmentAccessor departmentAccessor)
    {
        using var transaction = context.Database.BeginTransaction();
        Console.WriteLine("トランザクションを開始しました。");

        Console.Write("新しい部署名を入力してください->");
        var name = Console.ReadLine();
        var entity = new DepartmentEntity
        {
            Id = 0, // Idは自動採番されるため、0を指定する
            Name = name
        };
        // Create()メソッドを使用して、departmentテーブルに新しい部署を登録する
        var result = departmentAccessor.Create(entity);
        Console.WriteLine($"新しい部署を登録しました: 部署Id={result.Id} , 部署名={result.Name}");

        Console.Write("トランザクションをコミットしますか？ (y/n)->");
        var input = Console.ReadLine();
        //ToLower()メソッドは、文字列内の英字をすべて小文字に変換した新しい文字列を返す。
        if (input?.ToLower() == "y")

        {
            // トランザクションをコミットする
            transaction.Commit();
            Console.WriteLine("トランザクションをコミットしました。");
        }
        else
        {
            // トランザクションをロールバックする
            transaction.Rollback();
            Console.WriteLine("トランザクションをロールバックしました。");
        }

        // 登録した部署を含むすべての部署を取得して表示する
        var departments = departmentAccessor.FindAll();
        foreach (var department in departments)
        {
            Console.WriteLine($"部署Id={department.Id} , 部署名={department.Name}");
        }
    }
}