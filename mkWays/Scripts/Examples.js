Examples = (function() {
    var myPublic = {};

    myPublic.asyncPost = function() {
        WebMethods.asyncPost(
            function(isSuccess, result) {
                if (isSuccess) {
                    alert(result);
                }
            }
        );
    };

    myPublic.asyncGet = function() {
        WebMethods.asyncGet(
            function(isSuccess, result) {
                if (isSuccess) {
                    alert(result);
                }
            }
        );
    };

    myPublic.asyncPostWithParams = function() {
        WebMethods.asyncPostWithParams(
            document.getElementById("example3-FirstName").value,
            document.getElementById("example3-LastName").value,
            function(isSuccess, result) {
                if (isSuccess) {
                    alert(result);
                }
            }
        );
    };

    myPublic.asyncGetWithParams = function() {
        WebMethods.asyncGetWithParams(
            document.getElementById("example4-FirstName").value,
            document.getElementById("example4-LastName").value,
            function(isSuccess, result) {
                if (isSuccess) {
                    alert(result);
                }
            }
        );
    };

    myPublic.blocking = function() {
        alert(WebMethods.blocking());
    };

    myPublic.getObject = function() {
        WebMethods.getObject(
            function(isSuccess, result) {
                if (isSuccess) {
                    //var data = JSON.parse(result);
                    alert(result);
                }
            }
        );
    };

    myPublic.getObjectDefaultSerialization = function () {
        WebMethods.getObjectDefaultSerialization(
            function (isSuccess, result) {
                if (isSuccess) {
                    //var data = JSON.parse(result);
                    alert(result);
                }
            }
        );
    };

    myPublic.sendModelAsParameter = function () {
        WebMethods.sendModelAsParameter(
            {
                ID: 1,
                Name: "MyModelName2112",
                Items: [1, 2, 3, 12],
                Description: "Will not be added to the model, because in the model it is private.",
                AdditionalDescription: "Will not be added to the model, because IgnoreAttribute is used."
            },
            function (isSuccess, result) {
                if (isSuccess) {
                    //var data = JSON.parse(result);
                    alert(result);
                }
            }
        );
    };

    return myPublic;
}());