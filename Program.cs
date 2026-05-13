using CS_DB_Exercise.Infrastructures.Accessors;
using CS_DB_Exercise.Infrastructures.Contexts;

namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        // 演習用DbContextを生成する
        var context = new AppDbContext();

        // EmployeeおよびDepartmentテーブルアクセスクラスを生成する
        var employeeAccessor = new EmployeeAccessor(context);
        var departmentAccessor = new DepartmentAccessor(context);

        // 演習-11 employeeテーブルの社員を削除する
        //Exercise13(employeeAccessor);
        // 演習-14 departmentテーブルの部署と所属社員を取得する
        Exercise14(departmentAccessor);
    }

    /// <summary>
    /// 演習-11 employeeテーブルの社員を削除する
    /// </summary>
    /// <param name="employeeAccessor">Employeeテーブルアクセスクラス</param>
    /// <returns></returns>
    private static void Exercise11(EmployeeAccessor employeeAccessor)
    {

        Console.Write("社員Idを入力してください->");
        var empId = int.Parse(Console.ReadLine()!);

        Console.WriteLine("演習-11 指定された社員Idの社員を削除する\r\n");
        // 指定された社員Idの社員を削除する
        var result = employeeAccessor.DeleteById(empId);
        // 削除結果がnullの場合は該当社員が存在しないため削除できなかった旨を表示する
        if (result == null)
        {
            Console.WriteLine($"社員Id:{empId}の社員は存在しないため削除できませんでした");
            return;
        }
        Console.WriteLine($"社員Id:{empId}の社員を削除しました");
    }
        private static void Exercise13(EmployeeAccessor employeeAccessor)
    {

        Console.Write("社員名を入力してください->");
        var empName = Console.ReadLine();

        Console.WriteLine("演習-13 指定された社員名の社員と所属部署を取得する\r\n");
                var result = employeeAccessor.FindByNameJoinDepartment(empName);
        // 取得結果がnullの場合は該当社員が存在しないため取得できなかった旨を表示する
        if (result == null)
        {
            Console.WriteLine($"社員名:{empName}の社員は存在しませんでした");
            return;
        }
        Console.WriteLine($"社員Id={result.Id},社員名={result.Name},部署ID={result.DeptId},部署名={result.Department?.Name}");
    }
    private static void Exercise14(DepartmentAccessor departmentAccessor)
    {

        Console.Write("部署Idを入力してください->");
        var deptId = int.Parse(Console.ReadLine()!);

        Console.WriteLine("演習-14 指定された部署Idの部署と所属社員を取得する\r\n");
        var result = departmentAccessor.FindByIdJoinEmployee(deptId);
        if (result == null)
        {
            Console.WriteLine($"部署Id:{deptId}の部署は存在しませんでした");
            return;
        }
        Console.WriteLine($"部署Id={result.Id},部署名={result.Name}");
        foreach (var employee in result.Employees)
        {
            Console.WriteLine($"  社員Id={employee.Id},社員名={employee.Name},部署Id={result.Id}");
        }
    }
}
