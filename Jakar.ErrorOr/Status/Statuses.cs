// Jakar.Extensions :: Jakar.Extensions
// 06/06/2022  3:43 PM

namespace Jakar.Extensions;


public static class Statuses
{
    private static readonly ConcurrentDictionary<Type, Status> __statusMap = new()
                                                                             {
                                                                                 [typeof(NotImplementedException)]     = Status.NotImplemented,
                                                                                 [typeof(UnauthorizedAccessException)] = Status.Unauthorized,
                                                                                 [typeof(ValidationException)]         = Status.BadRequest,
                                                                                 [typeof(ArgumentOutOfRangeException)] = Status.InternalServerError,
                                                                                 [typeof(ArgumentNullException)]       = Status.InternalServerError,
                                                                                 [typeof(ArgumentException)]           = Status.InternalServerError,
                                                                                 [typeof(InvalidOperationException)]   = Status.InternalServerError,
                                                                                 [typeof(FileLoadException)]           = Status.ServiceUnavailable,
                                                                                 [typeof(IOException)]                 = Status.ServiceUnavailable,
                                                                                 [typeof(AmbiguousMatchException)]     = Status.Conflict,
                                                                                 [typeof(DuplicateNameException)]      = Status.Conflict,
                                                                                 [typeof(AccessViolationException)]    = Status.Unauthorized,
                                                                                 [typeof(HttpRequestException)]        = Status.ServiceUnavailable,
                                                                                 [typeof(ValidationException)]         = Status.BadRequest,
                                                                                 [typeof(OperationCanceledException)]  = Status.RequestTimeout
                                                                             };
    public static Func<Exception, Status> GetStatusFromException { get; set; } = AsStatus;


    /// <summary> The localized title of <paramref name="status"/> (<see cref="IErrorTitles.Current"/> unless <paramref name="titles"/> is given). </summary>
    public static string GetErrorTitle( Status status, IErrorTitles? titles = null )
    {
        titles ??= IErrorTitles.Current;
        ArgumentNullException.ThrowIfNull(titles);

        return status switch
               {
                   Status.NotSet                        => titles.NotSet,
                   Status.Continue                      => titles.Continue,
                   Status.SwitchingProtocols            => titles.SwitchingProtocols,
                   Status.Processing                    => titles.Processing,
                   Status.EarlyHints                    => titles.EarlyHints,
                   Status.Ok                            => titles.Ok,
                   Status.Created                       => titles.Created,
                   Status.Accepted                      => titles.Accepted,
                   Status.NonAuthoritativeInformation   => titles.NonAuthoritativeInformation,
                   Status.NoContent                     => titles.NoContent,
                   Status.ResetContent                  => titles.ResetContent,
                   Status.PartialContent                => titles.PartialContent,
                   Status.MultiStatus                   => titles.MultiStatus,
                   Status.AlreadyReported               => titles.AlreadyReported,
                   Status.ImUsed                        => titles.ImUsed,
                   Status.Ambiguous                     => titles.Ambiguous,
                   Status.Moved                         => titles.Moved,
                   Status.Found                         => titles.Found,
                   Status.RedirectMethod                => titles.RedirectMethod,
                   Status.NotModified                   => titles.NotModified,
                   Status.UseProxy                      => titles.UseProxy,
                   Status.Unused                        => titles.Unused,
                   Status.RedirectKeepVerb              => titles.RedirectKeepVerb,
                   Status.PermanentRedirect             => titles.PermanentRedirect,
                   Status.BadRequest                    => titles.BadRequest,
                   Status.Unauthorized                  => titles.Unauthorized,
                   Status.PaymentRequired               => titles.PaymentRequired,
                   Status.Forbidden                     => titles.Forbidden,
                   Status.NotFound                      => titles.NotFound,
                   Status.MethodNotAllowed              => titles.MethodNotAllowed,
                   Status.NotAcceptable                 => titles.NotAcceptable,
                   Status.ProxyAuthenticationRequired   => titles.ProxyAuthenticationRequired,
                   Status.RequestTimeout                => titles.RequestTimeout,
                   Status.Conflict                      => titles.Conflict,
                   Status.Gone                          => titles.Gone,
                   Status.LengthRequired                => titles.LengthRequired,
                   Status.PreconditionFailed            => titles.PreconditionFailed,
                   Status.RequestEntityTooLarge         => titles.RequestEntityTooLarge,
                   Status.RequestUriTooLong             => titles.RequestUriTooLong,
                   Status.UnsupportedMediaType          => titles.UnsupportedMediaType,
                   Status.RequestedRangeNotSatisfiable  => titles.RequestedRangeNotSatisfiable,
                   Status.ExpectationFailed             => titles.ExpectationFailed,
                   Status.Teapot                        => titles.Teapot,
                   Status.MisdirectedRequest            => titles.MisdirectedRequest,
                   Status.UnprocessableEntity           => titles.UnprocessableEntity,
                   Status.Locked                        => titles.Locked,
                   Status.FailedDependency              => titles.FailedDependency,
                   Status.TooEarly                      => titles.TooEarly,
                   Status.UpgradeRequired               => titles.UpgradeRequired,
                   Status.PreconditionRequired          => titles.PreconditionFailed,
                   Status.TooManyRequests               => titles.TooManyRequests,
                   Status.Disabled                      => titles.Disabled,
                   Status.RequestHeaderFieldsTooLarge   => titles.RequestHeaderFieldsTooLarge,
                   Status.AlreadyExists                 => titles.AlreadyExists,
                   Status.NoResponse                    => titles.NoResponse,
                   Status.UnavailableForLegalReasons    => titles.UnavailableForLegalReasons,
                   Status.SessionExpired                => titles.SessionExpired,
                   Status.ClientClosedRequest           => titles.ClientClosedRequest,
                   Status.InternalServerError           => titles.InternalServerError,
                   Status.NotImplemented                => titles.NotImplemented,
                   Status.BadGateway                    => titles.BadGateway,
                   Status.ServiceUnavailable            => titles.ServerIsUnavailable,
                   Status.GatewayTimeout                => titles.GatewayTimeout,
                   Status.HttpVersionNotSupported       => titles.HttpVersionNotSupported,
                   Status.VariantAlsoNegotiates         => titles.VariantAlsoNegotiates,
                   Status.InsufficientStorage           => titles.InsufficientStorage,
                   Status.LoopDetected                  => titles.LoopDetected,
                   Status.NotExtended                   => titles.NotExtended,
                   Status.NetworkAuthenticationRequired => titles.NetworkAuthenticationRequired,
                   _                                    => throw new ArgumentOutOfRangeException(nameof(status), status, null)
               };
    }


