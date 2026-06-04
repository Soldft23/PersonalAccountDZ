namespace PersonalAccount.ViewModels;

public class TeacherCabinetDisciplineViewModel : ViewModel
{
    public string Name { get; set; } = string.Empty;
}

public class TeacherCabinetGroupViewModel : ViewModel
{
    public string Name { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
}

public class TeacherCabinetViewModel : CabinetViewModel
{
    public List<int> DisciplineIdsOrder { get; set; } = [];
    public Dictionary<int, TeacherCabinetDisciplineViewModel> Disciplines { get; set; } = [];
    public Dictionary<int, List<TeacherCabinetGroupViewModel>> GroupsByDisciplines
    {
        get;
        set;
    } = [];
}