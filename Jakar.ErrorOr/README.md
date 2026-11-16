# Jakar.ErrorOr

RFC 7807-style errors and results: Error, Errors, Alert and ErrorOrResult<T>, plus the types they're built on: Pair, StringTags, Status.

```sh
dotnet add package Jakar.ErrorOr
```

Split out of [Jakar.Extensions](https://github.com/Jakar510/Jakar.Extensions) in 10.12. It depends on [Jakar.Json](https://www.nuget.org/packages/Jakar.Json/) only; [Jakar.Extensions](https://www.nuget.org/packages/Jakar.Extensions/) 10.12.1 and later depend on it. The types keep the `Jakar.Extensions` namespace, so code that used them from Jakar.Extensions only needs this package reference (and a recompile). With Jakar.Extensions, use 10.12.1 or later: 10.12.0 defines `Pair`, `StringTags` and `Status` itself.

## What's in it

- `Error`: an RFC 7807 problem (status, title, type, instance, description and `StringTags` details), with factories for the common cases (`Error.Validation`, `Error.NotFound`, `Error.Unauthorized`, `Error.Create(Exception)`, ...).
- `Errors`: a set of `Error`s plus an optional `Alert`.
- `ErrorOrResult` / `ErrorOrResult<T>`: a value or its errors.
- `All`, `Some`, `Success`, `Unknown`: result markers.

- `Pair`, `StringTags`, `IErrorDetails`: error details.
- `Status`, `Statuses` (exception → status, titles and type names; `Statuses.RegisterStatus<TException>(status)` adds your own), `IErrorTitles` / `ErrorTitles` (localizable titles).

`Error`, `Errors` and `Alert` keep JSON members they don't declare in `AdditionalData` (`[JsonOverflow]`); they no longer derive from Jakar.Extensions' `BaseClass`. `Error.Unauthorized(PasswordValidator.Results)` and `PasswordValidator.Results.ToStringTags()` are in Jakar.Extensions.

## Versioning

Versions are `<.NET major>.<library major>.<library minor>`: a breaking change bumps the middle number (`10.1.0` → `10.2.0`), anything else the last one.

## Repository

| Path | What it is |
|---|---|
| `Jakar.ErrorOr/` | The package. |
| `Jakar.ErrorOr.Tests/` | NUnit tests. |
| `.github/workflows/ci.yml` | Build and test on Ubuntu and Windows, for every push and pull request. |
| `.github/workflows/publish.yml` | On `master`: CI, then pack and push to nuget.org (Trusted Publishing). |