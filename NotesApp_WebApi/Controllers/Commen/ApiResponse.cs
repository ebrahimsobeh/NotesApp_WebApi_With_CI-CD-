using System.Collections.Generic;

namespace Malak.CommonEntities.Common
{
    public class ApiResponse<TData>
    {
        public TData Data { get; set; }
        public bool Succeeded { get; set; } = false;
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }


}
