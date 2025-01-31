namespace CleanArchitecture.Domain.Models;
public sealed record SignUpModel
(
    string FullName,
    string UserName,
    string Password
);
