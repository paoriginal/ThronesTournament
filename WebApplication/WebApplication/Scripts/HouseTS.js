$(function () {
    $.ajax({
        type: "GET",
        url: "/House/GetHouses",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (success) {
            var list = success;
            $.each(JSON.parse(success), function (index, element) {
                var listCharacter = element.ListCharacters;
                //$.each(element.ListCharacters, function (index2, element2) {
                //    let character: CharacterTS = new CharacterTS(element2.IdCharacter, element2.Nom, element2.Prenom, null);
                //    listCharacter.push(character);
                //});
                var house = new HouseTS(element.IdHouse, element.NomHouse, element.NbUnities, listCharacter);
                HouseTS.listMaison.push(house);
            });
        },
        complete: function (data) {
            startGame();
        },
        error: function (error) {
            alert(error);
        }
    });
});
$(function () {
    //let listCharacter: Array<CharacterTS> = new Array<CharacterTS>();
    //listCharacter.push(new CharacterTS(1, "Connor", "Sarah", null));
    //listCharacter.push(new CharacterTS(2, "Potter", "Harry", null));
    //listCharacter.push(new CharacterTS(3, "Wizlet", "Raune", null));
    //listCharacter.push(new CharacterTS(4, "Oda", "Takuro", null));
    //HouseTS.listMaison.push(new HouseTS(0, "Café", 2500, listCharacter));
    //listCharacter = null;
    //listCharacter = new Array<CharacterTS>();
    //listCharacter.push(new CharacterTS(5, "Renouleau", "Sylvain", null));
    //listCharacter.push(new CharacterTS(6, "Neboit", "Jean-Charles", null));
    //listCharacter.push(new CharacterTS(7, "Chazarin", "Léna", null));
    //HouseTS.listMaison.push(new HouseTS(1, "Thé", 2000, listCharacter));
    //listCharacter = null;
    //listCharacter = new Array<CharacterTS>();
    //listCharacter.push(new CharacterTS(8, "Quick", "2001", null));
    //listCharacter.push(new CharacterTS(9, "Polasek", "Roman", null));
    //listCharacter.push(new CharacterTS(10, "Sanchez", "Pablo", null));
    //listCharacter.push(new CharacterTS(11, "Chazarin", "Nicolas", null));
    //listCharacter.push(new CharacterTS(12, "Pitt", "Brad", null));
    //HouseTS.listMaison.push(new HouseTS(2, "Ice-Tea", 6000, listCharacter));
    //HouseTS.listMaison.push(new HouseTS(3, "Coca-Cola", 2500, null));
    //HouseTS.listMaison.push(new HouseTS(4, "KFC", 2500, null));
});
var HouseTS = /** @class */ (function () {
    function HouseTS(IdHouse, Name, nbUnite, listHero) {
        this.listHero = new Array();
        this.IdHouse = IdHouse;
        this.Name = Name;
        this.nbUnite = nbUnite;
        this.listHero = listHero;
    }
    HouseTS.prototype.afficherHouse = function () {
        var myThis = this;
        var div = $('<div>' + this.Name + '</div>');
        div[0].onclick = function (e) {
            myThis.openInfoCharacter();
        };
        return div;
    };
    HouseTS.prototype.openInfoCharacter = function () {
        alert('ouvrir info du personnage ' + this.Name);
    };
    HouseTS.listMaison = new Array();
    return HouseTS;
}());
//# sourceMappingURL=HouseTS.js.map