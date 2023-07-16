using ARAppBackend.DTOs.Class;

namespace ARAppBackend
{
    public partial interface IApplicationService
    {
        GetClassResponse CreateClass(CreateClassRequest request);
        bool DeleteClassById(int id);
        GetClassResponse GetClassById(int id);
        GetClassResponse GetClassByCode(string code);
        List<GetClassResponse> GetAllClasses();
        GetClassResponse EditClassInfo(UpdateClassRequest request);
        List<GetClassResponse> GetAllClassesByTextSearch(int userId, string textSearch);

    }
}
