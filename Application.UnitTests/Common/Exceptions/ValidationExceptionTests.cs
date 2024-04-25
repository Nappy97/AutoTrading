﻿using AutoTrading.Application.Common.Exceptions;
using FluentAssertions;
using FluentValidation.Results;

namespace Application.UnitTests.Common.Exceptions;

public class ValidationExceptionTests
{
    [Test]
    public void DefaultConstructorCreatesAnEmptyErrorDictionary()
    {
        var actual = new ValidationException().Errors;

        actual.Keys.Should().BeEquivalentTo([]);
    }

    [Test]
    public void SingleValidationFailureCreateASingleElementErrorDictionary()
    {
        var failures = new List<ValidationFailure>
        {
            new("Age", "must be over 18")
        };

        var actual = new ValidationException(failures).Errors;

        actual.Keys.Should().BeEquivalentTo(["Age"]);
        actual["Age"].Should().BeEquivalentTo(["must be over 18"]);
    }

    [Test]
    public void
        MultipleValidationFailureForMultiplePropertiesCreatesAMultipleElementErrorDictionaryEachWithMultipleValues()
    {
        var failures = new List<ValidationFailure>
        {
            new("Age", "must be 18 or older"),
            new("Age", "must be 25 or younger"),
            new("Password", "must contain at least 8 characters"),
            new("Password", "must contain a digit"),
            new("Password", "must contain upper case letter"),
            new("Password", "must contain lower case letter")
        };

        var actual = new ValidationException(failures).Errors;

        actual.Keys.Should().BeEquivalentTo(["Password", "Age"]);

        actual["Age"].Should().BeEquivalentTo
        ([
            "must be 25 or younger",
            "must be 18 or older"
        ]);

        actual["Password"].Should().BeEquivalentTo
        ([
            "must contain lower case letter",
            "must contain upper case letter",
            "must contain at least 8 characters",
            "must contain a digit"
        ]);
    }
}