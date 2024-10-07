namespace CalSystem2._0.Concrete.IServices.ICommonServices
{
    public interface ICurrentUserServices
    {
        string EmpID { get; }

        string Email { get; }

        string Name { get; }

        string RoleType { get; }

        string Dept { get; }

       // List<int> RoleIds { get; }
    }
}
