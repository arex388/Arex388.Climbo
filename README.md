# Arex388.Climbo

Arex388.Climbo is a highly opinionated .NET Standard 2.0 library for the [Climbo.com](https://climbo.com) API. It's intended to be an easy, well structured, and highly performant client for interacting with Climbo.com's API for retrieving review tracking information. It can be used in applications interacting with a single account using `IClimboClient`, or with applications interacting with multiple accounts using `IClimboClientFactory`.

As noted above, it is highly opinionated. The API documentation has some ambiguities and weirdness that I've attempted to normalize.

The library has built-in dependency injection to simplify usage. By default a singleton `IClimboClient` or `IClimboClientFactory` instance will be created. If using `IClimboClientFactory`, it will cache `IClimboClient` instance by their account id.

- [Changelog](CHANGELOG.md)
- [Benchmarks](BENCHMARKS.md)



#### Dependency Injection

To configure dependency injection with ASP.NET and ASP.NET Core, use `AddClimbo()` extensions on `IServiceCollection`. There are two signatures, with and without `apiKey` and `accountId` parameters. If `apiKey` and `accountId` are passed to the extension, it will register `IClimboClient` for use with a single account, otherwise it will register `IClimboClientFactory` for use with multiple accounts.



#### How to Use

To create a new review invitation use:

```c#
await climbo.PutReviewInvitationAsync(new PutReviewInvitation {
    Email = "",
    Name = "",
    SendAt = DateTimeOffset.Now.AddMinutes(1)
});
```

To get a previously created review invitation use:

```c#
await climbo.GetReviewInvitationAsync(new ReviewInvitationId(""));
```

To delete a previously created review invitation use:

```c#
await climbo.DeleteReviewInvitationAsync(new ReviewInvitationId(""));
```

