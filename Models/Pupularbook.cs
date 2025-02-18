using System;
using System.Collections.Generic;

namespace lab4.Models;

public partial class Pupularbook
{
    public int? BookId { get; set; }

    public string? Title { get; set; }

    public int? PublishedYear { get; set; }

    public string? Isbn { get; set; }

    public long? TotalLoans { get; set; }
}
