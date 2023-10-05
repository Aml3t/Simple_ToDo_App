using Globomatics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Domain
{
    public record TodoTask(string Title,
        DateTimeOffset DueDate,
        User CreatedBy)
        : Todo(Guid.NewGuid(), Title, DateTimeOffset.UtcNow, CreatedBy);


    public record Feature(string Title,
        string Description,
        string Component,
        int Priority,
        User CreatedBy,
        User AssignedTo) : TodoTask(Title, DateTimeOffset.MinValue, CreatedBy);


    public record Bug(string Title,
        string Description,
        Severity Severity,
        string AffectedVersion,
        int AffectedUsers,
        User CreatedBy,
        User? AssignedTo,
        IEnumerable<byte[]> Images) : TodoTask(Title, DateTimeOffset.MinValue, CreatedBy);


}
