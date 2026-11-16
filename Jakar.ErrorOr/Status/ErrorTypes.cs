// Jakar.Extensions :: Jakar.ErrorOr
// 11/15/2026

namespace Jakar.Extensions;


/// <summary> <see cref="Error.Type"/> values (the same as Jakar.Extensions' <c>Constants.*_TYPE</c>). </summary>
internal static class ErrorTypes
{
    public const string ACCEPTED_TYPE = "Server.Accepted";
    public const string ALREADY_EXISTS_TYPE = "Server.AlreadyExists";
    public const string ALREADY_REPORTED_TYPE = "Server.AlreadyReported";
    public const string AMBIGUOUS_TYPE = "Client.Ambiguous";
    public const string BAD_GATEWAY_TYPE = "Server.BadGateway";
    public const string BAD_REQUEST_TYPE = "Client.BadRequest";
    public const string CLIENT_CLOSED_REQUEST_TYPE = "Client.ClosedRequest";
    public const string CLIENT_IS_OUTDATED_TYPE = "Client.Outdated";
    public const string CLIENT_IS_UNAVAILABLE_TYPE = "Client.Unavailable";
    public const string CONFLICT_TYPE = "General.Conflict";
    public const string CONTINUE_TYPE = "General.Continue";
    public const string CREATED_TYPE = "Server.Created";
    public const string DISABLED_TYPE = "User.Disabled";
    public const string EARLY_HINTS_TYPE = "EarlyHints";
    public const string EXPECTATION_FAILED_TYPE = "Client.ExpectationFailed";
    public const string EXPIRED_SUBSCRIPTION_TYPE = "User.Subscription.Expired";
    public const string FAILED_DEPENDENCY_TYPE = "Client.FailedDependency";
    public const string FORBIDDEN_TYPE = "General.Forbidden";
    public const string FOUND_TYPE = "Server.Found";
    public const string GATEWAY_TIMEOUT_TYPE = "Server.GatewayTimeout";
    public const string GENERAL_FAILURE_TYPE = "General.Failure";
    public const string GONE_TYPE = "Gone";
    public const string HTTP_VERSION_NOT_SUPPORTED_TYPE = "Server.HttpVersionNotSupported";
    public const string IM_USED_TYPE = "ImUsed";
    public const string INSUFFICIENT_STORAGE_TYPE = "Server.InsufficientStorage";
    public const string INTERNAL_SERVER_ERROR_TYPE = "Server.InternalServerError";
    public const string INVALID_SUBSCRIPTION_TYPE = "User.Subscription.Invalid";
    public const string LENGTH_REQUIRED_TYPE = "Client.LengthRequired";
    public const string LOCKED_TYPE = "User.Locked";
    public const string LOOP_DETECTED_TYPE = "LoopDetected";
    public const string METHOD_NOT_ALLOWED_TYPE = "Client.MethodNotAllowed";
    public const string MISDIRECTED_REQUEST_TYPE = "Client.MisdirectedRequest";
    public const string MOVED_TYPE = "Server.Moved";
    public const string MULTI_STATUS_TYPE = "Server.MultiStatus";
    public const string NETWORK_AUTHENTICATION_REQUIRED_TYPE = "Client.NetworkAuthenticationRequired";
    public const string NO_CONTENT_TYPE = "Server.NoContent";
    public const string NO_INTERNET_TYPE = "Internet.Disabled";
    public const string NO_INTERNET_WIFI_TYPE = "Internet.Disabled.WiFi";
    public const string NO_RESPONSE_TYPE = "NoResponse";
    public const string NO_SUBSCRIPTION_TYPE = "User.Subscription.None";
    public const string NON_AUTHORITATIVE_INFORMATION_TYPE = "Server.NonAuthoritativeInformation";
    public const string NOT_ACCEPTABLE_TYPE = "Client.NotAcceptable";
    public const string NOT_EXTENDED_TYPE = "Client.NotExtended";
    public const string NOT_FOUND_TYPE = "General.NotFound";
    public const string NOT_IMPLEMENTED_TYPE = "NotImplemented";
    public const string NOT_MODIFIED_TYPE = "Server.NotModified";
    public const string NOT_SET_TYPE = "General.NotSet";
    public const string OK_TYPE = "Ok";
    public const string PARTIAL_CONTENT_TYPE = "Server.PartialContent";
    public const string PASSWORD_VALIDATION_TYPE = "Password.Unauthorized";
    public const string PAYMENT_REQUIRED_TYPE = "Client.PaymentRequired";
    public const string PERMANENT_REDIRECT_TYPE = "Server.PermanentRedirect";
    public const string PRECONDITION_FAILED_TYPE = "Client.PreconditionFailed";
    public const string PRECONDITION_REQUIRED_TYPE = "Client.PreconditionRequired";
    public const string PROCESSING_TYPE = "Server.Processing";
    public const string PROXY_AUTHENTICATION_REQUIRED_TYPE = "Client.ProxyAuthenticationRequired";
    public const string REDIRECT_KEEP_VERB_TYPE = "Server.RedirectKeepVerb";
    public const string REDIRECT_METHOD_TYPE = "Server.Redirect";
    public const string REQUEST_ENTITY_TOO_LARGE_TYPE = "Client.RequestEntityTooLarge";
    public const string REQUEST_HEADER_FIELDS_TOO_LARGE_TYPE = "Client.RequestHeaderFieldsTooLarge";
    public const string REQUEST_TIMEOUT_TYPE = "Client.RequestTimeout";
    public const string REQUEST_URI_TOO_LONG_TYPE = "Client.RequestUriTooLong";
    public const string REQUESTED_RANGE_NOT_SATISFIABLE_TYPE = "Client.RequestedRangeNotSatisfiable";
    public const string RESET_CONTENT_TYPE = "Server.ResetContent";
    public const string SERVER_IS_OUTDATED_TYPE = "Server.Outdated";
    public const string SERVER_IS_UNAVAILABLE_TYPE = "Server.Unavailable";
    public const string SERVICE_UNAVAILABLE_TYPE = "Server.ServiceUnavailable";
    public const string SESSION_EXPIRED_TYPE = "Client.SessionExpired";
    public const string SWITCHING_PROTOCOLS_TYPE = "Server.SwitchingProtocols";
    public const string TEAPOT_TYPE = "Teapot";
    public const string TOO_EARLY_TYPE = "Client.TooEarly";
    public const string TOO_MANY_REQUESTS_TYPE = "Client.TooManyRequests";
    public const string UNAUTHORIZED_TYPE = "General.Unauthorized";
    public const string UNAVAILABLE_FOR_LEGAL_REASONS_TYPE = "Server.UnavailableForLegalReasons";
    public const string UNEXPECTED_TYPE = "General.Unexpected";
    public const string UNPROCESSABLE_ENTITY_TYPE = "Client.UnprocessableEntity";
    public const string UNSUPPORTED_MEDIA_TYPE_TYPE = "Client.UnsupportedMediaType";
    public const string UNUSED_TYPE = "Unused";
    public const string UPGRADE_REQUIRED_TYPE = "Client.UpgradeRequired";
    public const string USE_PROXY_TYPE = "UseProxy";
    public const string VALIDATION_TYPE = "General.Unexpected";
    public const string VARIANT_ALSO_NEGOTIATES_TYPE = "VariantAlsoNegotiates";
}
