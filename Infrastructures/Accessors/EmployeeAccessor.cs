using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace CS_DB_Exercise.Infrastructures.Accessors;
/// <summary>
/// employeeテーブルにアクセスするクラス
/// </summary>
public class EmployeeAccessor
{
    private readonly AppDbContext _context;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">演習用DbContext</param>
    public EmployeeAccessor(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// 演習-07 employeeテーブルから部署Idで該当社員を取得する
    /// </summary>
    /// <param name="deptId">部署Id</param>
    /// <returns>問合せ結果</returns>
    public List<EmployeeEntity>? FindByDeptId(int deptId)
    {
        var employees = _context.Employees
            .Where(e => e.DeptId == deptId)
            .ToList();
        // 取得した社員の件数が0件の場合はnullを返す
        if (employees.Count == 0)
        {
            return null;
        }

        return employees;
    }
    public List<EmployeeEntity>? FindByContainsName(string keyword)
    {
        var employees = _context.Employees
             .Where(e => e.Name!.Contains(keyword))
             .ToList();
        if (employees.Count == 0)
        {
            return null;
        }

        return employees;
    }
    public EmployeeEntity? Create(EmployeeEntity employee)
    {
        var result = _context.Employees.Add(employee);
        _context.SaveChanges();
        return result.Entity;
    }
    public EmployeeEntity? UpdateById(EmployeeEntity employee)
    {
        var result = _context.Employees.Find(employee.Id);
        if (result == null)
        {
            return null;
        }
        result.Name = employee.Name;
        //result.DeptId = employee.DeptId;
        _context.SaveChanges();
        return result;
    }
}