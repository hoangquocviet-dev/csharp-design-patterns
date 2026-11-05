using System.Collections.Generic;

namespace DesignPatterns.Creational.Builder;

public class HttpRequest {
    public string Url { get; set; } = string.Empty;
    public string Method { get; set; } = "GET";
    public Dictionary<string, string> Headers { get; set; } = new();
    public string? Body { get; set; }
}

public class HttpRequestBuilder {
    private readonly HttpRequest _request = new();

    public HttpRequestBuilder WithUrl(string url) { _request.Url = url; return this; }
    public HttpRequestBuilder WithMethod(string method) { _request.Method = method; return this; }
    public HttpRequestBuilder AddHeader(string key, string value) { _request.Headers[key] = value; return this; }
    public HttpRequestBuilder WithBody(string body) { _request.Body = body; return this; }
    public HttpRequest Build() => _request;
}
