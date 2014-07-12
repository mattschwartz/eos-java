using System;

namespace eos.Models.Data
{
    interface IDataModel
    {
        String Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
        String CreatedBy { get; set; }
    }
}