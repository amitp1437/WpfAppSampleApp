function userService() {
    $(document).ready(function () {
        var accessToken;
        //GetUserAuthenticationToken();
        //Get All the Employee
        function GetAuthenticated() {
            $.ajax({
                type: "GET",
                url: "http://localhost:51100/api/employee/Authenticate",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                headers: { "Authorization": accessToken.token_type + " " + accessToken.access_token },
                dataType: "json",
                success: function (data) {
                    alert("Authenticate --> " + data);
                }
            });
        }

        function GetAuthorized() {
            $.ajax({
                type: "GET",
                url: "http://localhost:51100/api/employee/GetEmployeeById?id=1",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                headers: { "Authorization": accessToken.token_type + " " + accessToken.access_token },
                dataType: "json",
                success: function (data) {
                    alert("Authorized --> " + data.FirstName);
                }
            });
        }

        //Get User Token using OWIN
        function GetUserAuthenticationToken(userName, password) {
            $.ajax({
                type: "POST",
                url: "http://localhost:51100/token",
                data: "grant_type=password&username=" + userName + "&password=" + password + "",
                contentType: "application/text; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    accessToken = {
                        access_token: data.access_token,
                        token_type: data.token_type
                    }
                    GetAuthenticated();
                    GetAuthorized();
                }
            });
        }

        $('#btnLogin').click(function () {
            $.ajax({
                type: "GET",
                url: "http://localhost:51100/api/employee/CheckUserCredetial?userName=" + $('#txtUserName').val() + "&password=" + $('#txtPassword').val(),
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert("user Login --> " + data.UserName);
                    GetUserAuthenticationToken(data.UserName, data.Password);
                }
            });
        });

    })
};

userService();