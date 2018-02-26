//$(document).ready(function () {
//    $.ajax({
//        type: "GET",
//        url: "/Character",
//        data: {},
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (success) {
//            let list: CharacterTS[] = success as CharacterTS[];
//            $.each(success, function (index, element) {
//                let character: CharacterTS = new CharacterTS(element.IdCharacter, element.Nom, element.Prenom, element.Profil);
//                list.push(character);
//            });
//            list.forEach(function (element: CharacterTS) {
//                $('#div_list_character_ts').append(element.afficherCharacter);
//            });
//        },
//        error: function (error) {
//            alert(error);
//        }
//    });
//});
var Fonction;
(function (Fonction) {
    Fonction[Fonction["Soin"] = 1] = "Soin";
    Fonction[Fonction["Attaquant"] = 2] = "Attaquant";
    Fonction[Fonction["Defenseur"] = 3] = "Defenseur";
})(Fonction || (Fonction = {}));
var CharacterTS = /** @class */ (function () {
    function CharacterTS(IdCharacter, Name, Firstname, Type) {
        this.IdCharacter = IdCharacter;
        this.Name = Name;
        this.Firstname = Firstname;
        this.Type = Type;
    }
    CharacterTS.prototype.afficherCharacter = function () {
        var myThis = this;
        var div = $('<div>' + this.Name + '</div>');
        div[0].onclick = function (e) {
            myThis.openInfoCharacter();
        };
        return div;
    };
    CharacterTS.prototype.openInfoCharacter = function () {
        alert('ouvrir info du personnage ' + this.Name);
    };
    return CharacterTS;
}());
//# sourceMappingURL=CharacterTS.js.map