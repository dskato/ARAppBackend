using ARAppBackend.DTOs.Class;

namespace ARAppBackend
{
    public partial interface IApplicationService
    {
        GetClassResponse CreateClass(CreateClassRequest request);
        bool DeleteClassById(int id);
        GetClassResponse GetClassById(int id);
        List<GetClassResponse> GetAllClasses();
        GetClassResponse EditClassInfo(UpdateClassRequest request);

    }
}
