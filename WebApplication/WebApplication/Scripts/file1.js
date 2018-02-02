$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/api/Character/0",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (success) {
            var character = new CharacterTS();
            character.firstName = success.firstName;
            character.lastName = success.lastName;
            $('#div_charac').append(success.afficherCharac());
        },
        error: function (error) {
            alert(error);
        }
    });
});
var CharacterTS = (function () {
    function CharacterTS() {
    }
    CharacterTS.prototype.afficherCharac = function () {
        var myThis = this;
        var div = $('<div>' + this.firstName + " " + this.lastName + '</div>');
        return div;
    };
    return CharacterTS;
}());
//# sourceMappingURL=file1.js.map