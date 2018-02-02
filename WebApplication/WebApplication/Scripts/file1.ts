$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/api/Character/0",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (success) {
            let character: CharacterTS = new CharacterTS();
            character.firstName = success.firstName;
            character.lastName = success.lastName;
            $('#div_charac').append(success.afficherCharac());
        },
        error: function (error) {
            alert(error);
        }
    });
});

class CharacterTS {
    public firstName: string;
    public lastName: string;

    constructor() { }

    public afficherCharac(): JQuery
    {
        let myThis: CharacterTS = this;
        let div: JQuery = $('<div>' + this.firstName + " " + this.lastName + '</div>');

        return div;
    }
}