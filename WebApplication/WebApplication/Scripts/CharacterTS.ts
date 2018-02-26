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

enum Fonction {
    Soin=1,
    Attaquant,
    Defenseur
}

class CharacterTS {
    public IdCharacter: number;
    public Name: string;
    public Firstname: string;
    public Type: Fonction;

    constructor(IdCharacter: number, Name: string, Firstname: string, Type: Fonction) {
        this.IdCharacter = IdCharacter;
        this.Name = Name;
        this.Firstname = Firstname;
        this.Type = Type;
    }

    public afficherCharacter(): JQuery {
        let myThis: CharacterTS = this;
        let div: JQuery = $('<div>' + this.Name + '</div>'); 
        div[0].onclick = function (e) {
            myThis.openInfoCharacter();
        }
        return div;
    }

    public openInfoCharacter(): void {
        alert('ouvrir info du personnage ' + this.Name);
    }


}