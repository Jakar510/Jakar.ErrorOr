// Jakar.Extensions :: Jakar.ErrorOr.Tests
// 10/02/2026

// Shared by the golden-file generator (compiled against Jakar.Extensions 10.x / Newtonsoft with LEGACY defined) and by GoldenFile_Tests.
// Every sample is deterministic, so the JSON 10.x wrote and the JSON 11.0 writes can be compared directly.

using System.Collections.Generic;



namespace Jakar.Extensions.Tests;


public static class GoldenSamples
{
    public static StringTags StringTags() => new([new Pair("field", "notes"), new Pair("nullable", null)], ["must be 5 characters or fewer", "required"]);
    public static Error      Error()      => Extensions.Error.Validation(StringTags(), "/items/1", "must be 5 characters or fewer", "Validation");
    public static Errors     Errors()     => Extensions.Errors.Create(new Alert("Heads up", "Something happened", TimeSpan.FromSeconds(30)), Error(), Extensions.Error.Validation(description: "second"));
    public static Alert      Alert()      => new("Heads up", "Something happened", TimeSpan.FromSeconds(30));


    /// <summary> File name → JSON, written with the serializer of the build this is compiled into. </summary>
    public static IEnumerable<(string Name, string Json)> All()
    {
        yield return ( "Errors", Errors().ToJson() );
        yield return ( "Alert", Alert().ToJson() );
    #if LEGACY
        yield return ( "Error", Error().ToJson() );
    #else
        yield return ( "Error", JsonCodec.ToJson(Error()) );
    #endif
    }
}