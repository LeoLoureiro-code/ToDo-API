using System;
using System.Collections.Generic;

namespace Todo.DataAccess.EF.Models;

public partial class ToDo
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;
}
