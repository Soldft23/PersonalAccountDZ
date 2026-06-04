using PersonalAccount.Data;
using PersonalAccount.Data.Entities;
using PersonalAccount.Mappers;
using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public class TeacherGroupDisciplineRepo(
    AppDbContext ctx,
    IMapper<TeacherGroupDisciplineEntity, TeacherGroupDisciplineModel> mapper
) : Repo<TeacherGroupDisciplineEntity, TeacherGroupDisciplineModel>(ctx, mapper, c => c.TeacherGroupSubjets),
    ITeacherGroupDisciplineRepo
{
    public async Task<List<TeacherGroupDisciplineModel>> GetAllByTeacherAccountIdAsync(int teacherAccountId)
        => await GetAllByAsync(entity => entity.TeacherAccountId == teacherAccountId);

    public async Task RemoveByTeacherAccountIdAndGroupIdAndDisciplineIdAsync(int teacherAccountId, int disciplineId,
        int groupId) =>
        await RemoveByAsync(entity => entity.TeacherAccountId == teacherAccountId
                                      && entity.DisciplineId == disciplineId
                                      && entity.GroupId == groupId);
}