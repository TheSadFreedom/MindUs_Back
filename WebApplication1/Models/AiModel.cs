using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class AiModel
{
    public long AiModelId { get; set; }

    public string? AiModelAuthor { get; set; }

    public string? AiModelName { get; set; }

    public string? AiModelDescription { get; set; }
}
