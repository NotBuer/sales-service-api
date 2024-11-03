﻿using SalesService.Domain.Validations;

namespace SalesService.Application.Responses.Common;

public abstract class Response<TContent> : IResponse
    where TContent : class
{
    public abstract TContent? Content { get; init; }
    public abstract Metadata Metadata { get; init; }
    public abstract ValidationResult ValidationResult { get; init; }
}