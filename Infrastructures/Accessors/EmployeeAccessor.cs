using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;
namespace CS_DB_Exercise.Infrastructures.Queries;

public class EmployeeAccessor
{
    //  アプリケーション用DbContext
    private readonly AppDbContext _context;
    
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">アプリケーション用DbContext</param>
    public EmployeeAccessor(AppDbContext context)
    {
        _context = context;
    }
        public List<DepartmentEntity> FindAll()
    {
        // ToList()メソッドを使用して、すべての部署を取得する
        var departments = _context.Departments.ToList();
        return departments;
    }
    public List<EmployeeEntity> FindByDeptId(int deptId)
    {
        // deptIdを指定して、従業員を取得する
        var employees = _context.Employees.Where(e => e.DeptId == deptId).ToList();
        return employees;
    }
}