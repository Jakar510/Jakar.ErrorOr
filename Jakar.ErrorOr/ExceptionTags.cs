// Jakar.Extensions :: Jakar.ErrorOr
// 11/15/2026

namespace Jakar.Extensions;


/// <summary> The <see cref="Exception"/> details <see cref="Error.Create(Exception, string?, string?, in StringTags, Status?, string?)"/> records (Jakar.Extensions has the public equivalents). </summary>
internal static class ExceptionTags
{
    /// <summary> Trim/AOT-safe method signature for diagnostic text: <see langword="null"/> when the method metadata isn't available (trimmed, or Native AOT). </summary>
    [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Diagnostic text only. Exception.TargetSite returns null when the metadata was trimmed, and any failure reading it is reported as null ('unknown').")]
    public static string? TryGetMethodSignature( Exception e )
    {
        try
        {
            MethodBase? method = e.TargetSite;
            if ( method is null ) { return null; }

            ParameterInfo[] parameters = method.GetParameters();
            string[]        types      = new string[parameters.Length];
            for ( int i = 0; i < parameters.Length; i++ ) { types[i] = parameters[i].ParameterType.FullName ?? parameters[i].ParameterType.Name; }

            return $"{method.Name}( {string.Join(", ", types)} )";
        }
        catch ( Exception ) { return null; }
    }


    public static StringTags GetTags( Exception e )
    {
        List<Pair> pairs =
        [
            new(nameof(Type), e.GetType().FullName),
            new(nameof(e.Message), e.Message),
            new(nameof(e.Source), e.Source),
            new(nameof(e.StackTrace), e.StackTrace),
            new("MethodSignature", TryGetMethodSignature(e))
        ];

        foreach ( DictionaryEntry entry in e.Data ) { pairs.Add(new Pair(entry.Key.ToString() ?? string.Empty, entry.Value?.ToString())); }

        return new StringTags([.. pairs], [e.ToString()]);
    }
}