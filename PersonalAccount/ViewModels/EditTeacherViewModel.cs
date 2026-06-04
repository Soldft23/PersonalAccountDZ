namespace PersonalAccount.ViewModels;

public class EditTeacherDisciplineViewModel : ViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class  EditTeacherGroupViewModel : ViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
}

public class EditTeacherGroupOptionViewModel : ViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class  EditTeacherViewModel : ViewModel
{
    public int AccountId { get; set; }
    public List<int> DisciplineIdsOrder { get; set; } = [];
    public Dictionary<int, EditTeacherDisciplineViewModel> Disciplines { get; set; } = [];
    public List<EditTeacherGroupOptionViewModel> AllGroupOptions { get; set; } = [];
    public Dictionary<int, List<EditTeacherGroupViewModel>> GroupsByDisciplines
    {
        get;
        set;
    } = [];
}