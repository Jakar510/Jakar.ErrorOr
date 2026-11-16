// Jakar.Extensions :: Jakar.Extensions
// 03/03/2025  13:03

namespace Jakar.Extensions;


public static class ErrorExtensions
{
    public const string BULLET = "• ";
    public const string SPACER = "\n    -";


    public static string GetMessage( this Errors errors )
    {
        using PooledArray<string> array = errors.Details.AsValueEnumerable().Select(GetMessage).ToArrayPool();

        return string.Join('\n', array.Span);
    }
    public static string GetMessage( this IEnumerable<Error> errors ) => string.Join('\n', errors.Select(GetMessage));


    public static string GetMessage( this in ReadOnlySpan<Error> errors )
    {
        using IMemoryOwner<string?> owner = MemoryPool<string?>.Shared.Rent(errors.Length);
        Span<string?>               span  = owner.Memory.Span;
        int                         count = 0;

        foreach ( Error error in errors ) { span[count++] = error.GetMessage(); }

        StringBuilder sb = new(4096);
        sb.AppendJoin('\n', span);
        return sb.ToString();
    }

    public static string GetMessage( this Error error ) => error.Title.GetMessage(in error.details);
    public static string GetMessage( this string? title, ref readonly StringTags tags )
    {
        if ( tags.IsEmpty ) { return title ?? string.Empty; }

        using ValueStringBuilder builder = new(4096);

        builder.Append(BULLET).Append(title ?? string.Empty);

        foreach ( string value in tags.Entries.AsSpan() ) { builder.Append(SPACER).Append(value); }

        foreach ( ref readonly Pair value in tags.Tags.AsSpan() )
        {
            if ( value.Value is not null ) { builder.Append(SPACER).Append(value.Value); }
        }

        return builder.ToString();
    }


    public static Status GetStatus( this IEnumerable<Error>? errors ) => errors?.Max(Error.GetStatus) ?? Status.Ok;
    public static Status GetStatus( this Error[]? errors, Status status )
    {
        ReadOnlySpan<Error> span = errors;
        return span.GetStatus(status);
    }
    public static Status GetStatus( this in ReadOnlySpan<Error> errors, Status minStatus )
    {
        if ( errors.IsEmpty ) { return minStatus; }

        foreach ( Error error in errors )
        {
            Status? code = error.StatusCode;
            if ( code > minStatus ) { minStatus = code.Value; }
        }

        return minStatus;
    }
}
