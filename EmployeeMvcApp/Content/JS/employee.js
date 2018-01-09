function employeeService() {
    $(document).ready(function () {
        GetAllEmployees();

        //Get All the Employee
        function GetAllEmployees() {
            $.ajax({
                type: "GET",
                url: "http://localhost:51100/api/employee/Getall",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //var json = JSON.parse(data);
                    $.each(data, function (index, obj) {
                        var row = '<tr><th scope="row"> ' + obj.Id + ' </th> <td> ' + obj.FirstName + ' </td> <td>' + obj.LastName + '</td> <td>' + obj.Gender + '</td> <td>' + obj.Salary + '</td> </tr>'
                        $("#tableEmployees tbody").append(row);
                    });
                }
            });
        }
    })
};

employeeService();