    /// <summary> The <see cref="Error.Type"/> name of <paramref name="status"/>. </summary>
    public static string GetErrorType( Status status )
    {
        return status switch
               {
                   Status.NotSet                        => NOT_SET_TYPE,
                   Status.Continue                      => CONTINUE_TYPE,
                   Status.SwitchingProtocols            => SWITCHING_PROTOCOLS_TYPE,
                   Status.Processing                    => PROCESSING_TYPE,
                   Status.EarlyHints                    => EARLY_HINTS_TYPE,
                   Status.Ok                            => OK_TYPE,
                   Status.Created                       => CREATED_TYPE,
                   Status.Accepted                      => ACCEPTED_TYPE,
                   Status.NonAuthoritativeInformation   => NON_AUTHORITATIVE_INFORMATION_TYPE,
                   Status.NoContent                     => NO_CONTENT_TYPE,
                   Status.ResetContent                  => RESET_CONTENT_TYPE,
                   Status.PartialContent                => PARTIAL_CONTENT_TYPE,
                   Status.MultiStatus                   => MULTI_STATUS_TYPE,
                   Status.AlreadyReported               => ALREADY_REPORTED_TYPE,
                   Status.ImUsed                        => IM_USED_TYPE,
                   Status.Ambiguous                     => AMBIGUOUS_TYPE,
                   Status.Moved                         => MOVED_TYPE,
                   Status.Found                         => FOUND_TYPE,
                   Status.RedirectMethod                => REDIRECT_METHOD_TYPE,
                   Status.NotModified                   => NOT_MODIFIED_TYPE,
                   Status.UseProxy                      => USE_PROXY_TYPE,
                   Status.Unused                        => UNUSED_TYPE,
                   Status.RedirectKeepVerb              => REDIRECT_KEEP_VERB_TYPE,
                   Status.PermanentRedirect             => PERMANENT_REDIRECT_TYPE,
                   Status.BadRequest                    => BAD_REQUEST_TYPE,
                   Status.Unauthorized                  => UNAUTHORIZED_TYPE,
                   Status.PaymentRequired               => PAYMENT_REQUIRED_TYPE,
                   Status.Forbidden                     => FORBIDDEN_TYPE,
                   Status.NotFound                      => NOT_FOUND_TYPE,
                   Status.MethodNotAllowed              => METHOD_NOT_ALLOWED_TYPE,
                   Status.NotAcceptable                 => NOT_ACCEPTABLE_TYPE,
                   Status.ProxyAuthenticationRequired   => PROXY_AUTHENTICATION_REQUIRED_TYPE,
                   Status.RequestTimeout                => REQUEST_TIMEOUT_TYPE,
                   Status.Conflict                      => CONFLICT_TYPE,
                   Status.Gone                          => GONE_TYPE,
                   Status.LengthRequired                => LENGTH_REQUIRED_TYPE,
                   Status.PreconditionFailed            => PRECONDITION_FAILED_TYPE,
                   Status.RequestEntityTooLarge         => REQUEST_ENTITY_TOO_LARGE_TYPE,
                   Status.RequestUriTooLong             => REQUEST_URI_TOO_LONG_TYPE,
                   Status.UnsupportedMediaType          => UNSUPPORTED_MEDIA_TYPE_TYPE,
                   Status.RequestedRangeNotSatisfiable  => REQUESTED_RANGE_NOT_SATISFIABLE_TYPE,
                   Status.ExpectationFailed             => EXPECTATION_FAILED_TYPE,
                   Status.Teapot                        => TEAPOT_TYPE,
                   Status.MisdirectedRequest            => MISDIRECTED_REQUEST_TYPE,
                   Status.UnprocessableEntity           => UNPROCESSABLE_ENTITY_TYPE,
                   Status.Locked                        => LOCKED_TYPE,
                   Status.FailedDependency              => FAILED_DEPENDENCY_TYPE,
                   Status.TooEarly                      => TOO_EARLY_TYPE,
                   Status.UpgradeRequired               => UPGRADE_REQUIRED_TYPE,
                   Status.PreconditionRequired          => PRECONDITION_REQUIRED_TYPE,
                   Status.TooManyRequests               => TOO_MANY_REQUESTS_TYPE,
                   Status.Disabled                      => DISABLED_TYPE,
                   Status.RequestHeaderFieldsTooLarge   => REQUEST_HEADER_FIELDS_TOO_LARGE_TYPE,
                   Status.AlreadyExists                 => ALREADY_EXISTS_TYPE,
                   Status.NoResponse                    => NO_RESPONSE_TYPE,
                   Status.UnavailableForLegalReasons    => UNAVAILABLE_FOR_LEGAL_REASONS_TYPE,
                   Status.SessionExpired                => SESSION_EXPIRED_TYPE,
                   Status.ClientClosedRequest           => CLIENT_CLOSED_REQUEST_TYPE,
                   Status.InternalServerError           => INTERNAL_SERVER_ERROR_TYPE,
                   Status.NotImplemented                => NOT_IMPLEMENTED_TYPE,
                   Status.BadGateway                    => BAD_GATEWAY_TYPE,
                   Status.ServiceUnavailable            => SERVICE_UNAVAILABLE_TYPE,
                   Status.GatewayTimeout                => GATEWAY_TIMEOUT_TYPE,
                   Status.HttpVersionNotSupported       => HTTP_VERSION_NOT_SUPPORTED_TYPE,
                   Status.VariantAlsoNegotiates         => VARIANT_ALSO_NEGOTIATES_TYPE,
                   Status.InsufficientStorage           => INSUFFICIENT_STORAGE_TYPE,
                   Status.LoopDetected                  => LOOP_DETECTED_TYPE,
                   Status.NotExtended                   => NOT_EXTENDED_TYPE,
                   Status.NetworkAuthenticationRequired => NETWORK_AUTHENTICATION_REQUIRED_TYPE,
                   _                                    => throw new ArgumentOutOfRangeException(nameof(status), status, null)
               };
    }


