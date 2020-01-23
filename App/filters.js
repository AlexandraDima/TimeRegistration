/// <reference path="controllers/likesscript.js" />

//app-name of the module, "gender"-filter name, (gender)-filter input
app.filter("gender", function () {
    return function (gender) {
        switch (gender) {
            case 1:
                return "Male";
            case 2:
                return "Female";
            case 3:
                return "Not disclosed";
        }
    }
})