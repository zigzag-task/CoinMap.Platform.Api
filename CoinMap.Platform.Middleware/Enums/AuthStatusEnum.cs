using System.ComponentModel;

namespace CoinMap.Platform.Middleware.Enums
{
    public enum AuthStatusEnum : byte
    {
        [Description("User already exists")]
        UserAlreadyExists = 0,

        [Description("User creation failed! Please check user details and try again.")]
        UserCreationFailed = 1,

        [Description("User created successfully!")]
        UserCreatedSuccessfully = 2,

        [Description("Invalid username")]
        InvalidUsername = 3,

        [Description("Invalid password")]
        InvalidPassword = 4,

        [Description("Invalid token")]
        InvalidToken = 5,

        [Description("Token created successfully")]
        TokenCreatedSuccessfully = 6,
    }
}
