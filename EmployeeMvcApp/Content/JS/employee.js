function employeeService() {
    $(document).ready(function () {

        //if (sessionStorage.getItem("access_token") == undefined || sessionStorage.getItem("access_token") == '') {
        //    setLogout();
        //}
        //else {
        //    GetAllEmployees();
        //}

        GetAllEmployees();
        //Get All the Employee
        function GetAllEmployees() {
            $.ajax({
                type: "GET",
                url: "http://localhost:51100/api/employee/Getall",
                data: "{}",
                headers: { "Authorization": "bearer " + sessionStorage.getItem("access_token") },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //var json = JSON.parse(data);
                    $.each(data, function (index, obj) {
                        var row = '<tr><th scope="row"> ' + obj.id + ' </th> <td> ' + obj.firstName + ' </td> <td>' + obj.lastName + '</td> <td>' + obj.gender + '</td> <td>' + obj.salary + '</td> </tr>'
                        $("#tableEmployees tbody").append(row);
                    });
                }
            });
        }

        $('#btnLogout').click(function () {
            setLogout();
        })

        function setLogout() {
            sessionStorage.removeItem("access_token");
            window.location.href = window.applicationBaseUrl + 'User/Login';
        }
    })
};

employeeService();