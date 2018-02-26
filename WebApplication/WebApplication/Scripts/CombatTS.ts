//$(document).ready(function () {
//    $.ajax({
//        type: "GET",
//        url: "/Combat",
//        data: {},
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (success) {
//            let list: CombatTS[] = success as CombatTS[];
//            $.each(success, function (index, element) {
//                let character: CombatTS = new CombatTS(element.IdHouseAttack, element.IdHouseDefense, element.NbUniteAttack, element.NbUniteDefense);
//                list.push(character);
//            });
//            list.forEach(function (element: CombatTS) {
//                $('#div_list_character_ts').append(element.afficherCombat);
//            });
//        },
//        error: function (error) {
//            alert(error);
//        }
//    });
//});


class CombatTS {
    static listCombat: Array<CombatTS> = new Array<CombatTS>();
    public IdHouseAttack: number;
    public IdHouseDefense: number;
    public NbUniteAttack: number;
    public NbUniteDefense: number;
    public IdHeroAttack: number;
    public listIdHeroDefense: Array<number> = new Array<number>();
    public listHeroSoins: Array<number> = new Array<number>();

    constructor(IdHouseAttack: number, IdHouseDefense: number) {
        this.IdHouseAttack = IdHouseAttack;
        this.IdHouseDefense = IdHouseDefense;
    }

    
    public afficherCombat(): JQuery {
        /*let myThis: CombatTS = this;
        let div: JQuery = $('<div>' + this.Name + '</div>');
        div[0].onclick = function (e) {
            myThis.openInfoCharacter();
        }
        return div;*/
        return null;
    }
    /*
    public openInfoCharacter(): void {
        alert('ouvrir info du personnage ' + this.Name);
    }
    */
}