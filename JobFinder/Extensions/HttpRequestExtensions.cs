namespace JobFinder.Extensions;

public static class HttpRequestExtensions
{
    private static string RequestedWithHeader = "X-Requested-With";
    private static string XmlHttpRequest = "XMLHttpRequest";

    public static bool IsAjaxRequest(this HttpRequest request)
    {
        if (request == null)
        {
            throw new ArgumentNullException("request");
        }

        if (request.Headers != null)
        {
            return request.Headers[RequestedWithHeader] == XmlHttpRequest;
        }

        return false;
    }
}