    public static void RegisterStatus<TException>( Status status )
        where TException : Exception => __statusMap[typeof(TException)] = status;
    public static Status AsStatus( this Exception e )
    {
        Type type = e.GetType();
        if ( __statusMap.TryGetValue(type, out var status) ) { return status; }

        // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
        foreach ( KeyValuePair<Type, Status> kv in __statusMap )
        {
            if ( kv.Key.IsAssignableFrom(type) ) { return kv.Value; }
        }

        return Status.InternalServerError;
    }



    extension( HttpStatusCode code )
    {
        public Status ToStatus()     => (Status)code;
        public string ToStringFast() => code.ToStatus().ToStringFast();
    }



    extension( Status code )
    {
        public HttpStatusCode ToStatus() => (HttpStatusCode)code;
        public string ToStringFast() => code switch
                                        {
                                            Status.Continue                      => nameof(Status.Continue),
                                            Status.SwitchingProtocols            => nameof(Status.SwitchingProtocols),
                                            Status.Processing                    => nameof(Status.Processing),
                                            Status.EarlyHints                    => nameof(Status.EarlyHints),
                                            Status.Ok                            => nameof(Status.Ok),
                                            Status.Created                       => nameof(Status.Created),
                                            Status.Accepted                      => nameof(Status.Accepted),
                                            Status.NonAuthoritativeInformation   => nameof(Status.NonAuthoritativeInformation),
                                            Status.NoContent                     => nameof(Status.NoContent),
                                            Status.ResetContent                  => nameof(Status.ResetContent),
                                            Status.PartialContent                => nameof(Status.PartialContent),
                                            Status.MultiStatus                   => nameof(Status.MultiStatus),
                                            Status.AlreadyReported               => nameof(Status.AlreadyReported),
                                            Status.ImUsed                        => nameof(Status.ImUsed),
                                            Status.Ambiguous                     => nameof(Status.Ambiguous),
                                            Status.Moved                         => nameof(Status.Moved),
                                            Status.Found                         => nameof(Status.Found),
                                            Status.RedirectMethod                => nameof(Status.RedirectMethod),
                                            Status.NotModified                   => nameof(Status.NotModified),
                                            Status.UseProxy                      => nameof(Status.UseProxy),
                                            Status.Unused                        => nameof(Status.Unused),
                                            Status.RedirectKeepVerb              => nameof(Status.RedirectKeepVerb),
                                            Status.PermanentRedirect             => nameof(Status.PermanentRedirect),
                                            Status.BadRequest                    => nameof(Status.BadRequest),
                                            Status.Unauthorized                  => nameof(Status.Unauthorized),
                                            Status.PaymentRequired               => nameof(Status.PaymentRequired),
                                            Status.Forbidden                     => nameof(Status.Forbidden),
                                            Status.NotFound                      => nameof(Status.NotFound),
                                            Status.MethodNotAllowed              => nameof(Status.MethodNotAllowed),
                                            Status.NotAcceptable                 => nameof(Status.NotAcceptable),
                                            Status.ProxyAuthenticationRequired   => nameof(Status.ProxyAuthenticationRequired),
                                            Status.RequestTimeout                => nameof(Status.RequestTimeout),
                                            Status.Conflict                      => nameof(Status.Conflict),
                                            Status.Gone                          => nameof(Status.Gone),
                                            Status.LengthRequired                => nameof(Status.LengthRequired),
                                            Status.PreconditionFailed            => nameof(Status.PreconditionRequired),
                                            Status.RequestEntityTooLarge         => nameof(Status.RequestEntityTooLarge),
                                            Status.RequestUriTooLong             => nameof(Status.RequestUriTooLong),
                                            Status.UnsupportedMediaType          => nameof(Status.UnsupportedMediaType),
                                            Status.RequestedRangeNotSatisfiable  => nameof(Status.RequestedRangeNotSatisfiable),
                                            Status.ExpectationFailed             => nameof(Status.ExpectationFailed),
                                            Status.Teapot                        => nameof(Status.Teapot),
                                            Status.MisdirectedRequest            => nameof(Status.MisdirectedRequest),
                                            Status.UnprocessableEntity           => nameof(Status.UnprocessableEntity),
                                            Status.Locked                        => nameof(Status.Locked),
                                            Status.FailedDependency              => nameof(Status.FailedDependency),
                                            Status.TooEarly                      => nameof(Status.TooEarly),
                                            Status.UpgradeRequired               => nameof(Status.UpgradeRequired),
                                            Status.PreconditionRequired          => nameof(Status.PreconditionRequired),
                                            Status.TooManyRequests               => nameof(Status.TooManyRequests),
                                            Status.Disabled                      => nameof(Status.Disabled),
                                            Status.RequestHeaderFieldsTooLarge   => nameof(Status.RequestHeaderFieldsTooLarge),
                                            Status.AlreadyExists                 => nameof(Status.AlreadyExists),
                                            Status.NoResponse                    => nameof(Status.NoResponse),
                                            Status.UnavailableForLegalReasons    => nameof(Status.UnavailableForLegalReasons),
                                            Status.ClientClosedRequest           => nameof(Status.ClientClosedRequest),
                                            Status.InternalServerError           => nameof(Status.InternalServerError),
                                            Status.NotImplemented                => nameof(Status.NotImplemented),
                                            Status.BadGateway                    => nameof(Status.BadGateway),
                                            Status.ServiceUnavailable            => nameof(Status.ServiceUnavailable),
                                            Status.GatewayTimeout                => nameof(Status.GatewayTimeout),
                                            Status.HttpVersionNotSupported       => nameof(Status.HttpVersionNotSupported),
                                            Status.VariantAlsoNegotiates         => nameof(Status.VariantAlsoNegotiates),
                                            Status.InsufficientStorage           => nameof(Status.InsufficientStorage),
                                            Status.LoopDetected                  => nameof(Status.LoopDetected),
                                            Status.NotExtended                   => nameof(Status.NotExtended),
                                            Status.NetworkAuthenticationRequired => nameof(Status.NetworkAuthenticationRequired),
                                            _                                    => code.ToString()
                                        };
    }
}
