namespace DesignPatterns.Behavioral.ChainOfResponsibility;

public abstract class HttpHandler {
    protected HttpHandler? _next;
    public HttpHandler SetNext(HttpHandler next) { _next = next; return next; }
    public abstract bool Handle(string token, string role);
}

public class JwtAuthenticationHandler : HttpHandler {
    public override bool Handle(string token, string role) {
        if (string.IsNullOrEmpty(token)) return false;
        return _next?.Handle(token, role) ?? true;
    }
}

public class RoleAuthorizationHandler : HttpHandler {
    public override bool Handle(string token, string role) {
        if (role != "Admin") return false;
        return _next?.Handle(token, role) ?? true;
    }
}
